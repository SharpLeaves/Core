using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
using UnityEngine.Experimental.Rendering.Universal;
public class TrapCoreCTL : MonoBehaviour
{
  [Header("下属的陷阱列表")]
  public List<TrapBase> TrapList;
  [Header("core")]
  public CoreCTL core;

  public GameObject redCore;

  public Light2D _light;

  private bool isPured;


  // Start is called before the first frame update

  private void Start()
  {
    isPured = false;
  }

  private void FixedUpdate()
  {
    if (core.IsPure == true && this.isPured == false)
    {
      this.isPured = true;
      this.DisableAllTrap();
      this.redCore.SetActive(false);
      this._light.color = new Color(0, 0.7f, 1, 1);
    }
  }



  void DisableAllTrap()
  {
    foreach (TrapBase trap in TrapList)
    {
      trap.Disable();
    }
  }
}
