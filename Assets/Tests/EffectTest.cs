using NUnit.Framework;
using UnityEngine;
using AutoBattleCoop.Assets.Scripts.Effects;
using UnityEngine.TestTools;
using System.Collections;
using AutoBattleCoop.Assets.Scripts.Effects.Internal;
using AutoBattleCoop.Assets.Scripts;

namespace Assets.Tests {
    class EffectTest {

        [UnityTest]
        public IEnumerator NegateWithoutRemoval() {
            GameObject target = new();
            AbstractUnit targetUnit = target.AddComponent<TestUnit>();
            IEffectResolver existing = target.AddComponent<TestEffectBase>();
            IEffectResolver incoming = new GameObject().AddComponent<TestEffectNegateWithoutRemoval>();

            targetUnit.ApplyEffect(incoming);
            Assert.True(existing.Active);
            Assert.False(incoming.Active);

            yield return new WaitForEndOfFrame();
            Assert.IsNotNull(targetUnit.GetComponent<TestEffectBase>());
            Assert.IsNull(targetUnit.GetComponent<TestEffectNegateWithoutRemoval>());
        }

        [UnityTest]
        public IEnumerator NegateWithoutRemoval_Inverted() {
            GameObject target = new();
            AbstractUnit targetUnit = target.AddComponent<TestUnit>();
            IEffectResolver existing = target.AddComponent<TestEffectNegateWithoutRemoval>();
            IEffectResolver incoming = new GameObject().AddComponent<TestEffectBase>();

            targetUnit.ApplyEffect(incoming);
            Assert.True(existing.Active);
            Assert.False(incoming.Active);

            yield return new WaitForEndOfFrame();
            Assert.IsNotNull(targetUnit.GetComponent<TestEffectNegateWithoutRemoval>());
            Assert.IsNull(targetUnit.GetComponent<TestEffectBase>());
        }

        [UnityTest]
        public IEnumerator Negate() {
            GameObject target = new();
            AbstractUnit targetUnit = target.AddComponent<TestUnit>();
            IEffectResolver existing = target.AddComponent<TestEffectBase>();
            IEffectResolver incoming = new GameObject().AddComponent<TestEffectNegated>();

            targetUnit.ApplyEffect(incoming);
            Assert.False(existing.Active);
            Assert.False(incoming.Active);

            yield return new WaitForEndOfFrame();
            Assert.IsNull(targetUnit.GetComponent<TestEffectBase>());
            Assert.IsNull(targetUnit.GetComponent<TestEffectNegated>());
        }

        [UnityTest]
        public IEnumerator Negate_Inverted() {
            GameObject target = new();
            AbstractUnit targetUnit = target.AddComponent<TestUnit>();
            IEffectResolver existing = target.AddComponent<TestEffectNegated>();
            IEffectResolver incoming = new GameObject().AddComponent<TestEffectBase>();

            targetUnit.ApplyEffect(incoming);
            Assert.False(existing.Active);
            Assert.False(incoming.Active);

            yield return new WaitForEndOfFrame();
            Assert.IsNull(targetUnit.GetComponent<TestEffectNegated>());
            Assert.IsNull(targetUnit.GetComponent<TestEffectBase>());
        }

        [UnityTest]
        public IEnumerator Join() {
            GameObject target = new();
            AbstractUnit targetUnit = target.AddComponent<TestUnit>();
            IEffectResolver existing = target.AddComponent<TestEffectBase>();
            IEffectResolver incoming = new GameObject().AddComponent<TestEffectJoined>();

            targetUnit.ApplyEffect(incoming);
            Assert.False(existing.Active);
            Assert.False(incoming.Active);

            yield return new WaitForEndOfFrame();
            Assert.IsNull(targetUnit.GetComponent<TestEffectBase>());
            Assert.IsNull(targetUnit.GetComponent<TestEffectJoined>());
            Assert.IsNotNull(targetUnit.GetComponent<TestEffectJoinedResult>());
            Assert.True(targetUnit.GetComponent<TestEffectJoinedResult>().Active);
        }

        [UnityTest]
        public IEnumerator Join_Inverted() {
            GameObject target = new();
            AbstractUnit targetUnit = target.AddComponent<TestUnit>();
            IEffectResolver existing = target.AddComponent<TestEffectJoined>();
            IEffectResolver incoming = new GameObject().AddComponent<TestEffectBase>();

            targetUnit.ApplyEffect(incoming);
            Assert.False(existing.Active);
            Assert.False(incoming.Active);

            yield return new WaitForEndOfFrame();
            Assert.IsNull(targetUnit.GetComponent<TestEffectJoined>());
            Assert.IsNull(targetUnit.GetComponent<TestEffectBase>());
            Assert.IsNotNull(targetUnit.GetComponent<TestEffectJoinedResult>());
            Assert.True(targetUnit.GetComponent<TestEffectJoinedResult>().Active);
        }

        [UnityTest]
        public IEnumerator Add() {
            GameObject target = new();
            AbstractUnit targetUnit = target.AddComponent<TestUnit>();
            IEffectResolver existing = target.AddComponent<TestEffectBase>();
            IEffectResolver incoming = new GameObject().AddComponent<TestEffectAdded>();

            targetUnit.ApplyEffect(incoming);
            Assert.True(existing.Active);
            Assert.True(incoming.Active);

            yield return new WaitForEndOfFrame();
            Assert.IsNotNull(targetUnit.GetComponent<TestEffectBase>());
            Assert.IsNotNull(targetUnit.GetComponent<TestEffectAdded>());
        }

        [UnityTest]
        public IEnumerator Add_Inverted() {
            GameObject target = new();
            AbstractUnit targetUnit = target.AddComponent<TestUnit>();
            IEffectResolver existing = target.AddComponent<TestEffectAdded>();
            IEffectResolver incoming = new GameObject().AddComponent<TestEffectBase>();

            targetUnit.ApplyEffect(incoming);
            Assert.True(existing.Active);
            Assert.True(incoming.Active);

            yield return new WaitForEndOfFrame();
            Assert.IsNotNull(targetUnit.GetComponent<TestEffectAdded>());
            Assert.IsNotNull(targetUnit.GetComponent<TestEffectBase>());
        }

        [UnityTest]
        public IEnumerator Duplicate() {
            GameObject target = new();
            AbstractUnit targetUnit = target.AddComponent<TestUnit>();
            IEffectResolver existing = target.AddComponent<TestEffectBase>();
            IEffectResolver incoming = new GameObject().AddComponent<TestEffectBase>();

            targetUnit.ApplyEffect(incoming);
            Assert.True(existing.Active);
            Assert.True(incoming.Active);

            yield return new WaitForEndOfFrame();
            Assert.AreEqual(1, targetUnit.GetComponents<TestEffectBase>().Length);
            Assert.IsNotNull(targetUnit.GetComponent<TestEffectBase>());
        }

    }
}
