using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMStateManager : MonoBehaviour
{
    // 유한 상태 기계(Flying Spaghetti Monster)로 적을 작성
    // 나중에 원하는 적이 다양할 경우 좀만 수정해서 사용 가능함
    protected FSMState curState;

    private Dictionary<string, FSMState> stateMachine = new Dictionary<string, FSMState>();
    protected Dictionary<string, FSMState> StateMachine { get => stateMachine; set => stateMachine = value; }

    protected FSMState CurState { get => curState; set => curState = value; }

    protected Transform target;

    /// <summary>
    /// 스테이트 컴포넌트 설정
    /// </summary>
    public virtual void SetStateComponent()
    {
        Debug.Log("SetStateComponent");
    }

    private void Awake()
    {
        SetStateComponent();
    }

    /// <summary>
    /// FSM OnEnable 됐을 시 실행
    /// </summary>
    public virtual void FSMOnEnable()
    {
        Debug.Log("FSM OnEnable");
    }

    private void Start()
    {
        FSMStartState();
    }

    /// <summary>
    /// FSM 처음 스테이트값 넣는 함수
    /// </summary>
    public virtual void FSMStartState()
    {
        Debug.Log("처음 FSM State");
    }

    private void Update()
    {
        FSMUpdate();
    }

    /// <summary>
    /// FSM 업데이트문 
    /// 스테이트가 null이 아니라면 반복으로 사용
    /// 이 업데이트 문은 무조건 필요함
    /// 추가하고싶은 반복문 추가해서 돌릴 수 있음
    /// </summary>
    public virtual void FSMUpdate()
    {
        if (curState != null)
        {
            curState.OnExecute(target.gameObject);
        }
    }

    /// <summary>
    /// 스테이트 변경
    /// </summary>
    /// <param name="changeState"></param>
    /// <param name="obj"></param>
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
}