using UnityEngine;

namespace Core.Character
{
  [AddComponentMenu("Core/Character/MainController")]

  public class Wed : Creature
  {
    // 输入组件
    public Wed_InputController inputController;
    // 相机控制组件
    public Wed_LookController lookController;
    // 朝向组件
    public Wed_FlipController flipController;
    // 装备挂载组件
    public EquipmentController handEquipment;
    public EquipmentController backEquipment;
    // 死亡判定组件
    public Wed_DeathJudgeBody deathJudgeBody;
    public Wed_DeathJudgeTop deathJudgeTop;
    //角色净化判断碰撞箱
    public Collider2D PurityCol;
    //角色的transform
    public Transform wedTransform;
    //角色顶部碰撞检测
    public GroundedTester upTester;
    //声音组件
    public AudioComponent audioComponent;

    public bool chargeOver = false;

    public float chargeTime = 2.0f;

    public float chargeTimer = 0.0f;

    public float chargeDuration = 5.0f;

    /* 角色动作参数 */
    // 行走增量
    public float walkForce = 10f;
    // 奔跑增量
    public float runForce = 50f;
    // 浮空增量
    public float airForce = 30f;
    // 最小行走速度
    public float walkMinSpeed = 0.2f;
    // 最小跑步速度
    public float runMinSpeed = 1f;
    // 跳跃初速
    public float jump = 4.0f;
    // 跳跃重力
    public float jumpGravityScale = 0.8f;
    //角色是否死亡
    public bool IsDead { get; set; }
    // // 跳跃前容许跳跃持续时间
    // public float lateJumpToleranceDuration = 0.2f;
    // public float canJumpTimeRemaining;
    protected override void StateMachineInit()
    {
      this.stateMachine = new StateMachine();
      this.stateMachine.addState(new Wed_Idle(this));
      this.stateMachine.addState(new Wed_Walk(this));
      this.stateMachine.addState(new Wed_Run(this));
      this.stateMachine.addState(new Wed_Air(this));
      this.stateMachine.addState(new Wed_Crouch(this));
      this.stateMachine.addState(new Wed_LookUp(this));
      this.stateMachine.addState(new Wed_Dead(this));
      this.stateMachine.addState(new Wed_ReModel(this));
      this.stateMachine.addState(new Wed_Charge(this));
      this.stateMachine.addState(new Wed_Purity(this));

      this.stateMachine.switchState("idle");
    }

    private void Awake()
    {
      StateMachineInit();
    }
    void Start()
    {

    }

    private void FixedUpdate()
    {

      Debug.Log(this.stateMachine.curState.getName());
      this.stateMachine.update();

    }

    public void Wed_Die()
    {
      this.stateMachine.switchState("dead");
    }

    public void Wed_Init()
    {
      this.IsDead = false;
      wedTransform.position = GameManagerData.GetInstance().SpwanPoint;
      this.stateMachine.switchState("idle");
      this.handEquipment.switchEquipment(GameManagerData.GetInstance().WEDcurEquipmentHand);
      this.backEquipment.switchEquipment(GameManagerData.GetInstance().WEDcurEquipmentBack);
    }
  }
}