using UnityEngine;

namespace AutoBattleCoop {
    public abstract class AbstractEffect : MonoBehaviour {

        [field: SerializeField] public EffectType Type { get; protected set; }

        public EffectResolve ResolveEffectOutcome(AbstractEffect otherEffect) {
            return EffectResolve.Added;
        }

        // Placeholder
        public void IssueEffect(AbstractEffect otherEffect) {
            return;
        }

        private void ResolveEffect(AbstractEffect otherEffect, EffectResolve resolve) {

        }

    }
}
