using AutoBattleCoop.Assets.Scripts.Damage;
using AutoBattleCoop.Assets.Scripts.Effects.Internal;
using AutoBattleCoop.Assets.Scripts.Stats;
using System;
using System.Linq;
using UnityEngine;

namespace AutoBattleCoop.Assets.Scripts {
    public abstract class AbstractUnit : MonoBehaviour, IDamageResolver {

        public EUnitFaction Faction { get; protected set; } = EUnitFaction.Unknown;

        // Hitpoints

        [field: SerializeField]
        public int BaseMaxHitPoints { get; protected set; }
        public int MaxHitPoints { get { return this.ModifyStat(EStatType.HitPoints, this.BaseMaxHitPoints); } private set { } }
        public int CurrentHitPoints { get; private set; }

        // Initiative

        [field: SerializeField]
        public int BaseInitiative { get; protected set; }
        public int CurrentInitiave { get { return this.ModifyStat(EStatType.Initiative, this.BaseInitiative); } private set { } }

        private int ModifyStat(EStatType statType, int baseStat) {
            int modifiedStat = baseStat;
            foreach (var resolver in this.gameObject.GetComponents<IStatModifier>()) {
                if (resolver.StatType == statType) {
                    modifiedStat += resolver.ResolveStats();
                }
            }

            return modifiedStat;
        }

        public int ApplyDamage(int damage, EDamageType damageType) {
            int cumulativeDamageTaken = 0;
            foreach (var resolver in this.gameObject.GetComponents<IDamageResolver>()) {
                cumulativeDamageTaken += resolver.ResolveDamage(damage, damageType, this);
            }

            this.BaseMaxHitPoints -= Mathf.Max(0, cumulativeDamageTaken);

            return cumulativeDamageTaken;
        }

        public int ResolveDamage(int baseDamage, EDamageType damageType, AbstractUnit unit) {
            return baseDamage;
        }

        public void ApplyEffect(IEffectResolver incomingEffect) {
            Tuple<IEffectResolver, EEffectResolveType, Type> selectedExistingEffect = new(null, EEffectResolveType.Added, null);
            foreach (var effect in this.gameObject.GetComponents<IEffectResolver>().Where(x => x.Active)) {
                if (effect.Type == incomingEffect.Type) {
                    selectedExistingEffect = new(null, EEffectResolveType.Duplicate, null);
                }

                Tuple<EEffectResolveType, Type> resolution = effect.ResolveEffects(incomingEffect);
                if (resolution.Item1 >= selectedExistingEffect.Item2) {
                    selectedExistingEffect = new(effect, resolution.Item1, resolution.Item2);
                }
            }

            switch (selectedExistingEffect.Item2) {
                case EEffectResolveType.Duplicate:
                    Debug.Log("Duplicate effect applied.");
                    break;
                case EEffectResolveType.Negated_Without_Removal:
                    Debug.Log("Effect negated without removal.");
                    incomingEffect.Deactivate();
                    break;
                case EEffectResolveType.Negated:
                    Debug.Log("Effect negated with removal.");
                    incomingEffect.Deactivate();
                    selectedExistingEffect.Item1.Deactivate();
                    Destroy(selectedExistingEffect.Item1 as MonoBehaviour);
                    break;
                case EEffectResolveType.Joined:
                    this.gameObject.AddComponent(selectedExistingEffect.Item3);
                    selectedExistingEffect.Item1.Deactivate();
                    Destroy(selectedExistingEffect.Item1 as MonoBehaviour);
                    incomingEffect.Deactivate();
                    Destroy(incomingEffect as MonoBehaviour);
                    break;
                case EEffectResolveType.Added:
                    this.gameObject.AddComponent(incomingEffect.GetType());
                    break;
                default:
                    Debug.LogWarning("Oh no, that's not a valid effect.");
                    break;
            }
        }

    }
}
