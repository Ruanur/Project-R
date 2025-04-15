using System;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.Stats
{
    public class LevelDisplay : MonoBehaviour
    {
        BaseStats baseStats;
        
        private void Awake()
        {
            baseStats = GameObject.FindWithTag("Player").GetComponent<BaseStats>();
        }

        private void Update()
        {
            //체력 디버그 텍스트 갱신
            //String.Format {0:0}, 소수점 표시 제거, 소수점 첫째 자리는 {0,0.0}
            GetComponent<Text>().text = String.Format("{0:0}", baseStats.GetLevel());
        }
    }
}
