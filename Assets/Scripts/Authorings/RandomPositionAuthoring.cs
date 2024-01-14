using Unity.Entities;
using UnityEngine;

namespace Authorings
{
    public struct RandomPosition : IComponentData
    {
        public Vector3 MinPosition;
        public Vector3 MaxPosition;
    }

    public class RandomPositionAuthoring : MonoBehaviour
    {
        public Vector3 MinPosition;
        public Vector3 MaxPosition;

        private class Baker : Baker<RandomPositionAuthoring>
        {
            public override void Bake(RandomPositionAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent(entity,
                    new RandomPosition { MinPosition = authoring.MinPosition, MaxPosition = authoring.MaxPosition });
            }
        }
    }
}