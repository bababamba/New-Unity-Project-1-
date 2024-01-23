# 1. 프로젝트 소개
이 프로젝트는 뱀파이어 서바이벌(이하 '뱀서')의 시스템을 활용해 다른 게임을 만들어보는것이 목적이다.
현재 여러 아이디어를 기획하며 뱀서의 시스템을 개발중이다.
디자이너가 합류할 예정이고 디자이너의 그림체에 따라 귀여운 느낌의 뱀서가 될것으로 예상하고 있다.

다음과 같은 아이디어를 생각중이다.
1. 마을과 던전이 있는 RPG
2. 특정 구역(건물, NPC 오브젝트 등)을 지키는 디펜스
3. 기존 뱀서에서 보스전을 매우 강화
목표는 스토어 출시다.
# 2. 개발 환경
유니티 C#으로 개발한다.

Unity 2020.3.12f1

Visual Studio 2019

Github Desktop
# 3. 프로젝트 인원
메인 프로그래머 한태종

디자이너(예정)

# 4. 프로젝트 구조
```
├─Assets
│  ├─Asset
│  │  └─Font
│  ├─Resources
│  │  ├─Audio
│  │  │  ├─BGM
│  │  │  └─SFX
│  │  ├─ETC
│  │  └─Prefab
│  │      ├─areaDamage
│  │      ├─enemy
│  │      ├─item
│  │      ├─projectile
│  │      ├─tiles
│  │      └─UseByPassive
│  ├─Scenes
│  ├─Script
│  │  ├─Creture
│  │  ├─enemy
│  │  │  ├─Boss
│  │  │  ├─NormalEnemy
│  │  │  ├─specialEnemy
│  │  │  └─UseByEnemy
│  │  │      ├─AreaDamage
│  │  │      └─projectile
│  │  ├─item
│  │  │  ├─areaDamage
│  │  │  ├─item_object
│  │  │  ├─passive
│  │  │  ├─projectile
│  │  │  ├─synergy
│  │  │  └─Weapon
│  │  ├─Player
│  │  ├─System
│  │  │  └─Observer
│  │  └─UI
│  │      └─inventory
│  └─storeAsset
│      ├─2D Pixel Item Pack
│      ├─2D Pixel RPG Icon Pack
│      ├─2D_PFX
│      ├─GUI Kit - Dark Geo
│      ├─Pixel Monsters Vol1
│      ├─RPG_Pack
│      └─TextMesh Pro
│          ├─Documentation
│          ├─Examples & Extras
│          └─...
├─Library
├─Logs
├─obj
├─Packages
├─ProjectSettings
├─test
│  ├─CruelSurvive
│  ├─MonoBleedingEdge
│  ├─New Unity Project (1)_Data
│  └─toplay
└─UserSettings
```

# 4. 개발 기간
2023.4월 경 부터 개발을 시작하였고 8월까지의 개발 후 휴식 이후 2024 2월 재가동 
# 5. 현재 목표
뱀서 라이크 클론 게임 만들기
