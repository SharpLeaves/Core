﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

public class WindRobot_Wind : Core.Effective
{

  public float windForce;

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }

  protected override void processObjectEnter(GameObject gameObject)
  {

  }

  protected override void processObjectExit(GameObject gameObject)
  {

  }

  protected override void processObjectUpdate()
  {
    foreach (GameObject gameObject in effectedObjects)
    {
      if (gameObject.tag == "Player")
      {
        gameObject.GetComponentInChildren<Core.Character.Wed>().physicsController.addForce(0, windForce);
      }
    }
  }
}
