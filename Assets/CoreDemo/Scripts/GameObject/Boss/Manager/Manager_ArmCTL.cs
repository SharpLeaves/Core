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

  public bool Active;

  private int rotateDir;
  private int moveDir;
  private float currentRotate = 0;
  private float currentMovement = 0;

  private RaycastHit2D hit;

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
    }


  }



  void Init()
  {
    rotateDir = 1;
    moveDir = 1;
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
}
