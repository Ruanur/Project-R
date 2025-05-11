using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Combat
{
    public class Weapon : MonoBehaviour
    {
        public void OnHit()
        {
            print("장착중인 무기 : " + gameObject.name);
        }
    }
}
