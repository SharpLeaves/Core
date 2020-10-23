using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class WIndRobotCTL : MonoBehaviour
{
  public CoreCTL core;

  public Light2D _light;

  //public Core.Character.Wed wed;

  public WindRobot_Wind wind;
  private bool IsPure;
  // Start is called before the first frame update
  void Start()
  {
    IsPure = false;
    wind.Active = false;
    wind.gameObject.SetActive(false);
  }

  // Update is called once per frame
  void Update()
  {

  }

  private void FixedUpdate()
  {
    if (core.IsPure == true && !IsPure)
    {
      IsPure = true;
      AfterPure();
    }
  }


  void AfterPure()
  {
    this._light.color = new Color(0, 0.7f, 1, 1);
    wind.Active = true;
    wind.gameObject.SetActive(true);
  }
}
