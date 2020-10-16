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
    public bool dashOK = true;

    public float DashForce;
    public override string getName()
    {
      return "DashUp";
    }

    public override void function()
    {
      Debug.Log("Dash: Process");
      if (main.GetStateMachine.curState.getName() == "air" && dashOK)
      {
        dashOK = false;
        if (main.physicsController.Velocity.y < 0)
        {
          main.physicsController.addVelocity(0, -main.physicsController.Velocity.y + DashForce);
        }
        else
          main.physicsController.addVelocity(0, DashForce);
        TimerManager.instance.addTask(new Task(dashCD, () =>
        {
          dashOK = true;
        }));
      }
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
      //this.stateMachine.update();
    }
  }
}
