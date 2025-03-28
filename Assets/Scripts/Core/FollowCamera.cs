using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Core
{
    public class FollowCamera : MonoBehaviour
    {
        [SerializeField] Transform target;

        // Update() -> LateUpdate()
        void LateUpdate()
        {
            transform.position = target.position;
        }
    }
}
