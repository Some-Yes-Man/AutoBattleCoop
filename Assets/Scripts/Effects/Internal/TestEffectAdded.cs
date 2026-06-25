using AutoBattleCoop.Assets.Scripts.Effects.Internal;
using System;

namespace AutoBattleCoop.Assets.Scripts.Effects {
    public class TestEffectAdded : AbstractEffect {

        public TestEffectAdded() {
            Type = EEffectType._TestEffectAdded;
        }

        public override Tuple<EEffectResolveType, Type> ResolveEffects(IEffectResolver incomingEffect) {
            return new(EEffectResolveType.Added, null);
        }

    }
}
