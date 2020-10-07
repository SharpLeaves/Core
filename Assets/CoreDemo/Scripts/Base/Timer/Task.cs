﻿using UnityEngine;
using UnityEngine.Events;

namespace Core{
    public class Task{
        public float cd;
        public UnityAction function;

        public Task(float cd, UnityAction function){
            this.cd = cd;
            this.function = function;
        }
    }
}