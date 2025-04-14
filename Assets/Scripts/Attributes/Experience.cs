using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Attribute
{
    public class Experience : MonoBehaviour
    {
        [SerializeField] float experiencePoints = 0f;

        public void GainExperience(float experience)
        {
            experiencePoints += experience;
        }

        void Update()
        {

        }
    }

}