using RPG.Core;
using RPG.Saving;
using RPG.Stats;
using UnityEngine;

namespace RPG.Attributes
{
    public class Health : MonoBehaviour, ISaveable
    {
        [SerializeField] float healthPoint = 100f;

        bool isDead = false;

        private void Start()
        {
            healthPoint = GetComponent<BaseStats>().GetHealth();
        }

        public bool IsDead()
        {
            return isDead;
        }

        public void TakeDamage(float damage)
        {
            healthPoint = Mathf.Max(healthPoint - damage, 0);
            if (healthPoint == 0)
            {
                Die();
            }
        }

        public float GetPercentage()
        {
            return 100 * (healthPoint / GetComponent<BaseStats>().GetHealth());
        }

        private void Die()
        {
            if (isDead) return;

            isDead = true;
            GetComponent<Animator>().SetTrigger("die");
            GetComponent<ActionScheduler>().CancelCurrentAction();
        }

        public object CaptureState()
        {
            return healthPoint;
        }

        //마지막으로 저장된 체력 불러오기
        public void RestoreState(object state)
        {
            healthPoint = (float)state;
            if (healthPoint == 0)
            {
                Die();
            }

        }

    }
}
