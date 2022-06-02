using Photon.Deterministic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Quantum
{
    public unsafe class Turn : SystemMainThreadFilter<Turn.Player>
    {

        public override void Update(Frame f, ref Player player)
        {
            var input = f.GetPlayerInput(player.Link->Player);

            //FPVector3 newDirection = FPVector3.MoveTowards(player.Transform->Position, input->mousePos, 50);
            //Log.Info(player.Transform->Position + "\n" + input->mousePos);
            //Draw.Line(player.Transform ->Position, input->mousePos , ColorRGBA.Red);
            if (f.Unsafe.TryGetPointer<Turret>(player.Link->visualTurret, out var turret))
            {
                if (f.Unsafe.TryGetPointer<Transform3D>(player.Link->visualTurret, out var turretTransform))
                {  
                    FPVector3 newDirection = -turretTransform->Position + input->mousePos;
                    turretTransform->Rotation = FPQuaternion.Slerp(turretTransform->Rotation, FPQuaternion.LookRotation(newDirection, FPVector3.Up), turret->speed * f.DeltaTime);
                }

                   
            }
            
        }

        public unsafe struct Player
        {
            public EntityRef Entity;            //Đối tượng
            public PhysicsBody3D* Move;         //Điều khiển
            public Tank* Link;                //Đối tượng truyền vào
        }
    }
}
