# Annihilation

<div align="center">
<img width="820" alt="image" src="https://github.com/user-attachments/assets/406eddb3-8d40-48f0-bc44-c2b078068f56">


</div>

# Annihilation
> **RPG Combat Tech Learning** <br/> **개발기간: 2025.03.27 ~ 2025.05.13**

## 배포 주소

> **개발 버전** : [https://drive.google.com/file/d/1D_GbSKcQaN_yaxmNzFn1xBOc3ELkj9JS/view?usp=drive_link] <br>
> **빌드 버전(실행 파일)** : [https://drive.google.com/file/d/1IRjGUxZFyUT1hTcm607eAw2_pQUankKu/view?usp=drive_link]<br>

## 개발팀 소개

|      민경진       |                                                                                                                 
| :------------------------------------------------------------------------------: | 
|   <img width="200px" src="https://github.com/user-attachments/assets/0cb4b61a-0a01-4629-9147-fb8cd0c96285"/>    | 
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

### ⭐️ 전투 시스템 구현
- 플레이어와 적의 전투가 가능하도록 근거리/원거리 공격 구조를 구현하였습니다.
- 무기 장착 및 전투 대상 판정, 피해 처리, 사망 처리 등 기본적인 전투 흐름을 구성했습니다.
- RPG 전투 시스템의 기본 구조를 학습하는 데 초점을 두고 구현하였습니다.

### ⭐️ 스탯 성장 및 캐릭터 강화
- 플레이어의 능력치와 성장 요소를 반영해 전투 성능이 점진적으로 향상되도록 구성했습니다.
- 전투와 보상 획득을 통해 캐릭터가 성장하는 RPG의 핵심 루프를 구현하였습니다.

### ⭐️ 저장/불러오기 시스템
- 플레이 진행 상태를 저장하고 다시 불러올 수 있도록 Save/Load 기능을 구현하였습니다.
- 장비, 캐릭터 상태, 진행 정보 등이 유지되도록 구성해 RPG의 지속적인 플레이 흐름을 지원했습니다.

### ⭐️ 포탈 기반 씬 이동
- 특정 지역 간 이동이 가능하도록 포탈 시스템을 구현하였습니다.
- 씬 전환 과정에서 플레이 흐름이 자연스럽게 이어지도록 구성하였습니다.

### ⭐️ 저장/불러오기 시스템
- 단순이 게임을 완성하는 것보다, RPG에서 반복적으로 사용되는 핵심 시스템을 직접 구현하고 구조를 이해하는 데에 목적을 두었습니다.
- 전투, 성장, 저장, 씬 이동 등 다양한 시스템을 직접 연결하며 RPG 개발 흐름을 학습했습니다.

---

