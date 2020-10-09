using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

public class Laser_CTL : TrapBase
{

  [Header("旋转速度")]
  public float rotateSpeed;
  [Header("最大旋转角度")]
  public float rotateMax = 60;
  [Header("射线的长度")]
  public float LaserLength;
  [Header("射线的Line")]
  public LineRenderer line;
  [Header("需要射线检测的图层")]
  public LayerMask layer;
  [Header("左右移动速度")]
  public float MoveSpeed;
  [Header("左右移动范围")]
  public float MoveRange;


  private int rotateDir;
  private int moveDir;
  private float currentRotate = 0;
  private float currentMovement = 0;

  private RaycastHit2D hit;


  public override void FunctionOnDisable()
  {
    Destroy(line.gameObject);
    //this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
  }

  protected override void StateMachineInit()
  {
    this.stateMachine = new Core.StateMachine();
    this.stateMachine.addState(new Laser_Normal(this));
    this.stateMachine.addState(new Laser_Disable(this));
  }

  void Start()
  {
    Init();
  }



  void FixedUpdate()
  {
    //this.stateMachine.update();
    if (Active)
    {
      rotate();
      LaserRay();
      Move();
    }
  }



  void Init()
  {
    rotateDir = 1;
    moveDir = 1;
    this.Active = true;
  }
  void rotate()
  {

    transform.Rotate(new Vector3(0, 0, rotateDir * rotateSpeed));
    currentRotate += rotateDir * rotateSpeed;
    if (Mathf.Abs(currentRotate) >= rotateMax)
      rotateDir = -rotateDir;
  }

  void LaserRay()
  {
    hit = Physics2D.Raycast(transform.position, transform.rotation * Vector3.up, LaserLength, layer);
    if (hit.collider != null)
    {
      if (hit.collider.gameObject.tag == "Platform")
      {
        float dis = Vector2.Distance(hit.point, (Vector2)transform.position);
        this.line.SetPosition(1, new Vector3(0, dis, 0));
        this.line.GetComponent<BoxCollider2D>().size = new Vector2(this.line.GetComponent<BoxCollider2D>().size.x, dis);
        this.line.GetComponent<BoxCollider2D>().offset = new Vector2(this.line.GetComponent<BoxCollider2D>().offset.x, dis / 2);
        //Debug.Log(dis);
      }
    }
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
