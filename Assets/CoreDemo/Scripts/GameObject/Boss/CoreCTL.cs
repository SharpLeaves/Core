using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
public class CoreCTL : Effective
{
  public bool IsPure;



  // Start is called before the first frame update
  void Start()
  {
    IsPure = false;
  }

  // Update is called once per frame
  void Update()
  {

  }


  protected override void processObjectEnter(GameObject gameObject)
  {
    if (gameObject.tag == "pure")
    {
      this.IsPure = true;
    }

  }

  protected override void processObjectExit(GameObject gameObject)
  {

  }

  protected override void processObjectUpdate()
  {

  }
}
