# UnityGameManagers

## Managers

### PoolingManager
SetPool 을 사용해서 오브젝트를 SetActive(false)를 시킨 다음 SetPool에 있던 PoolingName 으로 새로운 카테고리를 만들어 넣어줌 만약 카테고리가 있을경우 그 카테고리로 넣어줌
그리고 GetPool을 사용해서 원하는 카테고리에 있는 오브젝트를 가져올 수 있음 만약 없을경우 null을 반환
사용시 받아올때 null을 받을 경우 null을 체크 한 뒤 원하는 오브젝트 생성해서 사용

### AudioManager
오디오 소스가 들어간 프리펩을 넣어서 사용 Pooling을 사용할 경우에 마지막 Destoy보단 PoolingManager를 같이 사용해 주는게 좋음

### PopupManager
팝업 창이 나올때 눌러도 괜찮은 UI와 누르면 안되는 UI를 나눠 막아둠
현재 까지의 팝업창의 갯수가 0 초과일 경우에 터치를 막아둠

### Sington
자주 사용하기 때문에 클래스를 따로 만들어 사용함 만약 싱글톤으로 사용하고 싶은 경우 상속해서 사용하며 Awake를 사용하고 싶을땐 오버라이딩 해서 사용

### ObserverPatternClass 
옵저버는 AchievementObserver를 조건 달성은 AchievementSubject을 상속해서 사용
특정한 조건에 옵저버들을 감시해야 할 사항이 생기면 AchievementSubject의 Notify()를 실행시키면 옵저버들의 조건을 검사 한 뒤 그 옵저버의 조건 달성 이벤트를 실행시켜줌

### JsonManager
제이슨을 사용하는 경우에 제이슨 에 맞는 클래스를 만든 뒤 상속해서 사용
게임이 실행될때 읽음

### SaveData
저장을 원하는 데이터가 있을 경우 새로운 클래스를 만들어서 상속하여 사용
데이터가 없으면 디폴트로 저장하고 데이터를 수정하여 저장 하는 추상 함수 사용

Item, Letter, Aniaml, Player DataManager는 위 SaveData를 상속하여 만듦

DataManager는 직접적으로 로컬 파일로 만들어 저장하는 클래스
SaveDataMager는 DataManger를 상속시켜 위에 SaveData 들을 한번에 묶어 저장, 로드, 수정 하는 클래스
