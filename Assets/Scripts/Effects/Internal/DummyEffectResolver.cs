namespace AutoBattleCoop.Assets.Scripts.Effects.Internal {
    internal class DummyEffectResolver : IEffectResolver {

        public EEffectType Type => throw new System.NotImplementedException();

        public bool Active => throw new System.NotImplementedException();

        public void Deactivate() {
            throw new System.NotImplementedException();
        }

    }
}
