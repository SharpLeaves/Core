using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Timer;

namespace Core.Timer{
    public class Hero : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                TimerManager.instance.addTask(new Task(1f, Foo));
            }
        }


        void Foo()
        {
            Debug.Log("nb");
        }
    }

}
