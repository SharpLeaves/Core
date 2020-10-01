using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Core.Timer{
    public class Task{
        public float cd;
        public UnityAction function;

        public Task(float cd, UnityAction function){
            this.cd = cd;
            this.function = function;
        }
    }
}