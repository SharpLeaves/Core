using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

public class TrapCoreCTL : InteractableC
{
  [Header("下属的陷阱列表")]
  public List<TrapBase> TrapList;


  // Start is called before the first frame update

  protected override void processInteract()
  {
    DisableAllTrap();
  }

  void DisableAllTrap()
  {
    foreach (TrapBase trap in TrapList)
    {
      trap.Disable();
    }
  }
}
