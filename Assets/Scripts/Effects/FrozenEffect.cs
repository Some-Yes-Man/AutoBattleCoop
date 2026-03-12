using AutoBattleCoop.Assets.Scripts.Effects.Internal;
using System;

namespace AutoBattleCoop.Assets.Scripts.Effects {
    public class FrozenEffect : AbstractEffect {

        public FrozenEffect() {
            Type = EffectType.Frozen;
        }

        public override Tuple<EffectResolveType, Type> ResolveEffects(IEffectResolver incomingEffect) {
            return new(EffectResolveType.Added, null);
        }

    }
}
