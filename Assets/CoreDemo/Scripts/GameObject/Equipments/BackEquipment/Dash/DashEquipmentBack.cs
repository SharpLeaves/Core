using Core;
using UnityEngine;

namespace Core.Equipment
{
  public class DashEquipmentBack : IEquipmentBack
  {
    // Dash CD
    public float dashCD = 4.0f;
    public bool dashOK = true;
    public float buffTime = 0.05f;
    public float dashForce = 50f;

    public override string getName()
    {
      return "Dash";
    }

    public override void function()
    {
      if (main.GetStateMachine.curState.getName() == "air" && dashOK)
      {
        dashOK = false;
        main.physicsController.addVelocity(dashForce * main.flipController.flipTransform.localScale.x * -1, 0);
        TimerManager.instance.addTask(new Task(dashCD, () =>
        {
          dashOK = true;
        }));
      }
    }

    protected override void StateMachineInit()
    {
      this.stateMachine = new StateMachine();
      this.stateMachine.addState(new DashEquipmentBack_Ready(this));
      this.stateMachine.addState(new DashEquipmentBack_CD(this));
      this.stateMachine.addState(new DashEquipmentBack_Active(this));
      this.stateMachine.switchState("ready");
    }
    void Start()
    {
      StateMachineInit();
    }
    protected void FixedUpdate()
    {
      base.Update();
      this.stateMachine.update();
    }

    // protected void Update()
    // {
    //   base.Update();
    // }
  }
}
