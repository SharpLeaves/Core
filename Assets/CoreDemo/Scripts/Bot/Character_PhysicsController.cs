using UnityEngine;
using System.Collections;

namespace Core.Character
{
  [AddComponentMenu("Core/Character/PhysicsController")]
  public class Character_PhysicsController : MonoBehaviour
  {
    public Character_MainController main;

    /* 物理控制参数 */
    private bool brakeHorizontal = false;
    private bool brakeVertical = false;
    private Vector2 applyVelocity = new Vector2(0.0f, 0.0f);
    private Vector2 applyForce = new Vector2(0.0f, 0.0f);
    private Vector2 applyDamping = new Vector2(0.0f, 0.0f);
    private Vector2 applyPosition = new Vector2(0.0f, 0.0f);

    /* 摩擦参数 */
    public float groundDamping = 80.0f;
    public float airDamping = 40.0f;

    /* 重力参数 */
    public float gravityScale;
    // 默认重力
    public float normalGravityScale = 1.25f;





    public Vector2 Velocity
    {
      get
      {
        return main.rigidbodyComponent.velocity;
      }
      set
      {
        main.rigidbodyComponent.velocity = value;
      }
    }
    public Vector2 Position
    {
      get
      {
        return main.rigidbodyComponent.transform.position;
      }
      set
      {
        main.rigidbodyComponent.transform.position = value;
      }
    }

    public void addForce(float x, float y)
    {
      applyForce.x += x;
      applyForce.y += y;
    }
    public void addVelocity(float x, float y)
    {
      applyVelocity.x += x;
      applyVelocity.y += y;
    }
    public void addPosition(float x, float y)
    {
      applyPosition.x += x;
      applyPosition.y += y;
    }
    public void addDamp(float x, float y)
    {
      applyDamping.x += x;
      applyDamping.y += y;
    }
    public void setHorizontalBrake(bool b)
    {
      brakeHorizontal = b;
    }
    public void setVerticalBrake(bool b)
    {
      brakeVertical = b;
    }




    private void Awake()
    {
      gravityScale = normalGravityScale;
    }

    // 刚体受物理系统影响与否
    public void disable()
    {
      enabled = false;
      main.rigidbodyComponent.isKinematic = true;
    }
    public void enable()
    {
      enabled = true;
      main.rigidbodyComponent.isKinematic = false;
    }

    private void microAdjust()
    {
      Vector2 velocity = main.rigidbodyComponent.velocity;
      if (Mathf.Abs(velocity.x) < 0.03f)
        velocity.x = 0;
      main.rigidbodyComponent.velocity = velocity;
    }

    private void processBrake()
    {
      Vector2 velocity = main.rigidbodyComponent.velocity;
      if (brakeHorizontal)
      {
        velocity.x = 0;
      }

      if (brakeVertical)
      {
        velocity.y = 0;
      }
      main.rigidbodyComponent.velocity = velocity;
    }

    private void processDamping()
    {
      Vector2 velocity = main.rigidbodyComponent.velocity;
      if (main.groundedTester.IsGrounded)
      {
        velocity.x -= groundDamping * velocity.x * Time.fixedDeltaTime;
      }
      else
      {
        velocity.x -= airDamping * velocity.x * Time.fixedDeltaTime;
      }
      velocity -= applyDamping * velocity.x * Time.fixedDeltaTime;

      main.rigidbodyComponent.velocity = velocity;
    }

    private void processPhysics()
    {
      Vector2 velocity = main.rigidbodyComponent.velocity;
      velocity += applyVelocity;
      velocity += applyForce * Time.fixedDeltaTime;

      main.rigidbodyComponent.velocity = velocity;
    }

    private void processPosition()
    {
      Vector2 position = main.rigidbodyComponent.transform.position;
      position += applyPosition;

      main.rigidbodyComponent.transform.position = position;
    }

    private void processGravityModification()
    {
      main.rigidbodyComponent.gravityScale = gravityScale;
    }

    private void after()
    {
      brakeHorizontal = false;
      brakeVertical = false;

      applyDamping.x = 0;
      applyDamping.y = 0;

      applyPosition.x = 0;
      applyPosition.y = 0;

      applyVelocity.x = 0;
      applyVelocity.y = 0;
      applyForce.x = 0;
      applyForce.y = 0;

      gravityScale = normalGravityScale;
    }

    private void FixedUpdate()
    {
      processPosition();
      processGravityModification();
      processBrake();
      // Vector2 velocity = main.rigidbodyComponent.velocity;
      // applyForce.x = 30;
      // applyForce.y = 0;
      // velocity += applyVelocity;
      // velocity += applyForce * Time.fixedDeltaTime;

      // main.rigidbodyComponent.velocity = velocity;
      processPhysics();
      processDamping();
      microAdjust();
      after();
    }


    /* 这块跳跃优化暂时弃用 状态机可能还会面临一次微调 */
    // public void CanJump(float a_fDuration)
    // {
    // 	m_fCanJumpTimeRemaining = a_fDuration;
    // }
    // public void Jump(){

    // }
    // private void ProcessJump(){
    // 	float willJumpTimeRemaining = 0;
    // 	float canJumpTimeRemaining = 0;
    // 	bool bGetJump = characterInput.Jump;

    // 	// 悬空但按下跳跃键，刷新将要跳跃计时
    // 	if(bGetJump && main.groundedTester.IsGrounded == false){
    // 		willJumpTimeRemaining = earlyJumpToleranceDuration;
    // 	}
    // 	// 衰减，保持一定时间内落地即跳跃
    // 	if(willJumpTimeRemaining > 0){
    // 		willJumpTimeRemaining -= Time.fixedDeltaTime;
    // 	}

    // 	// 着地状态，刷新能跳跃状态
    // 	if(main.groundedTester.IsGrounded){
    // 		canJumpTimeRemaining = lateJumpToleranceDuration;
    // 	}
    // 	// 离地衰减，在离地一段时间内准许跳跃
    // 	if(canJumpTimeRemaining > 0){ 
    // 		canJumpTimeRemaining -= Time.fixedDeltaTime;
    // 	}

    // 	// 处理是否跳跃逻辑
    // 	if(main.groundedTester.IsGrounded || canJumpTimeRemaining > 0){
    // 		if(bGetJump || willJumpTimeRemaining > 0){
    // 			willJumpTimeRemaining = 0.0f;
    // 			canJumpTimeRemaining = 0.0f;

    // 			Vector2 position = main.rigidbodyComponent.transform.position;
    // 			position.y += 0.05f;
    // 			main.rigidbodyComponent.transform.position = position;

    // 			Vector2 f2Velocity = main.rigidbodyComponent.velocity;
    // 			f2Velocity.y = jump;
    // 			main.rigidbodyComponent.velocity = f2Velocity;
    // 		}
    // 	}
    // }
    public System.Action onJump;

  }
}
