using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace FSM
{
  public abstract class IState
  {
    protected StateMachine BelongTo;

    public void setBelongTO(StateMachine s)
    {
      this.BelongTo = s;
    }
    public abstract void onEnter();

    public abstract void onUpdate();

    public abstract void onExit();

    public abstract string GetState();
  }

  public class StateMachine
  {
    List<IState> stateList;
    IState curState;
    public StateMachine()
    {
      stateList = new List<IState>();
    }

    public void addState(IState s)
    {
      IState tmpstate = this.GetState(s.GetState());
      if (tmpstate == null)
      {
        this.stateList.Add(s);
        s.setBelongTO(this);
      }
      else
      {
        Debug.LogWarningFormat("FSMSystem(容错)：该状态【{0}】已经存在！", s.GetState().ToString());
      }
    }
    public IState GetState(string s)
    {
      foreach (IState state in this.stateList)
      {
        if (state.GetState() == s)
        {
          return state;
        }
      }
      return null;
    }
    public void removeState(IState s)
    {
      IState _tmpState = GetState(s.GetState());
      if (_tmpState != null)
      {
        stateList.Remove(_tmpState);
      }
      else
      {
        Debug.LogWarningFormat("FSMSystem(容错)：该状态【{0}】已经被移除！", s.GetState().ToString());
      }
    }

    public void SwitchState(string s)
    {
      IState tmpState = this.GetState(s);
      if (tmpState == null)
      {
        Debug.LogWarningFormat("FSMSystem(容错)：该状态【{0}】不存在于状态机中！", s);
      }
      if (this.curState != null)
      {
        curState.onExit();
      }
      this.curState = tmpState;
      tmpState.onEnter();
    }
    public void Update()
    {
      this.curState.onUpdate();
    }

    public void clearState()
    {
      if (this.curState != null)
      {
        this.curState.onExit();
        this.curState = null;
      }
      this.stateList.Clear();
    }
  }
}

