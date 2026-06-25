using System;

namespace AutoBattleCoop.Assets.Scripts.Effects.Internal {
    public interface IEffectResolver {

        EEffectType Type { get; }

        bool Active { get; }

        void Deactivate();

        Tuple<EEffectResolveType, Type> ResolveEffects(IEffectResolver incomingEffect) {
            return new(EEffectResolveType.Added, null);
        }

    }
}
