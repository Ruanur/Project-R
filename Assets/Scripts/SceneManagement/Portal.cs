using RPG.Control;
using RPG.Stage;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

namespace RPG.SceneManagement
{
    public class Portal : MonoBehaviour
    {
        enum DestinationIdentifer
        {
            A, B, C, D, E
        }


        [SerializeField] int sceneToLoad = -1;
        [SerializeField] Transform spawnPoint;
        [SerializeField] DestinationIdentifer destination;
        [SerializeField] float fadeOutTime = 1f;
        [SerializeField] float fadeInTime = 2f;
        [SerializeField] float fadeWaitTime = 0.5f;
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                StartCoroutine(Transition());
            }
        }

        private IEnumerator Transition()
        {
            NewStage newStage = FindObjectOfType<NewStage>();
            if (sceneToLoad < 0)
            {
                Debug.LogError("씬이 설정되지 않음");
                yield break;
            }
            //씬 불러오기, LoadScene(String)의 경우 씬 이름을 바꿀 때 코드도 같이 바꿔야 하는 번거로움이 있어
            //LoadScene(Index) 사용, Build Setting 설정으로 들어가 씬 인덱스 번호 확인 가능
            else if (!newStage.CheckEnemy()) //1번 Scene에 StageManager 오브젝트 생성 후 스크립트 삽입
            {
                Debug.Log("아직 경비명이 생존중");
                yield break;
            }
            
            //씬 로드 전
            DontDestroyOnLoad(gameObject);

            Fader fader = FindObjectOfType<Fader>();

            //현재 레벨 저장
            SavingWrapper wrapper = FindObjectOfType<SavingWrapper>();
            PlayerController playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
            playerController.enabled = false;

            yield return fader.FadeOut(fadeOutTime);

            wrapper.Save();

            yield return SceneManager.LoadSceneAsync(sceneToLoad);
            PlayerController newPlayerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
            newPlayerController.enabled = false;
            //현재 레벨 불러오기
            wrapper.Load();

            //씬 로드 후
            Portal otherPortal = GetOtherPortal();
            UpdatePlayer(otherPortal);

            wrapper.Save();

            yield return new WaitForSeconds(fadeWaitTime);
            fader.FadeIn(fadeInTime);

            newPlayerController.enabled = true;
            Destroy(gameObject);

            Debug.Log("포탈 입장함");
            //이 라인부터 NewStage 추가, 
            //TODO: 경비병이 남아있으면 포탈 입장 불가 : 구현 완료
            //포탈 입장 시 플레이어의 레벨에 맞는 경비병 재 소환
            newStage.StageSet();

        }

        private void UpdatePlayer(Portal otherPortal)
        {
            GameObject player = GameObject.FindWithTag("Player");
            player.GetComponent<NavMeshAgent>().enabled = false;
            player.GetComponent<NavMeshAgent>().Warp(otherPortal.spawnPoint.position);
            player.transform.rotation = otherPortal.spawnPoint.rotation;
            player.GetComponent<NavMeshAgent>().enabled = true;
        }

        private Portal GetOtherPortal()
        {
            foreach (Portal portal in FindObjectsOfType<Portal>())
            {
                if (portal == this) continue;
                if (portal.destination != destination) continue;

                return portal;
            }

            return null;
        }
    }
}