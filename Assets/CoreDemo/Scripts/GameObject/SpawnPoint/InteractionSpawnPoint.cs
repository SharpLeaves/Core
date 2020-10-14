﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

public class InteractionSpawnPoint : InteractableC
{
  public StorySystem_Point storySystem_Point;
  protected override void processInteract()
  {
    GameManagerData.GetInstance().SpwanPoint = this.transform.position;
    this.storySystem_Point.Dialog();
  }
}