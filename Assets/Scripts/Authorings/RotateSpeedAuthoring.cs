using Unity.Entities;
using UnityEngine;

namespace Authorings
{
    public struct RotateSpeed : IComponentData
    {
        public float Speed;
    }

    public class RotateSpeedAuthoring : MonoBehaviour
    {
        public float Speed;

        private class Baker : Baker<RotateSpeedAuthoring>
        {
            public override void Bake(RotateSpeedAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent(entity, new RotateSpeed { Speed = authoring.Speed });
            }
        }
    }
}