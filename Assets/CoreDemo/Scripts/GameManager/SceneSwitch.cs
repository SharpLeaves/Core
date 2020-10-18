using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
public class SceneSwitch : Effective
{
  public int TargetSceneIndex;
  protected override void processObjectEnter(GameObject gameObject)
  {
    if (gameObject.tag == "Player")
    {
      GameManagerData.GetInstance().SwitchScene(TargetSceneIndex);
    }
  }

  protected override void processObjectExit(GameObject gameObject)
  {

  }

  protected override void processObjectUpdate()
  {

  }



}
