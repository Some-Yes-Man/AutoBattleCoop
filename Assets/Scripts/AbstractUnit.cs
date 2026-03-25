using AutoBattleCoop.Assets.Scripts.Damage;
using AutoBattleCoop.Assets.Scripts.Effects.Internal;
using System;
using System.Linq;
using UnityEngine;

namespace AutoBattleCoop.Assets.Scripts {
    public abstract class AbstractUnit : MonoBehaviour, IDamageResolver {

        [field: SerializeField]
        public int HitPoints { get; protected set; }

        [field: SerializeField]
        public int Initiative { get; protected set; }

        public EUnitFaction Faction { get; protected set; } = EUnitFaction.Unknown;

        public int ApplyDamage(int damage, EDamageType damageType) {
            int cumulativeDamageTaken = 0;
            foreach (var resolver in this.gameObject.GetComponents<IDamageResolver>()) {
                cumulativeDamageTaken += resolver.ResolveDamage(damage, damageType, this);
            }

            this.HitPoints -= Mathf.Max(0, cumulativeDamageTaken);

            return cumulativeDamageTaken;
        }

        public int ResolveDamage(int baseDamage, EDamageType damageType, AbstractUnit unit) {
            return baseDamage;
        }

        public void ApplyEffect(IEffectResolver incomingEffect) {
            Tuple<IEffectResolver, EffectResolveType, Type> selectedExistingEffect = new(null, EffectResolveType.Added, null);
            foreach (var effect in this.gameObject.GetComponents<IEffectResolver>().Where(x => x.Active)) {
                if (effect.Type == incomingEffect.Type) {
                    selectedExistingEffect = new(null, EffectResolveType.Duplicate, null);
                }

                Tuple<EffectResolveType, Type> resolution = effect.ResolveEffects(incomingEffect);
                if (resolution.Item1 >= selectedExistingEffect.Item2) {
                    selectedExistingEffect = new(effect, resolution.Item1, resolution.Item2);
                }
            }

            switch (selectedExistingEffect.Item2) {
                case EffectResolveType.Duplicate:
                    Debug.Log("Duplicate effect applied.");
                    break;
                case EffectResolveType.Negated_Without_Removal:
                    Debug.Log("Effect negated without removal.");
                    incomingEffect.Deactivate();
                    break;
                case EffectResolveType.Negated:
                    Debug.Log("Effect negated with removal.");
                    incomingEffect.Deactivate();
                    selectedExistingEffect.Item1.Deactivate();
                    Destroy(selectedExistingEffect.Item1 as MonoBehaviour);
                    break;
                case EffectResolveType.Joined:
                    this.gameObject.AddComponent(selectedExistingEffect.Item3);
                    selectedExistingEffect.Item1.Deactivate();
                    Destroy(selectedExistingEffect.Item1 as MonoBehaviour);
                    incomingEffect.Deactivate();
                    Destroy(incomingEffect as MonoBehaviour);
                    break;
                case EffectResolveType.Added:
                    this.gameObject.AddComponent(incomingEffect.GetType());
                    break;
                default:
                    Debug.LogWarning("Oh no, that's not a valid effect.");
                    break;
            }
        }

    }
}
