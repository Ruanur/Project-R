using UnityEngine;

namespace RPG.Stats
{
    public class BaseStats : MonoBehaviour
    {
        [Range(1,99)]
        [SerializeField] int startinglevel = 1;
        [SerializeField] CharacterClass CharacterClass;
        [SerializeField] Progression progression = null;

        void Update()
        {

        }
    }
}
