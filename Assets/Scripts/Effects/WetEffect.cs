using Assets.Scripts.Effects;
using System;

namespace AutoBattleCoop.Assets.Scripts.Effects {
    public class WetEffect : AbstractEffect {

        public override Tuple<EffectResolveType, Type> ResolveEffects(IEffectResolver incomingEffect) {
            if (incomingEffect.Type == EffectType.Sad) {
                return new(EffectResolveType.Joined, typeof(WetEffect));
            }
            return new(EffectResolveType.Added, null);
        }

    }
}
