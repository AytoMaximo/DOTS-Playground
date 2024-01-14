using Authorings;
using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;
using SystemState = Unity.Entities.SystemState;

namespace Systems
{
    public partial struct RotatingSystem : ISystem
    {
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<RotateSpeed>();
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            //deactivate system
            state.Enabled = false;
            return;
        
            //ExecuteWithoutJob(ref state);

            var rotationJob = new RotatingJob { DeltaTime = SystemAPI.Time.DeltaTime };
            rotationJob.ScheduleParallel();
        }

        private void ExecuteWithoutJob(ref SystemState state)
        {
            //foreach (var rotateSpeed in SystemAPI.Query<LocalTransform, RotateSpeed>())

            foreach (var (localTransform, rotateSpeed) in SystemAPI.Query<RefRW<LocalTransform>, RefRO<RotateSpeed>>()
                         .WithNone<Player>())
            {
                localTransform.ValueRW =
                    localTransform.ValueRO.RotateY(rotateSpeed.ValueRO.Speed * SystemAPI.Time.DeltaTime);
            }
        }

        [BurstCompile]
        [WithAll(typeof(RotatingCube))]
        public partial struct RotatingJob : IJobEntity
        {
            public float DeltaTime;

            //ref = read-write
            //in = read-only
            public void Execute(ref LocalTransform localTransform, in RotateSpeed rotateSpeed)
            {
                localTransform = localTransform.RotateY(rotateSpeed.Speed * DeltaTime);
            }
        }
    }
}