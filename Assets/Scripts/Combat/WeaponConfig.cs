using RPG.Attributes;
using RPG.Stats;
using UnityEngine;

namespace RPG.Combat
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Weapons/Make New Weapon", order = 0)]
    public class WeaponConfig : ScriptableObject
    {
        [SerializeField] AnimatorOverrideController animatorOverride = null;
        [SerializeField] Weapon equippedPrefab = null;
        [SerializeField] float weaponDamage = 5f;
        [SerializeField] float percentageBonus = 0f;
        [SerializeField] float weaponRange = 2f;
        [SerializeField] bool isRightHanded = true; //에디터 인스펙터 내에서 설정 가능, 오른손 or 왼손 장비
        [SerializeField] Projectile projectile = null;

        const string weaponName = "Weapon";

        //
        public Weapon Spawn(Transform RightHand, Transform LeftHand, Animator animator)
        {
            DestroyOldWeapon(RightHand, LeftHand);

            Weapon weapon = null;

            if (equippedPrefab != null)
            {
                Transform handTransform = GetTransform(RightHand, LeftHand);
                weapon = Instantiate(equippedPrefab, handTransform);
                weapon.gameObject.name = weaponName;
            }

            var overrideController = animator.runtimeAnimatorController as AnimatorOverrideController;
            if (animatorOverride != null)
            {
                animator.runtimeAnimatorController = animatorOverride;
            }
            else if(overrideController != null)
            {        
                animator.runtimeAnimatorController = overrideController.runtimeAnimatorController;            
            }

            return weapon;
        }

        private void DestroyOldWeapon(Transform rightHand, Transform leftHand)
        {
            Transform oldWeapon = rightHand.Find(weaponName);
            //오른손에 장비가 없으면 왼손 탐색
            if (oldWeapon == null)
            {
                oldWeapon = leftHand.Find(weaponName);
            }
            //왼손도 없으면 return
            if (oldWeapon == null) { return; }

            //탐색 후, 교체된 장비 Destory
            oldWeapon.name = "DESTROYING";
            Destroy(oldWeapon.gameObject);
        }

        private Transform GetTransform(Transform RightHand, Transform LeftHand)
        {
            Transform handTransform;
            if (isRightHanded) { handTransform = RightHand; }
            else { handTransform = LeftHand; }

            return handTransform;
        }

        //인스펙터에서 Projectile이 지정되어 있다면 투사체 발사, 즉 원거리 장비
        public bool HasProjectile()
        {
            //I,II는 서로 같은 의미로 동작함, 이해를 위해 II.경우로 작성
            //I. return projectile != null;
            //II. 
            if (projectile != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //투사체 발사
        public void LaunchProjectile(Transform rightHand, Transform leftHand, Health target, GameObject instigator, float calculatedDamage)
        {
            Projectile projectileInstance = Instantiate(
                projectile, //설정한 투사체
                GetTransform(rightHand, leftHand).position, //오른손, 왼손 위치
                Quaternion.identity);

            projectileInstance.SetTarget(target, instigator, calculatedDamage);
        }

        public float GetDamage()
        {
            return weaponDamage;
        }

        public float GetPercentageBonus()
        {
            return percentageBonus;
        }

        public float GetRange()
        {
            return weaponRange;
        }
    }
}