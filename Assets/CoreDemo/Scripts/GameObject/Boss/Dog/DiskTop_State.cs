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
      TimerManager.instance.addTask(new Task(this.main.unactiveDuration, ()=>{
        this.main.search = true;
      }));
    }

    public override void onExit()
    {

    }

    public override void update()
    {
      if(this.main.search){
        if(this.main.aimAt.transform.position.x - this.main.transform.position.x > this.main.allowableErrorX){
          this.main.physicsController.addVelocity(this.main.speed,0);
        }
        else if(this.main.aimAt.transform.position.x - this.main.transform.position.x < -this.main.allowableErrorX){
          this.main.physicsController.addVelocity(-this.main.speed,0);
        }
        else{
          this.main.search = false;
          this.stateMachine.switchState("active");
        }
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
      TimerManager.instance.addTask(new Task(this.main.activeDuration, ()=>{
        this.main.search = true;
      }));
    }

    public override void onExit()
    {

    }

    public override void update()
    {
      if(this.main.search){
        if(this.main.aimAt.transform.position.x - this.main.transform.position.x > this.main.allowableErrorX){
          this.main.physicsController.addVelocity(this.main.speed,0);
        }
        else if(this.main.aimAt.transform.position.x - this.main.transform.position.x < -this.main.allowableErrorX){
          this.main.physicsController.addVelocity(-this.main.speed,0);
        }
        else{
          this.main.search = false;
          this.stateMachine.switchState("normal");
        }
      }
    }
  }

}