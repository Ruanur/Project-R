using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Stage
{
    public class NewStage : MonoBehaviour
    {
        //List<T>: 여러개의 오브젝트를 유동적으로 설정 가능
        [SerializeField] List<GameObject> spot;

        //TODO:
        //1. 씬 내 경비병 생존 확인 or 포탈 입장 시 씬 리로드 -> 포탈 입장 시 리로드 하는 방식으로 - 씬 리로드 과정 문제, 필드 경비병 배치 방식 변경 필요
        //1-if : 경비병이 1명이라도 생존해있다면, 포탈 입장 불가, Portal.cs 수정 - 완
        //2. 현재 플레이어 레벨에 맞게 경비병 재 소환
        //일단 이렇게 구현 진행

        //테스트용 함수, 경비병 생존 수 확인 
        //void Update()
        //{
        //    if (Input.GetKeyDown(KeyCode.C))
        //    {
        //        StageSet();
        //    }
        //}
        
        public void StageSet()
        {
            Spot[] spots = FindObjectsOfType<Spot>();
            Debug.Log("남은 경비명 인원: " + CountEnemy());

            foreach (Spot spot in spots)
            {
                spot.SpawnGuard();
            }

        }

        public bool CheckEnemy()
        {
            if (CountEnemy() > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //경비병 수 확인
        public int CountEnemy()
        {
            GameObject[] ememies = GameObject.FindGameObjectsWithTag("Enemy");
            int enemyCount = ememies.Length;

            return enemyCount;
        }
    }
}
