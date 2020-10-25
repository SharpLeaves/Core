using UnityEngine;
using Core;

namespace Core.Dog
{
  public abstract class Dog_State : IState
  {
    protected Dog main { get; set; }
  }

  public class Dog_Normal : Dog_State
  {
    public Dog_Normal(Dog main)
    {
      this.main = main;
    }
    public override string getName()
    {
      return "normal";
    }

    public override void onEnter()
    {
      this.main.animationController.play = "normal";
    }

    public override void onExit()
    {

    }

    public override void update()
    {
      if (Mathf.Abs(this.main.aimAt.transform.position.x - this.main.transform.position.x) < 30)
      {
        this.stateMachine.switchState("powerdecrease");
      }
    }
  }

  public class Dog_Breakout : Dog_State
  {
    public Dog_Breakout(Dog main)
    {
      this.main = main;
    }
    public override string getName()
    {
      return "breakout";
    }

    public override void onEnter()
    {

    }

    public override void onExit()
    {

    }

    public override void update()
    {

    }
  }

  public class Dog_PowerIncrease : Dog_State
  {
    public Dog_PowerIncrease(Dog main)
    {
      this.main = main;
    }
    public override string getName()
    {
      return "powerincrease";
    }

    public override void onEnter()
    {
      this.main.animationController.play = "powerincrease";
      this.main.audioComponent.Play("wed_charge", true);
    }

    public override void onExit()
    {
      this.main.audioComponent.Stop();
    }

    public override void update()
    {
      AnimatorStateInfo info = main.animationController.animInfo;
      if (info.normalizedTime >= 1.0f && info.IsName("powerincrease"))
      {
        stateMachine.switchState("chargeover");
      }
    }
  }

  public class Dog_PowerDecrease : Dog_State
  {
    public Dog_PowerDecrease(Dog main)
    {
      this.main = main;
    }
    public override string getName()
    {
      return "powerdecrease";
    }

    public override void onEnter()
    {
      this.main.animationController.play = "powerdecrease";
    }

    public override void onExit()
    {

    }

    public override void update()
    {
      AnimatorStateInfo info = main.animationController.animator.GetCurrentAnimatorStateInfo(0);
      if (info.normalizedTime >= 1.0f && info.IsName("powerdecrease"))
      {
        stateMachine.switchState("chargestart");
      }
    }
  }

  public class Dog_ChargeStart : Dog_State
  {
    public Dog_ChargeStart(Dog main)
    {
      this.main = main;
    }
    public override string getName()
    {
      return "chargestart";
    }

    public override void onEnter()
    {
      this.main.animationController.play = "chargestart";

      TimerManager.instance.addSustainTask(new Task(0.66f, () =>
      {
        Vector2 velovity = this.main.disk.velocity;
        velovity.y = 10f;
        this.main.disk.velocity = velovity;
      }));

      TimerManager.instance.addTask(new Task(0.66f, () =>
      {
        Vector2 velovity = this.main.disk.velocity;
        velovity.y = 0f;
        this.main.disk.velocity = velovity;
      }));
    }

    public override void onExit()
    {

    }

    public override void update()
    {
      AnimatorStateInfo info = main.animationController.animator.GetCurrentAnimatorStateInfo(0);
      if (info.normalizedTime >= 1.0f && info.IsName("chargestart"))
      {
        stateMachine.switchState("powerincrease");
      }
    }
  }

  public class Dog_ChargeOver : Dog_State
  {
    public Dog_ChargeOver(Dog main)
    {
      this.main = main;
    }
    public override string getName()
    {
      return "chargeover";
    }

    public override void onEnter()
    {
      this.main.animationController.play = "chargeover";
      TimerManager.instance.addTask(new Task(1.0f, () =>
      {

        TimerManager.instance.addSustainTask(new Task(0.2f, () =>
        {
          Vector2 velocity = this.main.disk.velocity;
          velocity.y = -30f;
          this.main.disk.velocity = velocity;
          this.main.audioComponent.Play("Pang", false);
        }));


      }));

    }

    public override void onExit()
    {
      Vector2 velovity = this.main.disk.velocity;
      velovity.y = 0.0f;
      this.main.disk.velocity = velovity;
      Vector2 positon = this.main.disk.transform.position;
      positon.y = 0.0f;
      this.main.disk.transform.position = positon;
    }

    public override void update()
    {
      AnimatorStateInfo info = main.animationController.animator.GetCurrentAnimatorStateInfo(0);
      if (info.normalizedTime >= 1.0f && info.IsName("chargeover"))
      {
        stateMachine.switchState("normal");
      }
    }
  }

}