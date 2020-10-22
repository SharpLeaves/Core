using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
public class SceneSwitchInteract : Core.InteractableC
{
  public int TargetSceneIndex;
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }


  protected override void processInteract()
  {
    GameManagerData.GetInstance().SwitchScene(TargetSceneIndex);
  }
}
