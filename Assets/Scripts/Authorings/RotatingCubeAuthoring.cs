using Unity.Entities;
using UnityEngine;

namespace Authorings
{
    public struct RotatingCube : IComponentData
    {
    }

    public class RotatingCubeAuthoring : MonoBehaviour
    {
        private class RotatingCubeBaker : Baker<RotatingCubeAuthoring>
        {
            public override void Bake(RotatingCubeAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent<RotatingCube>(entity);
            }
        }
    }
}