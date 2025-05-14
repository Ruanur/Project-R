using RPG.Core;
using RPG.Saving;
using RPG.Stats;
using RPG.Utils;
using System;
using UnityEngine;
using UnityEngine.Events;

namespace RPG.Attributes
{
    public class Health : MonoBehaviour, ISaveable
    {
        [SerializeField] float regenerationPercentage = 70f;
        [SerializeField] TakeDamageEvent takeDamage;
        [SerializeField] UnityEvent onDie;

        [System.Serializable]
        public class TakeDamageEvent : UnityEvent<float>
        {
        }

        LazyValue<float> healthPoints;

        bool isDead = false;

        private void Awake()
        {
            healthPoints = new LazyValue<float>(GetInitialHealth);
        }

        private float GetInitialHealth()
        {
            return GetComponent<BaseStats>().GetStat(Stat.Health);
        }

        private void Start()
        {
            healthPoints.ForceInit();
            //타겟 레벨 변동 시 체력이 차지 않는 버그 수정, 게임 시작 시 체력을 모두 채움
            healthPoints.value = GetMaxHealthPoints();
        }

        private void OnEnable()
        {
            GetComponent<BaseStats>().onLevelUp += RegenerateHealth;
        }

        private void OnDisable()
        {
            GetComponent<BaseStats>().onLevelUp -= RegenerateHealth;
        }

        public bool IsDead()
        {
            return isDead;
        }

        public void TakeDamage(GameObject instigator, float damage)
        {
            healthPoints.value = Mathf.Max(healthPoints.value - damage, 0);

            //사망, 체력 0
            if (healthPoints.value == 0)
            {
                //UnityEvent 호출, 사망 사운드 
                onDie.Invoke();
                Die();
                //경험치 보상
                AwardExperience(instigator);
            }
            else
            {
                takeDamage.Invoke(damage);
            }
        }

        public void Heal(float healthToRestore)
        {
            healthPoints.value = Mathf.Min(healthPoints.value + healthToRestore, GetMaxHealthPoints());
        }

        public float GetHealthPoints()
        {
            return healthPoints.value;
        }

        public float GetMaxHealthPoints()
        {
            return GetComponent<BaseStats>().GetStat(Stat.Health);
        }

        //체력 퍼센테이지
        public float GetPercentage()
        {
            return 100 * GetFraction();
        }

        //체력 비율 계산
        public float GetFraction()
        {
            return healthPoints.value / GetComponent<BaseStats>().GetStat(Stat.Health);
        }

        private void Die()
        {
            if (isDead) return;

            isDead = true;
            GetComponent<Animator>().SetTrigger("die");
            GetComponent<ActionScheduler>().CancelCurrentAction();
            //경비병 사망시 오브젝트가 남아있는 버그 발견, 플레이어를 제외한 개체가 사망 시 오브젝트 삭제 
            if (!gameObject.CompareTag("Player"))
            {
                Destroy(gameObject, 1f);
            }
        }

        private void AwardExperience(GameObject instigator)
        {
            Experience experience = instigator.GetComponent<Experience>();
            if (experience == null) { return; }

            experience.GainExperience(GetComponent<BaseStats>().GetStat(Stat.ExperienceReward));
        }

        private void RegenerateHealth()
        {
            float regenHealthPoints = GetComponent<BaseStats>().GetStat(Stat.Health) * (regenerationPercentage / 100);
            healthPoints.value = Mathf.Max(healthPoints.value, regenHealthPoints);
        }

        public object CaptureState()
        {
            return healthPoints.value;
        }

        //마지막으로 저장된 체력 불러오기
        public void RestoreState(object state)
        {
            healthPoints.value = (float)state;
            if (healthPoints.value == 0)
            {
                Die();
            }

        }


    }
}
