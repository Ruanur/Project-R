# Annihilation

<div align="center">
<img width="820" alt="image" src="https://github.com/user-attachments/assets/406eddb3-8d40-48f0-bc44-c2b078068f56">


</div>

# Annihilation
> **RPG Combat Tech Learning** <br/> **개발기간: 2025.03.27 ~ 2025.05.13**

## 배포 주소

> **개발 버전** : [https://naver.me/FkLGyUaC] <br>
> **빌드 버전(실행 파일)** : [https://naver.me/Fzsl51uK]<br>

## 개발팀 소개

|      민경진       |                                                                                                                 
| :------------------------------------------------------------------------------: | 
|   <img width="200px" src="https://github.com/user-attachments/assets/c186ef9f-20ea-4154-a7d5-186af7dd9dc1" />    | 
|   [@Ruanur](https://github.com/Ruanur)   | 

## 프로젝트 소개

Annihilation은 플레이어가 마을을 침략해 모든 경비병들을 처치하고
다양한 아이템을 약탈해 마을을 점령하는 게임입니다.

계속해서 강해지는 경비병들을 처치하고 더 좋은 아이템들을 계속해서 획득해
플레이어를 성장하는 것을 목표로 합니다.

<img width="780" alt="image" src="https://github.com/user-attachments/assets/8945b432-69e2-46ad-aeb9-2a0907b260e2">

## 시작 가이드
### Requirements
For building and running the application you need:

- [Unity Editor](https://public-cdn.cloud.unity3d.com/hub/prod/UnityHubSetup.exe)
- [Unity 2018.3.14f1](https://unity.com/kr/releases/editor/archive)

### Installation
``` bash
$ git clone https://github.com/Ruanur/Project-R.git
$ cd Annihilation
```

---

## Stacks 🐈

### Environment
![Visual Studio 2022](https://img.shields.io/badge/Visual%20Studio%202022-007ACC?style=for-the-badge&logo=Visual%20Studio%20Code&logoColor=white)
![Github Desktop](https://img.shields.io/badge/Github%20Desktop-C363F7?style=for-the-badge&logo=GitHub&logoColor=purple)
![Github](https://img.shields.io/badge/GitHub-181717?style=for-the-badge&logo=GitHub&logoColor=white)             
      
### Development
![C#](https://img.shields.io/badge/C%20Sharp-512BD4?style=flat-square&logo=sharp&logoColor=white)
![Unity](https://img.shields.io/badge/Unity-E6E6FA?style=for-the-badge&logo=unity&logoColor=black)

---
## 인게임 구성 📺
| 메인 화면  |   주방 스테이지   |
| :-------------------------------------------: | :------------: |
|  <img width="329" src="https://github.com/user-attachments/assets/20b18985-f96d-430f-a04a-a7ff7b836e30"/> |  <img width="329" src="https://github.com/user-attachments/assets/e6c948cc-3bb9-4932-9b78-6d44e7bdc514"/>|  
| 손질 재료 - 양상추, 토마토, 치즈 |  조리 재료 - 패티  |  
| <img width="329" src="https://github.com/user-attachments/assets/0abc507f-280d-4de6-8a5e-ab839950f89c"/>   |  <img width="329" src="https://github.com/user-attachments/assets/b8dad125-c262-4cc2-9a85-28dcc6473b4d"/>     |
| 서빙 성공   |  서빙 실패   |  
| <img width="329" src="https://github.com/user-attachments/assets/21c91b96-898c-4a9e-8a72-767a1ad5bb64"/>   |  <img width="329" src="https://github.com/user-attachments/assets/b2a089f0-a513-47ea-bbdc-28cf8bc540d8"/>     |
| 멀티플레이 화면   |  캐릭터 선택 화면   |  
| <img width="329" src="https://github.com/user-attachments/assets/34d16b2e-db3e-4e20-82a4-66ae7fd45e5f"/>   |  <img width="329" src="https://github.com/user-attachments/assets/7200d5b0-461d-4aaf-9b22-ea5a8134ecf3"/>     |
| 시간 초과, 게임 오버 |
| <img width="329" src="https://github.com/user-attachments/assets/2516a3fa-e854-42e5-a422-8f56fed32dc0"/>   
---
## 게임 내 구조 ➶

<img width="329" src="https://github.com/user-attachments/assets/0f29abad-dd0b-4e44-8b24-5be7f0791737"/>

- 게임의 전체적인 구조는 다음과 같습니다.
- 멀티플레이 씬과 싱글플레이 씬이 있으며, 내부의 UI를 통해 각 씬의 상태에 따라 게임이 진행됩니다.

---

## 주요 기능 📦

### ⭐️ 각기 다른 재료, 각기 다른 조리 방법
- 재료는 총 5개로 구성되어 있으며(번, 패티, 양상추, 토마토, 치즈) 이들은 각각 다른 상호작용을 필요로 합니다.
- 재료를 플레이팅 하기 위한 상호작용은 두 가지가 있으며, 이는 손질 / 가열로 나뉩니다.
- 양상추, 토마토, 치즈 - 손질 / 패티 - 가열
- 패티는 너무 오래 가열하면 타버려 사용하지 못합니다.

### ⭐️ 제한 시간 초과 시 서빙을 완료한 음식 명시
- 게임이 종료될 때, 시간 내에 서빙을 얼마나 수행하였는지 명시해줍니다. 

### ⭐️ 멀티플레이 지원
- 유니티에서 제공하는 멀티플레이어 게임용 서비스 Relay를 사용하였습니다.
- 이를 이용해 전용 게임 서버(DGS)를 구축하지 않고도 간편하고 안전한 P2P 통신을 통해 플레이어끼리 연결이 가능하게 하였습니다.
- 멀티플레이 선택 시 로비를 생성하는 씬이 나타나며, 플레이어의 닉네임, 캐릭터 선택 후 게임이 시작됩니다.
- 하나의 로비에 최대 4명까지 입장 가능합니다.

---

