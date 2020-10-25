using UnityEngine;

namespace Core.Equipment
{
  public abstract class DashUpEquipmentBack_State : IState
  {
    protected DashUpEquipmentBack main { get; set; }
  }

  public class DashUpEquipmentBack_Ready : DashUpEquipmentBack_State
  {
    public DashUpEquipmentBack_Ready(DashUpEquipmentBack equipment)
    {
      main = equipment;
    }
    public override string getName()
    {
      return "ready";
    }
    public override void onEnter()
    {
      main.animationController.play = main.WEDState;
    }
    public override void onExit()
    {

    }
    public override void update()
    {
      main.animationController.play = main.WEDState;
      if (main.dashOK == false)
      {
        stateMachine.switchState("active");
      }
    }
  }

  public class DashUpEquipmentBack_CD : DashUpEquipmentBack_State
  {
    public DashUpEquipmentBack_CD(DashUpEquipmentBack equipment)
    {
      main = equipment;
    }
    public override string getName()
    {
      return "cd";
    }
    public override void onEnter()
    {
      //main.animationController.play = "cd";
    }
    public override void onExit()
    {

    }
    public override void update()
    {
      main.animationController.play = main.WEDState;
      if (main.dashOK == true)
      {
        stateMachine.switchState("ready");
      }
    }
  }

  public class DashUpEquipmentBack_Active : DashUpEquipmentBack_State
  {
    public DashUpEquipmentBack_Active(DashUpEquipmentBack equipment)
    {
      main = equipment;
    }
    public override string getName()
    {
      return "active";
    }
    public override void onEnter()
    {
      main.animationController.play = "dash";
    }
    public override void onExit()
    {

    }
    public override void update()
    {
      AnimatorStateInfo info = main.animationController.animator.GetCurrentAnimatorStateInfo(0);

      if (info.normalizedTime >= 1.0f)
      {
        stateMachine.switchState("cd");
      }
    }
  }
}