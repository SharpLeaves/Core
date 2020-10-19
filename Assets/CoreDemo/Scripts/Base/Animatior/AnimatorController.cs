using UnityEngine;

namespace Core
{
  [AddComponentMenu("Core/AnimationController")]
  public class AnimatorController : MonoBehaviour
  {
    public Animator animator;
    public AnimatorStateInfo animInfo { set; get; }
    private string curPlay;
    private float playSpeed = 1.0f;

    public string play
    {
      get
      {
        return curPlay;
      }
      set
      {
        curPlay = value;
      }
    }

    public float speed
    {
      get
      {
        return playSpeed;
      }
      set
      {
        playSpeed = value;
      }
    }

    private bool overrideThisFrame = false;
    public void OverrideThisFrame()
    {
      overrideThisFrame = true;
    }

    private void Update()
    {
      if(!overrideThisFrame){
        animator.speed = playSpeed;
        animator.Play(curPlay);
        animInfo = animator.GetCurrentAnimatorStateInfo(0);
      }

      overrideThisFrame = false;
    }

    // 自适应动画播放速度		
    private void AdaptAnimationSpeedToMatchVelocity(float a_fNormalSpeedVelocity, float a_fCurrentSpeed)
    {
      float fAnimationSpeedPercent = a_fCurrentSpeed / a_fNormalSpeedVelocity;
      animator.speed = fAnimationSpeedPercent;
    }
  }
}
