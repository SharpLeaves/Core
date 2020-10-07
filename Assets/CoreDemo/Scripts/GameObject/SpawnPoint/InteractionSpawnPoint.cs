﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

public class InteractionSpawnPoint : InteractableC
{
  protected override void processInteract()
  {
    GameManager.GetInstance().SpwanPoint = this.transform.position;
  }
}