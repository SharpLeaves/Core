using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

namespace Core.Character
{

  public class Wed_Manager : MonoBehaviour
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

    private void OnTriggerEnter2D(Collider2D other)
    {
      if (other.tag == "Trap")
      {
        main.Wed_Die();
      }
    }
  }


}

