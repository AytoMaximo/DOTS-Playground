using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace Authorings
{
    public struct Movement : IComponentData
    {
        public float3 MovementVector;
    }

    public class MovementAuthoring : MonoBehaviour
    {
        public float3 MovementVector;

        private class MovementAuthoringBaker : Baker<MovementAuthoring>
        {
            public override void Bake(MovementAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent(entity, new Movement { MovementVector = authoring.MovementVector });
            }
        }
    }
}