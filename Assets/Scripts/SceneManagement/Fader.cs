using System.Collections;
using UnityEngine;

namespace RPG.SceneManagement
{
    public class Fader : MonoBehaviour
    {
        CanvasGroup canvasGroup;

        private void Start()
        {
            canvasGroup = GetComponent<CanvasGroup>();

            StartCoroutine(FadeOutIn());
        }

        IEnumerator FadeOutIn()
        {
            yield return FadeOut(3f);
            Debug.Log("페이드 아웃");
            yield return FadeIn(1f);
            Debug.Log("페이드 인");
        }

        public IEnumerator FadeOut(float time)
        {
            while (canvasGroup.alpha < 1) // Alpha != 1
            {
                canvasGroup.alpha += Time.deltaTime / time;
                yield return null;
            }
        }

        public IEnumerator FadeIn(float time)
        {
            while (canvasGroup.alpha > 0) // Alpha != 1
            {
                canvasGroup.alpha -= Time.deltaTime / time;
                yield return null;
            }
        }
    }

}