using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

namespace RPG.Control
{
    public class AIController : MonoBehaviour
    {
        [SerializeField] float chaseDistance = 5f;

        private void Update()
        {
            
            if (DistanceToPlayer() < chaseDistance)
            {
                if (gameObject.name == "Enemy (1)") { return; }
                print(gameObject.name + "추격");
            }
        }

        private float DistanceToPlayer()
        {
            GameObject player = GameObject.FindWithTag("Player");
            //플레이어와 대상의 거리 반환
            return Vector3.Distance(player.transform.position, transform.position);
        }
    }
}


