using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Stage
{
    public class Spot : MonoBehaviour
    {
        [SerializeField] GameObject Guard = null;

        //경비병 스폰 테스트, NewStage에서 호출 시 스폰되게 함수 변경 필요
        void Start()
        {
            if (Guard != null)
            {
                //기존 프리팹에 설정된 가드 생성
                //플레이어 레벨과 비슷한 레벨의 경비병이 생성되도록 변경 필요
                GameObject spawnGuard = Instantiate(Guard, transform.position, Quaternion.identity);
                Debug.Log("새로운 Guard가 생성되었습니다.");
            }
        }
    }
}
