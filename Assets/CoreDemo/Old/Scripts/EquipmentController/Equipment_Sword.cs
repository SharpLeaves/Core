using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment_Sword : HandEquipment
{
  // Start is called before the first frame update
  // Update is called once per frame

  protected override void ExUpdate()
  {

  }
  protected override void ExStart()
  {
    Debug.Log("child");
  }
  public override void Function()
  {
    Debug.Log("sword func");
  }
  public override string GetName()
  {
    return "sword";
  }

}
