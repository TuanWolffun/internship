using Photon.Deterministic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Quantum
{
    public unsafe class Movement : SystemMainThreadFilter<Movement.Player>, ISignalOnPlayerDataSet
    {

        public override void Update(Frame f, ref Player player)
        {
            var input = f.GetPlayerInput(player.Link->Player);
            
            //if (input->Direction.SqrMagnitude > 1)      //Chống Hack -_-
             //   input->Direction = input->Direction.Normalized;
            
            var moveDir = input->Direction.XOY;
            //player.Move->AddForce(moveDir * player.Link->accelation);        //Di chuyển
            if (moveDir == default)
                player.Move->Velocity = FPVector3.Lerp(player.Move->Velocity, default, player.Link->braking * f.DeltaTime);
            else
            {
             
                player.Move->Velocity += moveDir * f.DeltaTime * player.Link->accelation;
                player.Move->Velocity = FPVector3.ClampMagnitude(player.Move->Velocity, player.Link->maxSpeed);
                player.Transform->Rotation = FPQuaternion.Slerp(player.Transform->Rotation, FPQuaternion.LookRotation(moveDir), player.Link->rotationSpeed * f.DeltaTime);
            }
        }

        public void OnPlayerDataSet(Frame f, PlayerRef player)
        {
            var data = f.GetPlayerData(player);
            var prototype = f.FindAsset<EntityPrototype>(data.Prefab.Id);
            var e = f.Create(prototype);
            if (f.Unsafe.TryGetPointer<Tank>(e, out var Link))
                Link->Player = player;
            if (f.Unsafe.TryGetPointer<Transform3D>(e, out var Transform))
            {
                var ran = new Random();
                Transform->Position = new FPVector3(f.RNG->Next(-15,15), 0, f.RNG->Next(-10, 10));
                //Transform->Position = new FPVector3(5, 0, 6);
            }
                
        }

        public unsafe struct Player
        {
            public EntityRef Entity;            //Đối tượng
            public PhysicsBody3D* Move;         //Điều khiển
            public Transform3D* Transform;      //Trạng thái vật lý
            public Tank* Link;                  //Đối tượng truyền vào
        }
    }
}
