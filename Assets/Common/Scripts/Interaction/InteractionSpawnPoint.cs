﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionSpawnPoint : Interactable
{
  protected override void ExStart()
  {

  }

  protected override void ExUpdate()
  {

  }
  protected override void InteractFunction()
  {
    GameManager.GetInstance().SpwanPoint = this.transform.position;
  }
}