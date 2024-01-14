using System;
using Systems;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

namespace Vanilla
{
    public class PlayerShootManager : MonoBehaviour
    {
        public static PlayerShootManager Instance { get; private set; }

        [SerializeField] private GameObject shootPopupPrefab;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            //RefECSFromMono();
        }

        public void PlayerShoot(Vector3 playerPosition)
        {
            Instantiate(shootPopupPrefab, playerPosition, Quaternion.identity);
        }

        private void RefECSFromMono()
        {
            var playerShootingSystem = World.DefaultGameObjectInjectionWorld.GetExistingSystemManaged<PlayerShootingSystem>();
            playerShootingSystem.OnShoot += OnShoot;
        }

        private void OnShoot(object sender, EventArgs e)
        {
            var playerEntity = (Entity) sender;
            var localTransform = World.DefaultGameObjectInjectionWorld.EntityManager.GetComponentData<LocalTransform>(playerEntity);
            Instantiate(shootPopupPrefab, localTransform.Position, Quaternion.identity);
        }
    }
}