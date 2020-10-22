using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_ArmCTL : MonoBehaviour
{
  [Header("旋转速度")]
  public float rotateSpeed;
  [Header("最大旋转角度")]
  public float rotateMax = 60;
  [Header("左右移动速度")]
  public float MoveSpeed;
  [Header("左右移动范围")]
  public float MoveRange;
  [Header("激光组件")]
  public Laser_CTL laser;
  [Header("停歇时间")]
  public float BreakTime;
  [Header("运行时间")]
  public float RunningTime;
  [Header("时间偏移")]
  public float TimeOffset;
  [Header("声音组件")]
  public Core.AudioComponent audioComponent;

  public bool Active;

  private int rotateDir;
  private int moveDir;
  private float currentRotate = 0;
  private float currentMovement = 0;

  private float CurRunningTime;

  void Start()
  {
    Init();
  }



  void FixedUpdate()
  {
    if (Active)
    {
      //this.stateMachine.update();
      rotate();
      Move();
      Break();
    }


  }

  public void SetActive()
  {
    this.Active = true;
    this.audioComponent.Play("Laser", true);
    laser.line.gameObject.SetActive(true);
  }


  void Init()
  {
    rotateDir = 1;
    moveDir = 1;
    CurRunningTime = 0;
    Active = false;

  }
  void rotate()
  {

    transform.Rotate(new Vector3(0, 0, rotateDir * rotateSpeed));
    currentRotate += rotateDir * rotateSpeed;
    if (Mathf.Abs(currentRotate) >= rotateMax)
      rotateDir = -rotateDir;

  }

  void Move()
  {
    if (this.currentMovement < this.MoveRange)
    {
      float moveDistance = MoveSpeed * Time.deltaTime;
      this.transform.Translate(moveDistance * moveDir, 0, 0);
      this.currentMovement += moveDistance;
    }
    else
    {
      moveDir = -moveDir;
      this.currentMovement = 0;
    }
  }

  void Break()
  {
    CurRunningTime += Time.deltaTime;
    if (CurRunningTime >= RunningTime)
    {
      this.Active = false;
      CurRunningTime = 0;
      this.laser.line.enabled = false;
      this.audioComponent.Stop();
      StartCoroutine(BreakTimer());
    }
  }

  IEnumerator BreakTimer()
  {
    yield return new WaitForSeconds(BreakTime);
    this.Active = true;
    this.laser.line.enabled = true;
    this.audioComponent.Play("Laser", true);
  }


}
