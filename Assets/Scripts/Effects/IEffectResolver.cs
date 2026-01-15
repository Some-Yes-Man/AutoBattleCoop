using System;

namespace AutoBattleCoop.Assets.Scripts.Effects {
    public interface IEffectResolver {

        EffectType Type { get; }

        Tuple<EffectResolveType, Type> ResolveEffects(IEffectResolver incomingEffect) {
            return new(EffectResolveType.Added, null);
        }

    }
}
