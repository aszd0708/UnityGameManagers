### PoolingManager

팝업 창이 나올때 눌러도 괜찮은 UI와 누르면 안되는 UI를 나눠 터치를 막습니다. 

현재 까지의 팝업창의 갯수가 0 초과일 경우에 UI터치를 막습니다.

```
 public int PopupCount
    {
        get => popupCount;
        set
        {
            popupCount = value;

            if (PopupCount < 0)
                PopupCount = 0;

            if (PopupCount > 0)
            {
                for (int i = 0; i < popupNotPanel.Length; i++)
                    popupNotPanel[i].SetActive(false);

                for (int i = 0; i < popupNotBtn.Length; i++)
                    popupNotBtn[i].enabled = false;

                switch(nowSceneKind)
                {
                    case SceneKind.STAGE:
                        stageTouchManager.CanTouch = false;
                        break;
                    case SceneKind.MAIN:

                        break;
                    case SceneKind.GATCHA:
                        break;
                    default: break;
                }
            }
            else
            {
                for (int i = 0; i < popupNotPanel.Length; i++)
                    popupNotPanel[i].SetActive(true);

                for (int i = 0; i < popupNotBtn.Length; i++)
                    popupNotBtn[i].enabled = true;

                switch (nowSceneKind)
                {
                    case SceneKind.STAGE:
                        stageTouchManager.CanTouch = true;
                        break;
                    case SceneKind.MAIN:
                        break;
                    case SceneKind.GATCHA:
                        break;
                    default: break;
                }
            }
        }
    }
```
팝업 카운트를 하나씩 늘려가면서 0이 아닐경우 터치를 제한합니다.
