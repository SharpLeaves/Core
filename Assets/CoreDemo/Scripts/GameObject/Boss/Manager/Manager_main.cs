using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Manager_main : MonoBehaviour
{
  //激光手臂序列
  public List<Manager_ArmCTL> Arms;

  //是否被激活
  public bool Active;
  //核
  public CoreCTL core;
  //是否被净化
  public bool IsPure;
  //被净化后的动画
  public Animator BossPuritiedAnimator;
  //核的灯效
  public Light2D _light;
  // Start is called before the first frame update
  void Start()
  {
    Active = false;
    IsPure = false;
    this.core.gameObject.SetActive(false);
  }

  // Update is called once per frame
  void Update()
  {

  }

  private void FixedUpdate()
  {
    if (this.IsPure == false && this.core.IsPure == true && Active)
    {
      this.AfterPure();
      this.IsPure = true;
    }

    if (this.BossPuritiedAnimator.GetCurrentAnimatorStateInfo(0).IsName("Animation_Boss_Puritied")
        && this.BossPuritiedAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
    {
      Core.GameManagerData.GetInstance().SwitchScene(3);
    }
  }

  public void setArmActive(int index, bool active)
  {
    if (index >= Arms.ToArray().Length)
      Debug.LogWarning("超出范围");

    Arms[index].Active = active;

  }

  public void SetAllActive(bool active)
  {
    foreach (Manager_ArmCTL arm in Arms)
    {
      arm.SetActive();
    }
  }

  public void SetActive()
  {
    this.core.gameObject.SetActive(true);
    SetAllActive(true);
    Active = true;
  }
  public void AfterPure()
  {
    foreach (Manager_ArmCTL x in Arms)
      x.SetPuritied();
    this.BossPuritiedAnimator.Play("Animation_Boss_Puritied");
    this._light.color = new Color(0, 0.7f, 1, 1);
    Core.AudioManager._instance.PlayAudioByName("Core_Puritied", this.core.transform.position);
  }

}
