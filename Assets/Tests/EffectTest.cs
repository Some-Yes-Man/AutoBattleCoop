using NUnit.Framework;
using UnityEngine;
using AutoBattleCoop.Assets.Scripts.Effects;
using AutoBattleCoop.Assets.Scripts.Effects.Internal;
using UnityEngine.TestTools;
using System.Collections;

namespace AutoBattleCoop {
    class EffectTest {

        [UnityTest]
        public IEnumerator NegateWithoutRemoval() {
            GameObject gameObjectOne = new();
            AbstractUnit unitOne = gameObjectOne.AddComponent<TestUnit>();
            IEffectResolver existing = gameObjectOne.AddComponent<TestEffectBase>();

            GameObject gameObjectTwo = new();
            IEffectResolver incoming = gameObjectTwo.AddComponent<TestEffectNegateWithoutRemoval>();
            unitOne.ApplyEffect(incoming);

            Assert.True(existing.Active);
            Assert.False(incoming.Active);

            yield return new WaitForEndOfFrame();

            Assert.IsNotNull(unitOne.GetComponent<TestEffectBase>());
            Assert.IsNull(unitOne.GetComponent<TestEffectNegateWithoutRemoval>());
        }

        [Test]
        public void NegateWithoutRemoval_Inverted() {
            GameObject gameObjectOne = new();
            AbstractUnit unitOne = gameObjectOne.AddComponent<TestUnit>();
            gameObjectOne.AddComponent<TestEffectNegateWithoutRemoval>();

            GameObject gameObjectTwo = new();
            IEffectResolver incoming = gameObjectTwo.AddComponent<TestEffectBase>();
            unitOne.ApplyEffect(incoming);

            Assert.True(unitOne.GetComponent<TestEffectNegateWithoutRemoval>().Active);
            Assert.IsNull(unitOne.GetComponent<TestEffectBase>());
            Assert.False(incoming.Active);
        }

        [Test]
        public void Negate() {
            GameObject gameObjectOne = new();
            AbstractUnit unitOne = gameObjectOne.AddComponent<TestUnit>();
            gameObjectOne.AddComponent<TestEffectBase>();

            GameObject gameObjectTwo = new();
            IEffectResolver incoming = gameObjectTwo.AddComponent<TestEffectNegated>();
            unitOne.ApplyEffect(incoming);

            Assert.False(unitOne.GetComponent<TestEffectBase>().Active);
            Assert.IsNull(unitOne.GetComponent<TestEffectNegated>());
            Assert.False(incoming.Active);
        }

        [Test]
        public void Negate_Inverted() {
            GameObject gameObjectOne = new();
            AbstractUnit unitOne = gameObjectOne.AddComponent<TestUnit>();
            gameObjectOne.AddComponent<TestEffectNegated>();

            GameObject gameObjectTwo = new();
            IEffectResolver incoming = gameObjectTwo.AddComponent<TestEffectBase>();
            unitOne.ApplyEffect(incoming);

            Assert.False(unitOne.GetComponent<TestEffectNegated>().Active);
            Assert.IsNull(unitOne.GetComponent<TestEffectBase>());
            Assert.False(incoming.Active);
        }

        [Test]
        public void Join() {
            GameObject gameObjectOne = new();
            AbstractUnit unitOne = gameObjectOne.AddComponent<TestUnit>();
            gameObjectOne.AddComponent<TestEffectBase>();

            GameObject gameObjectTwo = new();
            IEffectResolver incoming = gameObjectTwo.AddComponent<TestEffectJoined>();
            unitOne.ApplyEffect(incoming);

            Assert.False(unitOne.GetComponent<TestEffectBase>().Active);
            Assert.IsNull(unitOne.GetComponent<TestEffectJoined>());
            Assert.False(incoming.Active);
            Assert.IsNotNull(unitOne.GetComponent<TestEffectJoinedResult>());
            Assert.True(unitOne.GetComponent<TestEffectJoinedResult>().Active);
        }

        [Test]
        public void Join_Inverted() {
            GameObject gameObjectOne = new();
            AbstractUnit unitOne = gameObjectOne.AddComponent<TestUnit>();
            gameObjectOne.AddComponent<TestEffectJoined>();

            GameObject gameObjectTwo = new();
            IEffectResolver incoming = gameObjectTwo.AddComponent<TestEffectBase>();
            unitOne.ApplyEffect(incoming);

            Assert.False(unitOne.GetComponent<TestEffectJoined>().Active);
            Assert.IsNull(unitOne.GetComponent<TestEffectBase>());
            Assert.False(incoming.Active);
            Assert.IsNotNull(unitOne.GetComponent<TestEffectJoinedResult>());
            Assert.True(unitOne.GetComponent<TestEffectJoinedResult>().Active);
        }

        [Test]
        public void Add() {
            GameObject gameObjectOne = new();
            AbstractUnit unitOne = gameObjectOne.AddComponent<TestUnit>();
            gameObjectOne.AddComponent<TestEffectBase>();

            GameObject gameObjectTwo = new();
            IEffectResolver incoming = gameObjectTwo.AddComponent<TestEffectAdded>();
            unitOne.ApplyEffect(incoming);

            Assert.True(unitOne.GetComponent<TestEffectBase>().Active);
            Assert.IsNotNull(unitOne.GetComponent<TestEffectAdded>());
            Assert.True(unitOne.GetComponent<TestEffectAdded>().Active);
        }

        [Test]
        public void Add_Inverted() {
            GameObject gameObjectOne = new();
            AbstractUnit unitOne = gameObjectOne.AddComponent<TestUnit>();
            gameObjectOne.AddComponent<TestEffectAdded>();

            GameObject gameObjectTwo = new();
            IEffectResolver incoming = gameObjectTwo.AddComponent<TestEffectBase>();
            unitOne.ApplyEffect(incoming);

            Assert.True(unitOne.GetComponent<TestEffectAdded>().Active);
            Assert.IsNotNull(unitOne.GetComponent<TestEffectBase>());
            Assert.True(unitOne.GetComponent<TestEffectBase>().Active);
        }

        [Test]
        public void Duplicate() {
            GameObject gameObjectOne = new();
            AbstractUnit unitOne = gameObjectOne.AddComponent<TestUnit>();
            gameObjectOne.AddComponent<TestEffectBase>();

            GameObject gameObjectTwo = new();
            IEffectResolver incoming = gameObjectTwo.AddComponent<TestEffectBase>();
            unitOne.ApplyEffect(incoming);

            Assert.AreEqual(1, unitOne.GetComponents<TestEffectBase>().Length);
            Assert.True(unitOne.GetComponent<TestEffectBase>().Active);
            Assert.IsNotNull(unitOne.GetComponent<TestEffectBase>());
            Assert.True(incoming.Active);
        }

    }
}
