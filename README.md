![Typing SVG](https://readme-typing-svg.demolab.com?font=Fira+Code&size=50&pause=1000&width=635&height=100&lines=MINI+METAVERSE)
---

# Description
 - **프로젝트 소개** <br>
   다양한 미니 게임을 즐길 수 있는 미니 메타버스 게임을 만들었습니다. <br>
   NPC 대화 시스템, 상점, 인벤토리 시스템, 스코어 보드, 아이템 시스템을 구현했습니다.<br><br>
 - **개발 기간** : 2025.02.15 - 2025.02.20
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
## 미니게임1 - The Stack
<img src="https://github.com/user-attachments/assets/93ca7097-6169-40ea-9e04-8aee7274cf5f" width="300"> <br>

## 미니게임2 - 무한의 계단
<img src="https://github.com/user-attachments/assets/fff24eb6-2aad-486a-b341-1109b0975a9b" width="300"> <br>
- 자료구조 Queue를 이용하여 구현하였습니다. 
- 블록을 Queue에 넣었고, 다음 블록으로 가게 되면 Queue에서 블록을 뽑아서<br>
  새롭게 위치를 지정해주고 다시 Queue에 넣어주는 것을 반복되도록 하였습니다.
- 플레이어가 다음 위치로 이동한 후에, 현재 블록과 위치를 비교하여 게임 오버 처리 되도록 하였습니다.


## 스코어 시스템
![image](https://github.com/user-attachments/assets/b6060060-6572-46aa-98d5-efaea99b3d5f) <br>
![image](https://github.com/user-attachments/assets/f3fc508d-1163-47cb-ad91-14a5710235db) <br>
- Scriptable Object를 사용해서 점수 시스템을 구현했습니다.
- 미니게임을 실행하면, 해당 미니게임의 Score 데이터를 DataManager에 등록하여 사용되도록 했습니다. 


## 게임 종료
<img src="https://github.com/user-attachments/assets/6b6ec968-4695-4c66-a1a3-bf5c529c5476" width="300"> <br>
![image](https://github.com/user-attachments/assets/5acd0b6f-1c33-4347-b11e-15c3d7f146e8)<br>
- DataManager에 저장된 게임의 결과 데이터를 읽어드리며, 결과가 비어있을 때는 UI가 호출되지 않도록 했습니다.

## 인벤토리 시스템
<img src="https://github.com/user-attachments/assets/df4ae527-d289-4251-bc33-e390b359277b" width="300"> <br>
![image](https://github.com/user-attachments/assets/14e35d5f-17ca-47cd-a018-a2d67ae07fa7) <br>
- Scriptable Object를 통해 인벤토리 데이터를 저장하였고, 해당 데이터를 읽어드려 인벤토리를 구성하도록 설계했습니다.
- 인벤토리에서 아이템을 선택하여 장착하고, 자동차를 탈 수 있게 만들었습니다.

## 상점 시스템

![image](https://github.com/user-attachments/assets/76034a60-8667-4280-a3c6-4fe6b3a2ea50) <br>
- Data Manager에 저장된 아이템 정보를 불러와서 아이템 목록을 출력합니다.
- 아이템 목록에 prefab으로 만든 버튼을 생성하며, 해당 버튼을 클릭할 때, 함숫가 호출되도록 Event에 람다를 넣어주었습니
  
##
  ![image](https://github.com/user-attachments/assets/6460ac68-c33b-46d1-975f-d25cbc1ab88f) <br>
![image](https://github.com/user-attachments/assets/a46d8a9c-2d2e-49ab-8599-7721ee24e30c) <br>
![image](https://github.com/user-attachments/assets/f78fc59c-98e7-484f-a473-cf8b87e55d73) <br>
- 아이템을 클릭하게 되면 아이템이 구매되도록 하였습니다.


  
