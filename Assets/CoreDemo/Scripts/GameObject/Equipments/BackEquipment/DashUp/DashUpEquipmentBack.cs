using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
namespace Core.Equipment
{
  public class DashUpEquipmentBack : IEquipmentBack
  {
    // Dash CD
    public float dashCD = 4.0f;
    public bool IsUsed;

    public float DashForce;

    public string WEDState;


    public override string getName()
    {
      return "DashUp";
    }

    public override void function()
    {
      if (main.GetStateMachine.curState.getName() == "air" && !IsUsed)
      {
        Core.AudioManager._instance.PlayAudioByName("jet", this.transform.position);

        if (main.physicsController.Velocity.y < 0)
        {
          main.physicsController.addVelocity(0, -main.physicsController.Velocity.y + DashForce);
        }
        else
          main.physicsController.addVelocity(0, DashForce);

        IsUsed = true;
        this.stateMachine.switchState("active");
      }
    }

    private void Start()
    {
      StateMachineInit();
      IsUsed = false;
    }

    protected override void StateMachineInit()
    {
      this.stateMachine = new StateMachine();
      this.stateMachine.addState(new DashUpEquipmentBack_Ready(this));
      this.stateMachine.addState(new DashUpEquipmentBack_CD(this));
      this.stateMachine.addState(new DashUpEquipmentBack_Active(this));
      this.stateMachine.switchState("ready");
    }

    protected void FixedUpdate()
    {
      base.Update();
      this.stateMachine.update();
      getWEDState();
      if (main.groundedTester.IsGrounded)
        IsUsed = false;

    }

    void getWEDState()
    {
      switch (main.GetStateMachine.curState.getName())
      {
        case "walk":
          this.WEDState = "walk";
          break;
        case "run":
          this.WEDState = "run";
          break;
        case "idle":
          this.WEDState = "idle";
          break;
        case "air":
          this.WEDState = "jump";
          break;
        case "charge":
          this.WEDState = "charge";
          break;
        case "purity":
          this.WEDState = "purity";
          break;
        case "remodel":
          this.WEDState = "remodel";
          break;

      }
    }
  }
}
