using System;

namespace AutoBattleCoop.Assets.Scripts.Effects.Internal {
    public interface IEffectResolver {

        EffectType Type { get; }

        bool Active { get; }

        void Deactivate();

        Tuple<EffectResolveType, Type> ResolveEffects(IEffectResolver incomingEffect) {
            return new(EffectResolveType.Added, null);
        }

    }
}
