using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapCoreCTL : Interactable
{
  [Header("下属的陷阱列表")]
  public List<TrapBase> TrapList;


  // Start is called before the first frame update
  protected override void ExStart()
  {

  }

  // Update is called once per frame
  protected override void ExUpdate()
  {

  }

  protected override void InteractFunction()
  {
    DisableAllTrap();
  }

  void DisableAllTrap()
  {
    foreach (TrapBase temp in TrapList)
    {
      temp.Disable();
    }
  }
}
