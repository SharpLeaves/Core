using UnityEngine;
using Core;
using Core.Character;


namespace Core.Dog
{
  public class Dog : Entity
  {
    public Wed aimAt;
    public Rigidbody2D disk;

    public CoreCTL core;

    public bool IsPure;
    public AudioComponent audioComponent;

    public Animator BossPuritiedAniamtor;

    public float power = 30.0f;




    protected override void StateMachineInit()
    {
      stateMachine = new StateMachine();
      stateMachine.addState(new Dog_Normal(this));
      stateMachine.addState(new Dog_Breakout(this));
      stateMachine.addState(new Dog_PowerIncrease(this));
      stateMachine.addState(new Dog_PowerDecrease(this));
      stateMachine.addState(new Dog_ChargeStart(this));
      stateMachine.addState(new Dog_ChargeOver(this));
      stateMachine.switchState("normal");
    }

    void Start()
    {
      StateMachineInit();
      this.IsPure = false;
    }

    private void FixedUpdate()
    {
      this.stateMachine.update();
      JudgeCore();
    }

    public void JudgeCore()
    {
      if (this.core.IsPure && !IsPure)
      {
        this.IsPure = true;
        this.stateMachine.switchState("breakout");
      }
    }
  }
}
