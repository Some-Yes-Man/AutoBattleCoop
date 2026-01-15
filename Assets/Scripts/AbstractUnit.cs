using System;
using System.Collections.Generic;
using UnityEngine;

namespace AutoBattleCoop {
    public abstract class AbstractUnit : MonoBehaviour {

        [field: SerializeField]
        public int HitPoints { get; protected set; }

        [field: SerializeField]
        public int Initiative { get; protected set; }

        public EUnitFaction Faction { get; protected set; } = EUnitFaction.Unknown;

        private int cumulativeDamageTaken = 0;

        public void ApplyDamage(int damage, EDamageType damageType) {
            this.cumulativeDamageTaken = 0;
            foreach (var resolver in this.gameObject.GetComponents<IDamageResolver>()) {
                resolver.ResolveDamage(damage, damageType, this);
            }
            this.HitPoints -= Mathf.Max(0, this.cumulativeDamageTaken);
        }

        public void ReportDamage(int damage) {
            this.cumulativeDamageTaken += damage;
        }

        public void AddEffect(AbstractEffect effect) {
        }

        public void RemoveEffect(AbstractEffect effect) {
        }

        public void ApplyEffect(AbstractEffect newEffect) {
            List<Tuple<AbstractEffect, EffectResolve>> listOfEffects = new List<Tuple<AbstractEffect, EffectResolve>>();
            var activeEffects = gameObject.GetComponents<AbstractEffect>();
            foreach (var effect in activeEffects) {
                effect.ResolveEffectOutcome(newEffect);
            }
            if (listOfEffects.Count > 0) return; // not the real end -> effect needs to be added
            listOfEffects.Sort(); // wont work :/

            EffectResolve effectType = listOfEffects[0].Item2;
            switch (effectType) {
                case EffectResolve.Negated:
                    // call negated() on all effects and newEffect
                    break;
                case EffectResolve.Joined:
                    // call joined(newEffect) on all effects
                    break;
                case EffectResolve.Added:
                    // just add new newEffect to gameobject
                    break;
                default:
                    Debug.LogWarning("Oh no, that's not a valid effect.");
                    break;
            }
        }

    }
}
