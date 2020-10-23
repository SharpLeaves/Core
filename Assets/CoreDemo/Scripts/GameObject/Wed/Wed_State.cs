using UnityEngine;

namespace Core.Character
{
  public abstract class Wed_State : IState
  {
    protected Wed main { get; set; }
  }

  public class Wed_Charge : Wed_State
  {
    public Wed_Charge(Wed main)
    {
      this.main = main;
    }

    public override void onEnter()
    {
      this.main.animationController.play = "charge";
      this.main.audioComponent.Play("wed_charge", false);
    }

    public override void onExit()
    {
      this.main.audioComponent.Stop();
    }

    public override void update()
    {
      if (this.main.inputController.MainHandHeld == false)
      {
        this.main.chargeTimer = 0.0f;
        this.stateMachine.switchState("idle");
      }

      this.main.chargeTimer += Time.deltaTime;

      if (this.main.chargeTimer >= this.main.chargeTime)
      {
        this.main.chargeTimer = 0.0f;
        this.main.chargeOver = true;

        TimerManager.instance.addTask(new Task(this.main.chargeDuration, () =>
        {
          this.main.chargeOver = false;
        }));

        this.stateMachine.switchState("idle");
      }


    }

    public override string getName()
    {
      return "charge";
    }

  }

  public class Wed_Purity : Wed_State
  {
    public Wed_Purity(Wed main)
    {
      this.main = main;
    }

    public override void onEnter()
    {
      this.main.chargeOver = false;
      this.main.animationController.play = "purity";
      this.main.audioComponent.Play("wed_emit", false);
    }

    public override void onExit()
    {

    }

    public override void update()
    {

      if (this.main.animationController.animInfo.IsName("purity") &&
          this.main.animationController.animInfo.normalizedTime >= 0.7f &&
          this.main.animationController.animInfo.normalizedTime < 1.0f)
      {
        this.main.PurityCol.gameObject.SetActive(true);
      }

      if (this.main.animationController.animInfo.IsName("purity") &&
          this.main.animationController.animInfo.normalizedTime >= 1.0f)
      {
        this.main.PurityCol.gameObject.SetActive(false);
        this.stateMachine.switchState("idle");
      }
    }

    public override string getName()
    {
      return "purity";
    }

  }

  public abstract class Wed_Ground : Wed_State
  {
    public override void onEnter()
    {
      if (Mathf.Abs(main.rigidbodyComponent.velocity.x) > main.runMinSpeed)
      {
        main.animationController.play = "run";
        main.animationController.speed = 1.0f;
      }
      else if (Mathf.Abs(main.rigidbodyComponent.velocity.x) > main.walkMinSpeed)
      {
        main.animationController.play = "walk";
        main.animationController.speed = 1.0f;
      }
      else
      {
        main.animationController.play = "stand";
        main.animationController.speed = 1.0f;
      }

    }
    public override void update()
    {
      // if(Mathf.Abs(main.rigidbodyComponent.velocity.x) > main.runMinSpeed){
      //     main.animationController.play = "run";
      //     main.animationController.speed = 1.0f;
      // }
      // else if(Mathf.Abs(main.rigidbodyComponent.velocity.x) > main.walkMinSpeed){
      //     main.animationController.play = "walk";
      //     main.animationController.speed = 1.0f;
      // }
      // else{
      //     main.animationController.play = "stand";
      //     main.animationController.speed = 1.0f;
      // }

      /*       if (main.inputController.Vertical > 0)
            {
              this.Container.switchState("lookup");
            }
            if (main.inputController.Vertical < 0)
            {
              this.Container.switchState("crouch");
            } */

      if (main.inputController.Jump)
      {

        main.audioComponent.PlayOnPoint("wed_jump", Camera.main.transform.position, 1f);
        main.physicsController.addPosition(0, 0.05f);
        main.physicsController.addVelocity(0, main.jump);
      }

      // if(main.inputController.Horizontal != 0){
      //     if(main.inputController.RunHeld){
      //         main.physicsController.addVelocity(main.runMinSpeed * main.inputController.Horizontal, 0);
      //     }
      //     else{
      //         main.physicsController.addVelocity(main.walkMinSpeed * main.inputController.Horizontal, 0);
      //     }
      // }
      if (main.inputController.Horizontal != 0)
      {
        if (main.inputController.RunHeld)
        {
          main.physicsController.addForce(main.runForce * main.inputController.Horizontal, 0);
        }
        else
        {
          main.physicsController.addForce(main.walkForce * main.inputController.Horizontal, 0);
        }
      }

      if (main.groundedTester.IsGrounded == false)
        this.Container.switchState("air");

      if (main.inputController.MainHandHeld && main.chargeOver == false)
      {
        this.stateMachine.switchState("charge");
      }

      if (main.inputController.MainHand && main.chargeOver == true)
      {
        this.stateMachine.switchState("purity");
      }

    }
  }

  public class Wed_Idle : Wed_Ground
  {
    public Wed_Idle(Wed mainController)
    {
      main = mainController;
    }

    public override string getName()
    {
      return "idle";
    }
    public override void onEnter()
    {
      base.onEnter();
    }
    public override void update()
    {
      base.update();
      if (Mathf.Abs(main.rigidbodyComponent.velocity.x) > main.walkMinSpeed)
        this.Container.switchState("walk");
    }
    public override void onExit()
    {

    }
  }

  public class Wed_Walk : Wed_Ground
  {
    public Wed_Walk(Wed mainController)
    {
      main = mainController;
    }

    public override string getName()
    {
      return "walk";
    }
    public override void onEnter()
    {
      main.audioComponent.Play("wed_walk", true);
      base.onEnter();
    }
    public override void update()
    {
      base.update();

      if (Mathf.Abs(main.rigidbodyComponent.velocity.x) <= main.walkMinSpeed)
        this.Container.switchState("idle");
      if (Mathf.Abs(main.rigidbodyComponent.velocity.x) >= main.runMinSpeed)
        this.Container.switchState("run");
    }
    public override void onExit()
    {
      main.audioComponent.Stop();
    }
  }

  public class Wed_Run : Wed_Ground
  {
    public Wed_Run(Wed mainController)
    {
      main = mainController;
    }
    public override string getName()
    {
      return "run";
    }
    public override void onEnter()
    {
      main.audioComponent.Play("wed_run", true);
      base.onEnter();

    }
    public override void update()
    {
      base.update();

      if (Mathf.Abs(main.rigidbodyComponent.velocity.x) <= main.runMinSpeed)
        this.Container.switchState("walk");
    }
    public override void onExit()
    {
      main.audioComponent.Stop();
    }
  }

  public class Wed_Air : Wed_State
  {
    public Wed_Air(Wed mainController)
    {
      main = mainController;
    }
    public override string getName()
    {
      return "air";
    }

    public override void onEnter()
    {
      main.animationController.play = "jump_up";
      main.animationController.speed = 1.0f;
    }

    public override void update()
    {
      if (main.rigidbodyComponent.velocity.y >= 0)
      {
        main.animationController.play = "jump_up";
      }
      else
      {
        main.animationController.play = "jump_down";
      }
      if (main.groundedTester.IsGrounded && main.physicsController.Velocity.y <= 0)
        this.Container.switchState("idle");





      if (main.inputController.Horizontal != 0)
      {
        main.physicsController.addForce(main.airForce * main.inputController.Horizontal, 0);
      }
      if (main.inputController.JumpHeld)
      {
        main.physicsController.gravityScale = main.jumpGravityScale;
      }
    }

    public override void onExit()
    {
      main.audioComponent.PlayOnPoint("wed_fall", Camera.main.transform.position, 1f);
    }
  }

  public class Wed_Crouch : Wed_State
  {
    public Wed_Crouch(Wed mainController)
    {
      main = mainController;
    }
    public override string getName()
    {
      return "crouch";
    }

    public override void onEnter()
    {
      main.physicsController.setHorizontalBrake(true);
      main.animationController.play = "crouch";
      main.animationController.speed = 1.0f;
    }

    public override void update()
    {
      if (main.inputController.Vertical == 0)
      {
        this.Container.switchState("idle");
      }

      main.lookController.VerticalOffset = -0.5f;
    }

    public override void onExit()
    {

    }
  }

  public class Wed_LookUp : Wed_State
  {
    public Wed_LookUp(Wed mainController)
    {
      main = mainController;
    }
    public override string getName()
    {
      return "lookup";
    }

    public override void onEnter()
    {
      main.physicsController.setHorizontalBrake(true);
      main.animationController.play = "lookup";
      main.animationController.speed = 1.0f;
    }

    public override void update()
    {
      if (main.inputController.Vertical == 0)
      {
        this.Container.switchState("idle");
      }

      main.lookController.VerticalOffset = 0.5f;
    }

    public override void onExit()
    {

    }
  }

  public class Wed_Dead : Wed_State
  {
    public Wed_Dead(Wed mainController)
    {
      main = mainController;
    }
    public override string getName()
    {
      return "dead";
    }

    public override void onEnter()
    {
      main.audioComponent.PlayOnPoint("wed_die", main.wedTransform.position, 1.0f);
      main.IsDead = true;
      main.animationController.play = "dead";
    }

    public override void update()
    {

    }

    public override void onExit()
    {
      main.IsDead = false;
    }
  }


  public class Wed_ReModel : Wed_State
  {
    public Wed_ReModel(Wed mainController)
    {
      main = mainController;
    }
    public override string getName()
    {
      return "remodel";
    }

    public override void onEnter()
    {

      main.animationController.play = "remodel";
    }

    public override void update()
    {
      if (main.animationController.animInfo.IsName("remodel") && main.animationController.animInfo.normalizedTime >= 1.0f)
        main.animationController.play = "remodelKeep";
      if (!main.inputController.InteractInput)
      {
        this.Container.switchState("idle");
      }

    }

    public override void onExit()
    {

    }
  }

}