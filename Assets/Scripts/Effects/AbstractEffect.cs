using AutoBattleCoop.Assets.Scripts.Effects;
using System;
using UnityEngine;

namespace Assets.Scripts.Effects {
    public abstract class AbstractEffect : MonoBehaviour, IEffectResolver {

        private static readonly IEffectResolver staticResolver = new DummyEffectResolver();

        [field: SerializeField]
        public string Name { get; protected set; }

        [field: SerializeField]
        public EffectType Type { get; protected set; }

        public virtual Tuple<EffectResolveType, Type> ResolveEffects(IEffectResolver incomingEffect) {
            return staticResolver.ResolveEffects(incomingEffect);
        }

    }
}
