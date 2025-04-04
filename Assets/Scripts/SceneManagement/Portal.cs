using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RPG.SceneManagement
{
    public class Portal : MonoBehaviour
    {
        [SerializeField] int sceneToLoad = -1;
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                StartCoroutine(Transition());
            }
        }

        private IEnumerator Transition()
        {
            //씬 불러오기, LoadScene(String)의 경우 씬 이름을 바꿀 때 코드도 같이 바꿔야 하는 번거로움이 있어
            //LoadScene(Index) 사용, Build Setting 설정으로 들어가 씬 인덱스 번호 확인 가능
            SceneManager.LoadScene(sceneToLoad);

            //씬 로드 전
            DontDestroyOnLoad(gameObject);
            yield return SceneManager.LoadSceneAsync(sceneToLoad);

            //씬 로드 후
            print("Scene Loaded");
            Destroy(gameObject);
        }
    }
}