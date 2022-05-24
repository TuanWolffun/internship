using Photon.Deterministic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantum
{
    public unsafe class Attack : SystemMainThreadFilter<Attack.Player>
    {

        public override void Update(Frame f, ref Player player)
        {
            if (player.Link->currentWeapon == null) {
                Log.Info("Start");
                player.Link->currentWeapon = player.Link->defaultAttack;
             }
           
            var input = f.GetPlayerInput(player.Link->Player);
            if (player.Link->interval > 0)
            {
                player.Link->interval -= 1; //Time.deltaTime;
                return;
            }
            
            if (!input->Fire)
                return;

            FireABullet(f, ref player);
        }
        
        public void ChangeAttackStyle(Frame f, ref AssetRefAttackStyle attackStyle, ref Player player)
        {
            player.Link->currentWeapon = attackStyle;
            var weapon = f.FindAsset<AttackStyle>(attackStyle.Id);
            player.Link->interval = weapon.interval;
            player.Link->bulletAmount = weapon.bulletAmount;        
        }
        
        private void FireABullet(Frame f, ref Player player)
        {
            var weapon = f.FindAsset<AttackStyle>(player.Link->currentWeapon.Id);
            
            weapon.Fire(f, player.Transform->Position, player.Transform->Forward);
            player.Link->bulletAmount -= 1;
            player.Link->interval = weapon.interval;
            if (player.Link->bulletAmount <= 0)
                ChangeAttackStyle(f, ref player.Link->defaultAttack, ref player);
            
        }

        public struct Player
        {
            public EntityRef Entity;            //Đối tượng
            public PhysicsBody3D* Move;         //Điều khiển
            public Transform3D* Transform;      //Trạng thái vật lý
            public Tank* Link;                  //Đối tượng truyền vào
        }
    }
}
