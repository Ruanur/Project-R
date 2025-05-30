﻿using System;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.Stats
{
    public class LevelDisplay : MonoBehaviour
    {
        BaseStats basestats;
        
        private void Awake()
        {
            //Player 태그의 Basestat 가져오기
            basestats = GameObject.FindWithTag("Player").GetComponent<BaseStats>();
        }

        private void Update()
        {
            //레벨 정보 갱신
            //String.Format {0:0}, 소수점 표시 제거, 소수점 첫째 자리는 {0,0.0}
            GetComponent<Text>().text = String.Format("{0:0}", basestats.GetLevel());
        }
    }
}
