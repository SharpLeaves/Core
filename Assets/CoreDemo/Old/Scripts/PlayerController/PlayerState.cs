using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerState
{
  abstract class PlayerState : FSM.IState
  {
    protected PlayerCTL Instance { get; set; }
  }
  class PlayerIdle : PlayerState
  {
    public PlayerIdle(PlayerCTL instance)
    {
      this.Instance = instance;
    }
    public override void onEnter()
    {

    }

    public override void onUpdate()
    {
      float MoveX = Input.GetAxis("Horizontal");
      if (MoveX != 0)
        this.BelongTo.SwitchState("walk");
      if (Input.GetKeyDown(KeyCode.Space))
        this.Instance.Jump();
      if (Input.GetKeyDown(KeyCode.Z))
        this.BelongTo.SwitchState("shock");
    }

    public override void onExit()
    {

    }

    public override string GetState()
    {
      return "idle";
    }
  }

  class PlayerWalk : PlayerState
  {
    public PlayerWalk(PlayerCTL instance)
    {
      this.Instance = instance;
    }
    public override void onEnter()
    {
      this.Instance.AnimCTL.SetBool("Walk", true);
    }

    public override void onUpdate()
    {
      float MoveX = Input.GetAxisRaw("Horizontal");
      if (MoveX == 0)
        this.BelongTo.SwitchState("idle");
      this.Instance.Walk(MoveX);
      if (Input.GetKey(KeyCode.LeftShift))
        this.BelongTo.SwitchState("run");
      if (Input.GetKeyDown(KeyCode.Space))
        this.Instance.Jump();
      if (Input.GetKeyDown(KeyCode.Z))
        this.BelongTo.SwitchState("shock");

    }

    public override void onExit()
    {
      this.Instance.AnimCTL.SetBool("Walk", false);
    }

    public override string GetState()
    {
      return "walk";
    }
  }

  class PlayerJump : PlayerState
  {
    public PlayerJump(PlayerCTL instance)
    {
      this.Instance = instance;
    }
    public override void onEnter()
    {
      this.Instance.Jump();
    }
    public override void onUpdate()
    {
    }

    public override void onExit()
    {

    }

    public override string GetState()
    {
      return "jump";
    }
  }

  class PlayerRun : PlayerState
  {
    public PlayerRun(PlayerCTL instance)
    {
      this.Instance = instance;
    }
    public override void onEnter()
    {
      this.Instance.AnimCTL.SetBool("Run", true);
    }

    public override void onUpdate()
    {
      float MoveX = Input.GetAxisRaw("Horizontal");
      if (MoveX == 0)
        this.BelongTo.SwitchState("idle");
      this.Instance.run(MoveX);
      if (!Input.GetKey(KeyCode.LeftShift))
        this.BelongTo.SwitchState("walk");
      if (Input.GetKeyDown(KeyCode.Space))
        this.Instance.Jump();
    }

    public override void onExit()
    {
      this.Instance.AnimCTL.SetBool("Run", false);
    }

    public override string GetState()
    {
      return "run";
    }
  }


  class PlayerRecycle : PlayerState
  {
    public PlayerRecycle(PlayerCTL instance)
    {
      this.Instance = instance;
    }
    public override void onEnter()
    {

    }

    public override void onUpdate()
    {

    }

    public override void onExit()
    {

    }

    public override string GetState()
    {
      return "recycle";
    }
  }


  class PlayerShock : PlayerState
  {
    public PlayerShock(PlayerCTL instance)
    {
      this.Instance = instance;
    }
    public override void onEnter()
    {
      this.Instance.AnimCTL.SetBool("Shock", true);
      this.Instance.Shock();
    }

    public override void onUpdate()
    {
      if (this.Instance.AnimInfo.normalizedTime >= 1.0f)
      {
        this.BelongTo.SwitchState("idle");
      }
    }

    public override void onExit()
    {
      this.Instance.AnimCTL.SetBool("Shock", false);
    }

    public override string GetState()
    {
      return "shock";
    }
  }

  class PlayerDie : PlayerState
  {
    public PlayerDie(PlayerCTL instance)
    {
      this.Instance = instance;
    }
    public override void onEnter()
    {
      this.Instance.AnimCTL.SetBool("Die", true);
    }

    public override void onUpdate()
    {
      if (this.Instance.AnimInfo.IsName("Die") &&
         this.Instance.AnimInfo.normalizedTime >= 1.0)
      {
        this.Instance.ResetPlayer();
      }
    }

    public override void onExit()
    {
      this.Instance.AnimCTL.SetBool("Die", false);
    }

    public override string GetState()
    {
      return "die";
    }
  }
}