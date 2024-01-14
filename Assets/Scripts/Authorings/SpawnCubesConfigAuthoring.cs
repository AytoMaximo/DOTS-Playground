using Unity.Entities;
using UnityEngine;

namespace Authorings
{
    public struct SpawnCubesConfig : IComponentData
    {
        public Entity PrefabEntity;
        public int Count;
    }
    
    public class SpawnCubesConfigAuthoring : MonoBehaviour
    {
        public GameObject Prefab;
        public int AmountToSpawn;
        
        public class SpawnCubesConfigAuthoringBaker : Baker<SpawnCubesConfigAuthoring>
        {
            public override void Bake(SpawnCubesConfigAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.None);
                AddComponent(entity, new SpawnCubesConfig
                {
                    PrefabEntity = GetEntity(authoring.Prefab, TransformUsageFlags.Dynamic),
                    Count = authoring.AmountToSpawn
                });
            }
        }
    }
}