using NUnit.Framework;
using UnityEngine;
using Assets.Scripts.Effects;
using AutoBattleCoop.Assets.Scripts.Effects;

namespace AutoBattleCoop {
    class EffectTest {

        [Test]
        public void Resolve() {
            GameObject gameObject = new();
            gameObject.AddComponent<TestUnit>();
            gameObject.AddComponent<ColdEffect>();

            AbstractUnit unit = gameObject.GetComponent<AbstractUnit>();
            unit.ApplyEffect(new GameObject().AddComponent<WetEffect>());

            Assert.IsNotNull(unit.GetComponent<ColdEffect>());
            Assert.IsNotNull(unit.GetComponent<WetEffect>());
        }
    }
}
