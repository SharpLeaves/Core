﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoorInteract : Core.InteractableC
{
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
    Core.GameManagerData.GetInstance().SwitchScene(4);
  }
}
