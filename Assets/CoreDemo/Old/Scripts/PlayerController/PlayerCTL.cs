using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;
using PlayerState;
using Core;
public class PlayerCTL : MonoBehaviour
{

  [Header("移动参数")]
  public float moveSpeed;
  public float runSpeed;
  public float jumpHeight;
  [Header("地面监测点")]
  public Transform groundCheck;
  public LayerMask ground;
  public bool IsGround;
  [Header("装备结点")]
  public BackEquipmentInterface backEquaipment;
  public HandEquipmentInterface handEquaipment;

  public Animator AnimCTL;
  public AnimatorStateInfo AnimInfo;
  public Rigidbody2D rb;
  private FSM.StateMachine sm;
  // Start is called before the first frame update
  void Start()
  {
    AnimCTL = GetComponent<Animator>();
    rb = this.GetComponent<Rigidbody2D>();
    StateMachineInit();
  }
  private void Update()
  {
    this.AnimInfo = AnimCTL.GetCurrentAnimatorStateInfo(0);
    IsGround = Physics2D.OverlapBox(groundCheck.position, new Vector2(0.3f, 0.3f), 0, ground);
    this.sm.Update();
  }
  // Update is called once per frame
  void FixedUpdate()
  {

  }
  public void Walk(float MoveX)
  {
    if (MoveX != 0)
    {
      transform.localScale = new Vector3(-MoveX, 1, 1);
    }

    this.rb.velocity = new Vector2(MoveX * this.moveSpeed, rb.velocity.y);
  }
  public void run(float MoveX)
  {
    if (MoveX != 0)
    {
      transform.localScale = new Vector3(-MoveX, 1, 1);
    }

    this.rb.velocity = new Vector2(MoveX * this.runSpeed, rb.velocity.y);
  }
  public void Jump()
  {
    if (IsGround)
      this.rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
  }
  public void Shock()
  {

  }

  public void Die()
  {
    this.sm.SwitchState("die");
  }
  void StateMachineInit()
  {
    this.sm = new FSM.StateMachine();
    this.sm.addState(new PlayerIdle(this));
    this.sm.addState(new PlayerRun(this));
    this.sm.addState(new PlayerWalk(this));
    this.sm.addState(new PlayerRecycle(this));
    this.sm.addState(new PlayerShock(this));
    this.sm.addState(new PlayerDie(this));
    this.sm.SwitchState("idle");
  }

  public void SwitchBackEquipment(string equipName)
  {
    this.backEquaipment.swtichEquipment(equipName);
  }

  public void SwitchHandEquipment(string equipName)
  {
    this.handEquaipment.swtichEquipment(equipName);
  }


  public void ResetPlayer()
  {
    this.transform.position = GameManagerData.GetInstance().SpwanPoint;
    this.sm.SwitchState("idle");
  }



  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.tag == "Trap")
    {
      this.Die();
    }
  }

}
