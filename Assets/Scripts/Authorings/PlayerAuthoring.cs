using Unity.Entities;
using UnityEngine;

namespace Authorings
{
    public struct Player : IComponentData
    {
    }

    public class PlayerAuthoring : MonoBehaviour
    {
        private class PlayerAuthoringBaker : Baker<PlayerAuthoring>
        {
            public override void Bake(PlayerAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent<Player>(entity);
            }
        }
    }
}