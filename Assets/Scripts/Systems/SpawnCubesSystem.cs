using Authorings;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Systems
{
    public partial class SpawnCubesSystem : SystemBase
    {
        protected override void OnCreate()
        {
            RequireForUpdate<SpawnCubesConfig>();
        }

        protected override void OnUpdate()
        {
            this.Enabled = false;

            var config = SystemAPI.GetSingleton<SpawnCubesConfig>();

            //SpawnByOne(config);
            SpawnMany(config);
        }

        private void SpawnByOne(SpawnCubesConfig config)
        {
            for (var i = 0; i < config.Count; i++)
            {
                var spawnedEntity = EntityManager.Instantiate(config.PrefabEntity);
                Spawn(spawnedEntity);
            }
        }

        private void SpawnMany(SpawnCubesConfig config)
        {
            var spawnedEntities = EntityManager.Instantiate(config.PrefabEntity, config.Count, Allocator.Temp);
            foreach (var spawnedEntity in spawnedEntities)
            {
                Spawn(spawnedEntity);
            }
        }

        private void Spawn(Entity spawnedEntity)
        {
            SystemAPI.SetComponent(spawnedEntity, new LocalTransform // <---- this guy is faster
                //EntityManager.SetComponentData(spawnedEntity, new LocalTransform
                {
                    Position =
                        new float3(UnityEngine.Random.Range(-4f, 20f), 0.6f, UnityEngine.Random.Range(-10f, 20f)),
                    Rotation = quaternion.identity,
                    Scale = 1f
                });
            
            //Alternative, cas previous approach needs transform fields to be mentioned, or it will be set to 0:
            //LocalTransform.FromPosition(new float3(UnityEngine.Random.Range(-4f, 20f), 0.6f,UnityEngine.Random.Range(-10f, 20f)));
        }
    }
}