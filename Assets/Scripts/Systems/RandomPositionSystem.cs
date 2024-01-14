using Authorings;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Systems
{
    public partial class RandomPositionSystem : SystemBase
    {
        protected override void OnStartRunning()
        {
            Entities.ForEach((ref LocalTransform localTransform, in RandomPosition randomPosition) =>
            {
                var randomX = UnityEngine.Random.Range(randomPosition.MinPosition.x, randomPosition.MaxPosition.x);
                var randomZ = UnityEngine.Random.Range(randomPosition.MinPosition.z, randomPosition.MaxPosition.z);

                localTransform.Position = new float3(randomX, 0, randomZ);
            }).Run();
        }

        protected override void OnUpdate()
        {
            // pass
        }
    }
}