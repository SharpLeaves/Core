using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.StateController;
using Core.Animation;
using Core.Character;

namespace Core{
    public abstract class Entity : MonoBehaviour{
        protected StateMachine stateMachine;
        public AnimatorController animationController;
        public Rigidbody2D rigidbodyComponent;
    }
}
