using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionTest : Interactable
{
  [Header("角色对象")]
  public PlayerCTL player;
  protected override void ExStart()
  {

  }

  protected override void ExUpdate()
  {

  }
  protected override void InteractFunction()
  {
    GetComponent<DialogSystem>().Dialog(this.transform.position);
  }


}
