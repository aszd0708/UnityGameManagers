# UnityGameManagers

대부분 파일 안에 주석으로 함수 설명 되어 있습니다.
간단한 사용법이 있습니다.

## Managers

이름을 누르면 설명이 나옵니다.

### [PoolingManager](ManagersMarkDown/PoolingManager.md)

### [AudioManager](ManagersMarkDown/AudioManager.md)

### [PopupManager](ManagersMarkDown/PopupManager.md)

### [ObserverPatternClass](ManagersMarkDown/ObserverPatternClass.md)

### [SaveData](ManagersMarkDown/SaveDataManger.md)

### Singleton
씬마다 무조건 1개 있어야 하며, 2개 이상 있을경우가 없고 자원을 공유 해야 하는 컴포넌트에서만 사용 부탁 드립니다.

만약 호출 빈도가 적거나 위에 원칙에 해당이 안되는 경우라면, 사용하지 않는 것이 더 좋습니다.

이 문서에는 PoolingManager, AudioManager, PopupManager, SaveData 정도에 사용했습니다.

위 4개의 컴포넌트는 자원을 공유해야 하는 컴포넌트 이기 때문에 사용했습니다.

### JsonManager

제이슨을 사용하는 경우에 제이슨 에 맞는 클래스를 제작 후 상속해서 사용 합니다.

Awake()에서 실행되며,

Awake()가 실행될 때 이 컴포넌트를 사용하는 경우가 있을 경우 유니티 엔진 내에서 스크립트 실행 순서를 바꿔줘야 에러 없이 실행

