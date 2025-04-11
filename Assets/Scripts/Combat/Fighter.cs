using RPG.Core;
using RPG.Movement;
using System;
using UnityEngine;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour, IAction
    {
        //몬스터 기준으로 몇 반경 외로 이동할 지
        [SerializeField] float timeBetweenAttacks = 1f;


        //무장 위치
        [SerializeField] Transform RightHandTransform = null;
        [SerializeField] Transform LeftHandTransform = null;
        [SerializeField] Weapon defaultweapon = null;
        //장비를 이름으로 저장하고 불러오기, 동일한 이름이 있을 경우 위험 요소가 있음
        //uuid로 저장하고 불러오게 구현 예정
        [SerializeField] string defaultweaponName = "Unarmed";

        Health target;
        float timeSinceLastAttack = Mathf.Infinity;
        Weapon currentWeapon = null;

        private void Start()
        {
            Weapon weapon = Resources.Load<Weapon>(defaultweaponName);
            EquipWeapon(weapon);
        }


        private void Update()
        {
            timeSinceLastAttack += Time.deltaTime;

            if (target == null) return;
            if (target.IsDead()) return;

            if (!GetIsInRange())
            {
                GetComponent<Mover>().MoveTo(target.transform.position, 1f);
            }
            else
            {
                GetComponent<Mover>().Cancel();
                AttackBehavior();
            }
        }

        public void EquipWeapon(Weapon weapon)
        {
            currentWeapon = weapon;
            Animator animator = GetComponent<Animator>();
            weapon.Spawn(RightHandTransform, LeftHandTransform, animator);
        }

        private void AttackBehavior()
        {
            transform.LookAt(target.transform);
            if (timeSinceLastAttack > timeBetweenAttacks)
            {
                //Hit() 이벤트 트리거
                TriggerAttack();
                timeSinceLastAttack = 0;
            }
        }

        private void TriggerAttack()
        {
            GetComponent<Animator>().ResetTrigger("stopAttack");
            GetComponent<Animator>().SetTrigger("attack");
        }

        //애니메이션 이벤트
        void Hit()
        {
            if (target == null) { return; }

            if (currentWeapon.HasProjectile())
            {
                currentWeapon.LaunchProjectile(RightHandTransform, LeftHandTransform, target);
            }
            else
            {
                target.TakeDamage(currentWeapon.GetDamage());
            }
        }

        void Shoot()
        {
            Hit();
        }

        private bool GetIsInRange()
        {
            return Vector3.Distance(transform.position, target.transform.position) < currentWeapon.GetRange();
        }

        public bool CanAttack(GameObject combatTarget)
        {
            if (combatTarget == null) { return false; }
            Health targetToTest = combatTarget.GetComponent<Health>();
            return targetToTest != null && !targetToTest.IsDead();
        }

        public void Attack(GameObject combatTarget)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            target = combatTarget.GetComponent<Health>();
        }

        public void Cancel()
        {
            StopAttack();
            target = null;
            GetComponent<Mover>().Cancel();
        }

        private void StopAttack()
        {
            GetComponent<Animator>().ResetTrigger("attack");
            //움직임이 감지되면 공격 애니메이션을 멈춤
            GetComponent<Animator>().SetTrigger("stopAttack");
        }

    }
}