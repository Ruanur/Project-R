using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Core
{
    public class CameraFacing : MonoBehaviour
    {

        // Update -> LateUpdate, 체력바 어긋남 개선
        void LateUpdate()
        {
            //Text가 카메라 기준으로 바라보게 
            transform.forward = Camera.main.transform.forward;
        }
    }
}
