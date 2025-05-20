using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.Stage
{
    public class LeftDisplay : MonoBehaviour
    {
        NewStage LeftEnemy;

        private void Awake()
        {
            //Player 태그의 Basestat 가져오기
            LeftEnemy = GameObject.FindWithTag("Management").GetComponent<NewStage>();
        }

        private void Update()
        {
            //레벨 정보 갱신
            //String.Format {0:0}, 소수점 표시 제거, 소수점 첫째 자리는 {0,0.0}
            GetComponent<Text>().text = String.Format("{0:0}", LeftEnemy.CountEnemy());
        }
    }
}
