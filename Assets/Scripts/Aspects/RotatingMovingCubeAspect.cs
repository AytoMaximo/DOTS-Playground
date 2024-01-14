using Authorings;
using Unity.Entities;
using Unity.Transforms;

namespace Aspects
{
    public readonly partial struct RotatingMovingCubeAspect : IAspect
    {
        public readonly RefRW<LocalTransform> LocalTransform;
        public readonly RefRO<RotateSpeed> RotateSpeed;
        public readonly RefRO<Movement> Movement;

        public void MoveAndRotate(float deltaTime)
        {
            LocalTransform.ValueRW = LocalTransform.ValueRO.RotateY(RotateSpeed.ValueRO.Speed * deltaTime);
            LocalTransform.ValueRW = LocalTransform.ValueRO.Translate(Movement.ValueRO.MovementVector * deltaTime);
        }
    }
}