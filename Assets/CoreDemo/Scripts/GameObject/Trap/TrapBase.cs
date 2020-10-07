using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

public abstract class TrapBase : Entity
{
  protected bool IsActive;
  public bool Active
  {
    set { this.IsActive = value; }
    get { return this.IsActive; }
  }

  public void Disable()
  {
    this.Active = false;
    FunctionOnDisable();
  }
  public abstract void FunctionOnDisable();


}
