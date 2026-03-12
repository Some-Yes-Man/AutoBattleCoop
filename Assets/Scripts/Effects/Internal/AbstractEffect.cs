using System;
using UnityEngine;

namespace AutoBattleCoop.Assets.Scripts.Effects.Internal {
    public abstract class AbstractEffect : MonoBehaviour, IEffectResolver {

        private static readonly IEffectResolver staticResolver = new DummyEffectResolver();

        [field: SerializeField]
        public string Name { get; protected set; }

        [field: SerializeField]
        public EffectType Type { get; protected set; }

        [field: SerializeField]
        public bool Active { get; protected set; }

        protected AbstractEffect() {
            Active = true;
        }

        public void Deactivate() {
            Active = false;
        }

        public virtual Tuple<EffectResolveType, Type> ResolveEffects(IEffectResolver incomingEffect) {
            return staticResolver.ResolveEffects(incomingEffect);
        }

    }
}
