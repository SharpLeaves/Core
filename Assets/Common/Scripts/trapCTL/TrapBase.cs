using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TrapBase : MonoBehaviour
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
