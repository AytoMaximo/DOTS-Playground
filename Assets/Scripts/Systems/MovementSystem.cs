using Authorings;
using Unity.Entities;
using Unity.Mathematics;

namespace Systems
{
    public partial class MovementSystem : SystemBase
    {
        protected override void OnCreate()
        {
            RequireForUpdate<Movement>();
        }

        protected override void OnStartRunning()
        {
            foreach (var movement in SystemAPI.Query<RefRW<Movement>>())
            {
                movement.ValueRW.MovementVector = new float3(
                    UnityEngine.Random.Range(-1f, 1f), 
                    0,
                    UnityEngine.Random.Range(-1f, 1f));
            }

            base.OnStartRunning();
        }

        protected override void OnUpdate()
        {
            
        }
    }
}