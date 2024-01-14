using Aspects;
using Authorings;
using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;

namespace Systems
{
    public partial struct HandleCubesSystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            foreach (var rotatingMovingCubeAspect in SystemAPI.Query<RotatingMovingCubeAspect>().WithAll<RotatingCube>())
            {
                rotatingMovingCubeAspect.MoveAndRotate(SystemAPI.Time.DeltaTime);
            }
        }

        [BurstCompile]
        public void OnDestroy(ref SystemState state)
        {
        }
    }
}