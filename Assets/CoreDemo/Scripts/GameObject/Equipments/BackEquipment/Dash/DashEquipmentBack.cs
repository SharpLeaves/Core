using Core;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

namespace Core.Equipment
{
  public class DashEquipmentBack : IEquipmentBack
  {
    // Dash CD
    public float dashCD = 4.0f;
    public bool dashOK = true;
    public float buffTime = 0.05f;
    public float dashForce = 50f;

    public string WEDState;

    public Light2D light1;
    public Light2D light2;

    public override string getName()
    {
      return "Dash";
    }

    public override void function()
    {
      if (main.GetStateMachine.curState.getName() == "air" && dashOK)
      {
        Core.AudioManager._instance.PlayAudioByName("jet", this.transform.position);
        dashOK = false;
        main.physicsController.addVelocity(dashForce * main.flipController.flipTransform.localScale.x * -1, 0);
        TimerManager.instance.addTask(new Task(dashCD, () =>
        {
          dashOK = true;
        }));
        this.stateMachine.switchState("active");
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
      WEDState = "idle";
    }
    protected void FixedUpdate()
    {
      base.Update();
      this.stateMachine.update();
      getWEDState();
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
