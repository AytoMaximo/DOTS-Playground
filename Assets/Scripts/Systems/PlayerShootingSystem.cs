using System;
using Authorings;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.EventSystems;
using Vanilla;

namespace Systems
{
    public partial class PlayerShootingSystem : SystemBase
    {
        public event EventHandler OnShoot;
        
        protected override void OnCreate()
        {
            RequireForUpdate<Player>();
        }

        protected override void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                var playerEntity = SystemAPI.GetSingletonEntity<Player>();
                EntityManager.SetComponentEnabled<Stunned>(playerEntity, true);
            }
            
            if (Input.GetKeyDown(KeyCode.Y))
            {
                var playerEntity = SystemAPI.GetSingletonEntity<Player>();
                EntityManager.SetComponentEnabled<Stunned>(playerEntity, false);
            }
            
            if (!Input.GetKeyDown(KeyCode.Space)) return;

            var config = SystemAPI.GetSingleton<SpawnCubesConfig>();

            var buffer = new EntityCommandBuffer(WorldUpdateAllocator);
            foreach (var(localTransform, entity) in SystemAPI.Query<RefRO<LocalTransform>>()
                         .WithAll<Player>()
                         .WithDisabled<Stunned>()
                         .WithEntityAccess())
            {
                var spawnedEntity = buffer.Instantiate(config.PrefabEntity);
                buffer.SetComponent(spawnedEntity, new LocalTransform
                {
                    Position = localTransform.ValueRO.Position,
                    Rotation = quaternion.identity,
                    Scale = 1f
                });
                buffer.SetComponent(spawnedEntity, new Movement
                {
                    MovementVector = localTransform.ValueRO.Forward()
                });
                
                OnShoot?.Invoke(entity, EventArgs.Empty);
                PlayerShootManager.Instance.PlayerShoot(localTransform.ValueRO.Position);
            }
            
            buffer.Playback(EntityManager);
        }
    }
}