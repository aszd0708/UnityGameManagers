# Finity State Machine

## FSM State
```
    public abstract void OnEnter(GameObject obj = null);

    public abstract void OnExecute(GameObject obj = null);

    public abstract void OnExit(GameObject obj = null);
```

원하는 상태를 이 함수를 상속하여 제작 합니다.

OnEnter()는 이 상태가 처음 들어갈때 한번 실행되는 함수 입니다.

OnExecute() 는 이 상태가 들어왔을때 반복문에서 실행되는 함수 입니다.

OnExit() 는 이 상태가 나갈때 한번 실행되는 함수 입니다.

## FSM Manager

### SetState
```
    private Dictionary<string, FSMState> stateMachine = new Dictionary<string, FSMState>();
    protected Dictionary<string, FSMState> StateMachine { get => stateMachine; set => stateMachine = value; }
    
    public virtual void SetStateComponent()
    {
        Debug.Log("SetStateComponent");
    }
```

이부분에 Dictionanry로 원하는 FSMState를 상속한 컴포넌트를 넣어 키값 설정 합니다.

### Update
```
    protected FSMState curState;
    protected FSMState CurState { get => curState; set => curState = value; }
public virtual void FSMUpdate()
    {
        if (curState != null)
        {
            curState.OnExecute(target.gameObject);
        }
    }
```
CurState 가 존재하면 반복문으로 실행시킵니다.

### ChangeState
```
 public void ChangeState(FSMState changeState, GameObject obj = null)
    {
        if (obj == null) obj = gameObject;

        // 현재상태랑 바꾸려는 상태가 같다면 
        if (curState == changeState) { return; }
        // 바꾸려는 상태가 없다면
        if (changeState == null) { return; }
        // 현재 상태가 없지 않다면 Exit시킴
        if (curState != null) { curState.OnExit(obj); }

        // Exit후 현재 상태를 바꾸려는 상태로 전환 후 Enter실행
        curState = changeState;
        curState.OnEnter(obj);
    }
```
현재 상태의 OnExit()를 실생시킨 뒤 상태를 바꾸고 OnEnter()를 실행 시킵니다.