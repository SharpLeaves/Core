using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;


public abstract class EquipmentBase : MonoBehaviour
{
  protected StateMachine sm;
  protected Animator AnimCTL;
  public PlayerCTL player;

  public void SetPlayer(PlayerCTL p)
  {
    player = p;
  }

  private void Start()
  {
    this.AnimCTL = GetComponent<Animator>();
    ExStart();
  }
  //装备自己的额外的Start调用
  protected abstract void ExStart();
  //该装备额外的Update调用
  protected abstract void ExUpdate();
  //该装备的技能函数
  public abstract void Function();
  //该装备的名字
  public abstract string GetName();

}

public abstract class HandEquipment : EquipmentBase
{
  private void Update()
  {
    //这个要修改到状态机里面
    if (Input.GetKeyDown(KeyCode.X))
    {
      this.Function();
    }
    ExUpdate();
  }
}

public abstract class BackEquipment : EquipmentBase
{
  //这个要修改到状态机里面
  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.C))
    {
      this.Function();
    }
    ExUpdate();
  }
}


