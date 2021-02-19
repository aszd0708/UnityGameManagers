using BitBenderGames;

/*
 * 2020-03-03
 * 메뉴 켜지면 터치 못하고 이동 못하게 해주는 스크립트
 * 싱글톤을 사용해서 작성함
 * 메뉴나 터치를 막아야 할 때 SetState(bool)를 사용해서 카운트
 * 만약 true를 넣을시 Count++;
 * 만약 false를 넣을시 Count--;
 * 프리퍼런스에서 한개씩 다 골라서 만들어줌
 * 
 * 
 * 아마 이 클래스는 안쓸거 같음 새로 PopupManager를 만들어서 사용함
 */

public class MenuManager : Singleton<MenuManager>
{
    private int menuCount = 0;
    private bool showPopup;
    public bool ShowPopup
    {
        get => showPopup;
        set
        {
            showPopup = value;
        }
    }

    public int MenuCount
    {
        get => menuCount;
        set
        {
            if (value <= 0) menuCount = 0;
            else menuCount = value;
        }
    }

    public void SetState(bool show)
    {
        if (show) MenuCount++;
        else MenuCount--;

        if (MenuCount <= 0) ShowPopup = false;
        else ShowPopup = true;
    }

    public void ResetState()
    {
        MenuCount = 0;
        ShowPopup = false;
    }
}
