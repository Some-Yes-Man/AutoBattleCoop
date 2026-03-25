using AutoBattleCoop;
using AutoBattleCoop.Assets.Scripts;
using AutoBattleCoop.Assets.Scripts.Damage;
using NUnit.Framework;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

namespace Assets.Tests {
    class DamageTest {

        private static EDamageType[] GetDamageTypes() {
            return (EDamageType[])Enum.GetValues(typeof(EDamageType));
        }

        [UnityTest]
        public IEnumerator DefaultDamage([ValueSource("GetDamageTypes")] EDamageType damageType) {
            AbstractUnit targetUnit = new GameObject().AddComponent<TestUnit>();
            int actualDamageDone = targetUnit.ApplyDamage(100, damageType);

            Assert.AreEqual(100, actualDamageDone);

            yield return null;
        }

        [UnityTest]
        public IEnumerator DoubleDamageExceptForTestDamageType([ValueSource("GetDamageTypes")] EDamageType damageType) {
            GameObject target = new();
            AbstractUnit targetUnit = target.AddComponent<TestUnit>();
            target.AddComponent<TestEffectDoubleDamage>();

            int actualDamageDone = targetUnit.ApplyDamage(100, damageType);

            Assert.AreEqual((damageType == EDamageType._Test) ? 100 : 200, actualDamageDone);
            yield return null;
        }

        [UnityTest]
        public IEnumerator HalfDamageExceptForTestDamageType([ValueSource("GetDamageTypes")] EDamageType damageType) {
            GameObject target = new();
            AbstractUnit targetUnit = target.AddComponent<TestUnit>();
            target.AddComponent<TestEffectHalfDamage>();

            int actualDamageDone = targetUnit.ApplyDamage(100, damageType);

            Assert.AreEqual((damageType == EDamageType._Test) ? 100 : 50, actualDamageDone);
            yield return null;
        }

    }
}
