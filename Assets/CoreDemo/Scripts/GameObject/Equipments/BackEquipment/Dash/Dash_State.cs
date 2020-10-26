using UnityEngine;

namespace Core.Equipment
{
  public abstract class DashEquipmentBack_State : IState
  {
    protected DashEquipmentBack main { get; set; }
  }

  public class DashEquipmentBack_Ready : DashEquipmentBack_State
  {
    public DashEquipmentBack_Ready(DashEquipmentBack equipment)
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
      
      if(main.WEDState == "run"){
        this.main.light1.transform.localPosition = new Vector3(0.782f - 0.8f,-0.9f,0);
        this.main.light2.transform.localPosition = new Vector3(0 - 0.8f,-0.9f,0);
      }
      else{
        this.main.light1.transform.localPosition = new Vector3(0.782f,0,0);
        this.main.light2.transform.localPosition = new Vector3(0,0,0);
      }
      this.main.light1.color = UnityEngine.Color.blue;
      this.main.light2.color = UnityEngine.Color.blue;
      main.animationController.play = main.WEDState;
      if (main.dashOK == false)
      {
        stateMachine.switchState("active");
      }
      
    }
  }

  public class DashEquipmentBack_CD : DashEquipmentBack_State
  {
    public DashEquipmentBack_CD(DashEquipmentBack equipment)
    {
      main = equipment;
    }
    public override string getName()
    {
      return "cd";
    }
    public override void onEnter()
    {
      
    }
    public override void onExit()
    {

    }
    public override void update()
    {
      main.animationController.play = main.WEDState;
      if(main.WEDState == "run"){
        this.main.light1.transform.localPosition = new Vector3(0.782f - 0.8f,-0.9f,0);
        this.main.light2.transform.localPosition = new Vector3(0 - 0.8f,-0.9f,0);
      }
      else{
        this.main.light1.transform.localPosition = new Vector3(0.782f,0,0);
        this.main.light2.transform.localPosition = new Vector3(0,0,0);
      }
      this.main.light1.color = UnityEngine.Color.red;
      this.main.light2.color = UnityEngine.Color.red;
      if (main.dashOK == true){
        stateMachine.switchState("ready");
      }
    }
  }

  public class DashEquipmentBack_Active : DashEquipmentBack_State
  {
    public DashEquipmentBack_Active(DashEquipmentBack equipment)
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
      main.main.deathJudgeBody.onDash = true;

      TimerManager.instance.addSustainTask(new Task(main.buffTime, () =>
      {
        main.main.physicsController.ignoreDamp = true;
        main.main.physicsController.ignoreForce = true;
        main.main.physicsController.setVerticalBrake(true);
      }));
      TimerManager.instance.addTask(new Task(main.buffTime, () =>
      {
        main.main.deathJudgeBody.onDash = false;
        main.main.physicsController.setHorizontalBrake(true);
      }));
    }
    public override void onExit()
    {

    }
    public override void update()
    {
      AnimatorStateInfo info = main.animationController.animator.GetCurrentAnimatorStateInfo(0);
      if (info.IsName("dash") && info.normalizedTime >= 1.0f)
      {
        stateMachine.switchState("cd");
      }
    }
  }
}