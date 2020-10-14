using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

public class HydroPress_CTL : TrapBase
{
  [Header("下压初速度")]
  public float PressInitialSpeed;
  [Header("下压加速度")]
  public float PressAcceleratedSpeed;
  [Header("回缩速度")]
  public float RecallSpeed;
  [Header("下压距离")]
  public float PressDistance;
  [Header("下压停留时间")]
  public float PressTimeoutDuration;
  [Header("回缩停留时间")]
  public float RecallTimeoutDuration;
  [Header("时间偏移")]
  public float TimeOffset;

  [Header("撞击箱")]
  public Collider2D col;


  /* 当前下压速度 */
  private float CurrentPressSpeed;
  /* 当前状态 */
  private bool isPress;
  /* 当前下压的距离 */
  private float CurPressDistance;
  /*判断是否在停留*/
  private bool IsTimeout;

  private bool IsRecallFinished;

  // Start is called before the first frame update

  void Start()
  {
    Init();
  }

  // Update is called once per frame
  void Update()
  {

  }

  private void FixedUpdate()
  {
    if (Active)
    {
      if (!IsTimeout)
      {
        this.Press();
        this.Recall();
      }
    }
    else
    {
      if (!IsRecallFinished)
      {
        this.Recall();
      }
    }
  }

  protected override void StateMachineInit()
  {
    this.stateMachine = new Core.StateMachine();
    this.stateMachine.addState(new HydroPress_Normal(this));
    this.stateMachine.addState(new HydroPress_Disable(this));
  }

  public override void FunctionOnDisable()
  {
    this.Active = false;
    isPress = false;
    this.col.isTrigger = false;
    this.Press();
    this.Recall();
  }

  void Init()
  {
    isPress = true;
    IsRecallFinished = true;
    this.Active = false;
    this.IsTimeout = false;
    this.CurrentPressSpeed = this.PressInitialSpeed;
    StateMachineInit();
    StartCoroutine(processTimeOffset());
  }




  void Press()
  {
    if (isPress)
    {
      this.CurrentPressSpeed += this.PressAcceleratedSpeed;
      this.transform.position -= new Vector3(0, CurrentPressSpeed * Time.deltaTime, 0);
      this.CurPressDistance += CurrentPressSpeed * Time.deltaTime;
      if (this.CurPressDistance >= this.PressDistance)
        StartCoroutine(PressTimeout());
    }

  }

  void Recall()
  {
    if (!isPress)
    {
      this.transform.position += new Vector3(0, RecallSpeed * Time.deltaTime, 0);
      this.CurPressDistance -= RecallSpeed * Time.deltaTime;
      if (this.CurPressDistance <= 0)
      {
        StartCoroutine(RecallTimeout());
        this.CurrentPressSpeed = this.PressInitialSpeed;
        if (!Active)
          this.IsRecallFinished = true;
      }
    }
  }

  IEnumerator processTimeOffset()
  {
    yield return new WaitForSeconds(TimeOffset);
    IsRecallFinished = false;
    this.Active = true;
  }

  IEnumerator PressTimeout()
  {
    IsTimeout = true;
    yield return new WaitForSeconds(PressTimeoutDuration);
    IsTimeout = false;
    isPress = false;
  }

  IEnumerator RecallTimeout()
  {
    IsTimeout = true;
    yield return new WaitForSeconds(RecallTimeoutDuration);
    IsTimeout = false;
    isPress = true;
  }
}
