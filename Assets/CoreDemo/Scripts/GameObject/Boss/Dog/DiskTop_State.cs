using UnityEngine;
using Core;

namespace Core.Dog
{
  public abstract class DiskTop_State : IState
  {
    protected DiskTop main { get; set; }
  }

  public class DiskTop_Normal : DiskTop_State
  {
    public DiskTop_Normal(DiskTop main)
    {
      this.main = main;
    }
    public override string getName()
    {
      return "normal";
    }

    public override void onEnter()
    {
      
    }

    public override void onExit()
    {

    }

    public override void update()
    {
      if(Mathf.Abs(this.main.aimAt.transform.position.x - this.main.transform.position.x) > 0.5){
        this.stateMachine.switchState("moving");
      }
      else{
        this.stateMachine.switchState("active");
        this.main.active = true;
      }
    }
  }

  public class DiskTop_Active : DiskTop_State
  {
    public DiskTop_Active(DiskTop main)
    {
      this.main = main;
    }
    public override string getName()
    {
      return "active";
    }

    public override void onEnter()
    {
      TimerManager.instance.addTask(new Task(5.0f, ()=>{
        this.main.active = false;
      }));
    }

    public override void onExit()
    {

    }

    public override void update()
    {
      if(!this.main.active){
        this.stateMachine.switchState("normal");
      }
      
    }
  }

  public class DiskTop_Moving : DiskTop_State
  {
    public DiskTop_Moving(DiskTop main)
    {
      this.main = main;
    }
    public override string getName()
    {
      return "moving";
    }

    public override void onEnter()
    {

    }

    public override void onExit()
    {

    }

    public override void update()
    {
      if(this.main.aimAt.transform.position.x - this.main.transform.position.x > 0.5){
        this.main.physicsController.addVelocity(20,0);
      }
      else if(this.main.aimAt.transform.position.x - this.main.transform.position.x < -0.5){
        this.main.physicsController.addVelocity(-20,0);
      }
      else{
        this.stateMachine.switchState("normal");
      }
    }
  }
}