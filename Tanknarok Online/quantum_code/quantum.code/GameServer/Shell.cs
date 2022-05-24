using Photon.Deterministic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantum
{
    public unsafe class Shell : SystemMainThreadFilter<Shell.Bullet>, ISignalOnCollisionEnter3D, ISignalOnTriggerEnter3D
    {
        public void OnCollisionEnter3D(Frame f, CollisionInfo3D info)
        {

            var entity = info.Entity;       // Tank
            var other = info.Other;         // Item
            if (f.Unsafe.TryGetPointer<Tank>(entity, out var x) && f.Unsafe.TryGetPointer<ItemPower>(other, out var y))
            {
                x->currentWeapon = y->weapon;
                var weapon = f.FindAsset<AttackStyle>(y->weapon.Id);
                x->interval = weapon.interval;
                x->bulletAmount = weapon.bulletAmount;
                Log.Info("Thay vũ khí!");
                if (f.Unsafe.TryGetPointer<Transform3D>(other, out var Tran))
                {
                    Tran->Position = new FPVector3(f.RNG->Next(-15,15), 60, f.RNG->Next(-10, 10));
                }
                    
                else
                    f.Destroy(other);
            }
            if (f.Unsafe.TryGetPointer<Tank>(entity, out var t))
                return;
            f.Destroy(info.Entity);
        }

        public void OnTriggerEnter3D(Frame f, TriggerInfo3D info)
        {
            var entity = info.Entity;       // Tank
            var other = info.Other;         // Item
            Log.Info(entity + " va chạm với " + other);
            if (f.Unsafe.TryGetPointer<Tank>(entity, out var x) && f.Unsafe.TryGetPointer<ItemPower>(other, out var y))
            {
                x->currentWeapon = y->weapon;
                var weapon = f.FindAsset<AttackStyle>(y->weapon.Id);
                x->interval = weapon.interval;
                x->bulletAmount = weapon.bulletAmount;
                f.Destroy(other);
            }
        }

        public override void Update(Frame f, ref Bullet bullet)
        {
            if (bullet.Link->TimeToDesTroy > 0)
            {
                bullet.Link->TimeToDesTroy -= f.DeltaTime;
                if (bullet.Link->TimeToDesTroy <= 0)
                {
                    f.Destroy(bullet.Entity);
                }
            }
        }

        public unsafe struct Bullet
        {
            public EntityRef Entity;            //Đối tượng
            public PhysicsBody3D* Move;         //Điều khiển
            public Transform3D* Transform;      //Trạng thái vật lý
            public Weapon* Link;                //Đối tượng truyền vào
        }
    }
}
