using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_BreakBoss0 : Core.InteractableC
{
  public StorySystem_Point storySystem_Point;
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }

  protected override void processInteract()
  {
    this.storySystem_Point.Dialog();
  }
}
