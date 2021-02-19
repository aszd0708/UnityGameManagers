using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * 2020-06-02
 * 팝업을 컨트롤 해주는 클래스
 * 나오게 하거나 없어지게 해주고
 * 팝업이 나오는 타이밍에 따라서 터치를 제한해주는 기능이 있음
 * 
 * 고양이 게임
 * 고양이 게임에는 게임중 게임중 아님이라는 선택지가 없기 때문에 약간의 수정을 함
 * 하... 그런데 이거 ㄹㅇ 답없이 짰었네...
 */

/// <summary>
/// 팝업 매니져
/// 메인 메뉴에서는 상태값으로 처리함
/// </summary>
public class PopupManager : Singleton<PopupManager>
{
    [Header("메뉴에서 나오는 팝업 카운트")]
    private int popupCount = 0;

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

    [Header("메뉴 팝업 나올때 터치 못해야 하는 버튼")]
    public Button[] popupNotBtn;

    [Header("메뉴 팝업 나올때 터치 못해야 하는 패널들")]
    public GameObject[] popupNotPanel;

    [Header("팝업들")]
    public RectTransform[] popups;

    [Header("팝업 나오는 시간")]
    public float popupTime;

    public enum SceneKind
    {
        STAGE, MAIN, GATCHA
    }

    [Header("지금 이 씬이 어떤 씬인지")]
    public SceneKind nowSceneKind;

    
    [Header("터치 못하게 하기 위한 터치 매니져 (스테이지에 필요)")]
    public StageTouchManagerBase stageTouchManager;

    private Vector3 popup01, popup10, popup11, popup00;
    private WaitForSeconds wait;

    private void OnEnable()
    {
        popup01 = new Vector3(1, 1);
        popup10 = new Vector3(1, 0.025f);
        popup11 = new Vector3(1, 1);
        wait = new WaitForSeconds(popupTime);

        for (int i = 0; i < popups.Length; i++)
        {
            popups[i].localScale = Vector3.zero;
            popups[i].gameObject.SetActive(false);
        }
    }

    public void OpenPopup(ref RectTransform popup)
    {
        StartCoroutine(OpenPopupAnimation(popup));
        PopupCount++;
    }

    public void ClosedPopup(ref RectTransform popup)
    {
        StartCoroutine(ClosePopupAnimation(popup));
        PopupCount--;
    }

    public void OpenPopup(RectTransform popup)
    {
        StartCoroutine(OpenPopupAnimation(popup));
        PopupCount++;
    }

    public void ClosedPopup(RectTransform popup)
    {
        StartCoroutine(ClosePopupAnimation(popup));
        PopupCount--;
    }

    private IEnumerator OpenPopupAnimation(RectTransform popup)
    {
        popup.gameObject.SetActive(true);
        popup.DOScale(popup01, popupTime).SetEase(Ease.InOutQuint);
        yield return wait;
        yield break;
    }

    private IEnumerator ClosePopupAnimation(RectTransform popup)
    {
        popup.DOScale(Vector3.zero, popupTime).SetEase(Ease.InOutQuint);
        yield return wait;
        popup.gameObject.SetActive(false);
        yield break;
    }
}