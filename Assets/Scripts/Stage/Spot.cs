﻿using RPG.Stats;
using RPG.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Stage
{
    public class Spot : MonoBehaviour
    {
        [SerializeField] GameObject Guard = null;
        //플레이어의 스탯 정보를 가져오기 위함
        const float spotPointRadius = 0.3f;

        BaseStats PlayerStats;
        void Awake()
        {
            PlayerStats = GameObject.FindWithTag("Player").GetComponent<BaseStats>();
        }

        private void Start()
        {
            SpawnGuard();
        }

        //Spot 위치 표시
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(transform.position, spotPointRadius);
        }


        //경비병 스폰 테스트, NewStage에서 호출 시 스폰되게 함수 변경 필요
        public void SpawnGuard()
        {
            //PlayerLevelGuard();
            //Debug.Log("실행됨");
            //플레이어의 현재 레벨 가져오기
            int playerLevel = PlayerStats.GetLevel();

            GameObject guardInstance = Instantiate(Guard, transform.position, Quaternion.identity);
            BaseStats guardStats = guardInstance.GetComponent<BaseStats>();

            if (guardStats != null && Guard != null)
            {
                guardStats.SetLevel(playerLevel);
            }
            
        }
    }
}
