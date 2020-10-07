using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment_Package : BackEquipment
{
  public float PushSpeed;

  private bool usable;
  protected override void ExUpdate()
  {
    if (this.player.IsGround)
    {
      usable = true;
    }
  }
  protected override void ExStart()
  {
    Debug.Log("Package");
  }
  public override void Function()
  {
    if (usable)
    {
      this.player.rb.velocity = new Vector3(player.rb.velocity.x, this.PushSpeed);
      usable = false;
    }

  }
  public override string GetName()
  {
    return "package";
  }


}
