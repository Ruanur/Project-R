using RPG.Core;
using UnityEngine;

namespace RPG.Combat
{
    //오브젝트에 CombatTarget.cs 추가 시 Health.cs 자동 추가
    [RequireComponent(typeof(Health))]
    public class CombatTarget : MonoBehaviour
    {

    }
}