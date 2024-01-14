using Unity.Entities;
using UnityEngine;

namespace Authorings
{
    public struct Stunned : IComponentData, IEnableableComponent
    {
    }
    
    public class StunnedAuthoring : MonoBehaviour
    {
        private class StunnedAuthoringBaker : Baker<StunnedAuthoring>
        {
            public override void Bake(StunnedAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent<Stunned>(entity);
                SetComponentEnabled<Stunned>(entity,false);
            }
        }
    }
}