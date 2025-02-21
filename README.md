![Typing SVG](https://readme-typing-svg.demolab.com?font=Fira+Code&size=50&pause=1000&width=635&height=100&lines=MINI+METAVERSE)
---

# Description
 - **프로젝트 소개** <br>
   다양한 미니 게임을 즐길 수 있는 미니 메타버스 프로젝트입니다. <br>
   NPC 대화 시스템, 상점, 인벤토리 시스템, 스코어 보드, 아이템 시스템 등을 구현했습니다.<br>
   유지보수와 확장이 용이한 형태로 설계하는 것을 목표로 개발했습니다.<br><br>
 - **개발 기간** : 2025.02.14 - 2025.02.20
<br><br>

---
# 핵심 기능
- The Stack (탑 쌓기 게임)
- 무한의 계단
- NPC 대화 시스템
- 상점 시스템
- 인벤토리 시스템
- 스코어 시스템
- 치장 아이템, 탈것 아이템
<br><br>

---
# 기능 소개
## 🕹️미니게임1 - The Stack
<img src="https://github.com/user-attachments/assets/93ca7097-6169-40ea-9e04-8aee7274cf5f" width="300"> <br>

## 🕹️미니게임2 - 무한의 계단
<img src="https://github.com/user-attachments/assets/fff24eb6-2aad-486a-b341-1109b0975a9b" width="300"> <br>
- 자료구조 Queue를 이용하여 구현하였습니다. 
- 블록을 Queue에 넣었고, 다음 블록으로 가게 되면 Queue에서 블록을 뽑아서<br>
  새롭게 위치를 지정해주고 다시 Queue에 넣어주는 것을 반복되도록 하였습니다.
- 플레이어가 다음 위치로 이동한 후에, 현재 블록과 위치를 비교하여 게임 오버 처리 되도록 하였습니다.

## 📗스코어 시스템
![image](https://github.com/user-attachments/assets/b6060060-6572-46aa-98d5-efaea99b3d5f) <br>
![image](https://github.com/user-attachments/assets/f3fc508d-1163-47cb-ad91-14a5710235db) <br>
- Scriptable Object를 사용해서 점수 시스템을 구현했습니다.
- 미니게임을 실행하면, 해당 미니게임의 Score 데이터를 DataManager에 등록하여 사용되도록 했습니다. 

## 🎮게임 종료
<img src="https://github.com/user-attachments/assets/6b6ec968-4695-4c66-a1a3-bf5c529c5476" width="300"> <br>
- 미니게임을 만들 때 마다 종료 Scene을 만드는 것이 아니라 공통적으로 사용할 수 있도록 설계했습니다.
- DataManager에 현재 진행중인 게임의 정보 데이터를 넣어두고, 게임 종료 씬에서 활용 할 수 있도록 했습니다.
- 메타버스로 돌아오면 DataManager에 입력된 게임 결과가 출력되도록 하였습니다.

## 🤝상호작용 시스템
<img src="https://github.com/user-attachments/assets/c6d2f68c-fd89-42f3-8a95-77b0bb823cc5" width="300"> <br>
- 상호작용이 가능한 오브젝트에 가까이 가면 버튼이 생성되게 하였으며, 해당 버튼을 클릭하면 UI가 호출되도록 만들었습니다.
- 또한 스코어 보드를 구현 하였는데, 미니게임 데이터를 저장하는 Scriptable Object를 스코어보드에서 읽어드려서 사용하도록 구현했습니다.

<img src="https://github.com/user-attachments/assets/5e851907-db7a-4938-825e-339c6f991330" width="300"> <br>
- 상호작용을 통해 던전에 입장할 수 있도록 했습니다.

## 🎒인벤토리 시스템
<img src="https://github.com/user-attachments/assets/df4ae527-d289-4251-bc33-e390b359277b" width="300"> <br>
![image](https://github.com/user-attachments/assets/14e35d5f-17ca-47cd-a018-a2d67ae07fa7) <br>
- Scriptable Object를 통해 인벤토리 데이터를 저장하였고, 해당 데이터를 읽어드려 인벤토리를 구성하도록 설계했습니다.
- 인벤토리에서 아이템을 선택하여 장착하고, 자동차를 탈 수 있게 만들었습니다.
- 아이템 장착은 아이템을 플레이어 오브젝트의 하위 객체로 옮겨주는 것으로 해결했습니다.

## 🏪상점 시스템
![image](https://github.com/user-attachments/assets/76034a60-8667-4280-a3c6-4fe6b3a2ea50) <br>
![image](https://github.com/user-attachments/assets/01c354c6-0b06-4c35-af34-1639882f23f3)
- Data Manager에 저장된 아이템 정보를 불러와서 아이템 목록을 출력합니다.
- 아이템 목록에 prefab으로 만든 버튼을 생성하며, 해당 버튼을 클릭할 때, 함숫가 호출되도록 Event에 람다를 넣어주었습니
  
##
  ![image](https://github.com/user-attachments/assets/6460ac68-c33b-46d1-975f-d25cbc1ab88f) <br>
![image](https://github.com/user-attachments/assets/a46d8a9c-2d2e-49ab-8599-7721ee24e30c) <br>
![image](https://github.com/user-attachments/assets/f78fc59c-98e7-484f-a473-cf8b87e55d73) <br>
- 아이템을 클릭하게 되면 아이템이 구매되도록 하였습니다.

## 💬대화 시스템
<img src="https://github.com/user-attachments/assets/aa97ed9e-cdba-46f6-8384-1ecc5e02510d" width="300"> <br>
![image](https://github.com/user-attachments/assets/d3566c27-30e8-4dec-8b58-e35fd4d8a067)
- Scriptable Object를 활용하여 대화 시스템을 구현하였습니다.
- 플레이어의 선택지에 다른 대화 데이터를 넣어서 계층 구조로 관리 되도록 만들었습니다.

![image](https://github.com/user-attachments/assets/6615ea28-effb-4bb4-9c66-1993026d6d34)

## 🏃🏼플레이어 이동 로직
![이동](https://github.com/user-attachments/assets/5661f9ef-c7b8-43d4-97a1-df6ad71fecab)
- 마우스로 클릭한 위치를 기준으로 마우스가 이동한 방향으로 캐릭터가 이동되도록 만들었습니다.
- 조이스틱 UI를 추가하여 기준점을 확인할 수 있게 했습니다.
  
![image](https://github.com/user-attachments/assets/c294e5e7-1b2c-4d21-bae6-2d65c15dbd1a)
- InputSystem을 활용하여 이동 로직을 구현했습니다.
  
![image](https://github.com/user-attachments/assets/5a430265-692e-4ef3-8d1b-1b69edf28135)
- 입력값이 모든 Scene에서 사용되는건 아니기에 Scene이 종료될 때 호출되는 OnDestory에서 함수의 연결을 해제해주었습니다.

![image](https://github.com/user-attachments/assets/966e1307-e293-4952-819e-3a09c5debf58)
- 조이스틱 UI는 클릭할 때, 클릭을 땔 때, 마우스를 움직일 때 함수가 호출되도록 하였으며 <br>
  플레이어 class와 의존성을 높이는 방식 보다는 따로 설계를 하는 것이 유지보수 측면에서 더 좋다고 판단하여 <br>
  같은 Input System만 사용하고 완전히 따로 작동되도록 만들었습니다. 
  
## 🎥카메라 시스템
<img src="https://github.com/user-attachments/assets/444ad02e-93db-47c8-bc6f-e9f5c1bbf235" width="300"> <br>
- 유니티의 virtual Camera 기능을 이용하여 플레이어 객체를 따라다니도록 만들었습니다.
- Cinemachine Confiner을 이용하여 카메라가 특정 범위만 촬영할 수 있도록 설계했습니다.

# 감사합니다!
