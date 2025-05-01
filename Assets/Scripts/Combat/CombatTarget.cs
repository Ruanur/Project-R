using RPG.Attributes;
using RPG.Control;
using UnityEngine;

namespace RPG.Combat
{
    //오브젝트에 CombatTarget.cs 추가 시 Health.cs 자동 추가
    [RequireComponent(typeof(Health))]
    public class CombatTarget : MonoBehaviour, IRaycastable
    {
        public bool HandleRaycast(PlayerController callingController)
        {
            if (!callingController.GetComponent<Fighter>().CanAttack(gameObject))
            {
                return false;
            }

            if (Input.GetMouseButton(1))
            {
                callingController.GetComponent<Fighter>().Attack(gameObject);
            }

            //대상 위로 커서 올릴 때 Combat 커서 변환
            return true;
        }
    }
}