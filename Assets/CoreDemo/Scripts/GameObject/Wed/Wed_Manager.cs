using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

namespace Core.Character
{
  public class Wed_Manager : Effective
  {
    //角色主控制脚本
    public Wed main;

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
      if (gameObject.tag == "Trap")
      {
        main.Wed_Die();
      }
    }

    protected override void processObjectExit(GameObject gameObject)
    {

    }

    protected override void processObjectUpdate()
    {

    }

  }


}

