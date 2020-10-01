using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.StateController{
    [AddComponentMenu("Core/FSM/State")]

    public abstract class IState{
        protected StateMachine stateMachine;
        public StateMachine Container{
            get{
                return stateMachine;
            }
            set{
                stateMachine = value;
            }
        }

        public abstract void onEnter();
        public abstract void update();
        public abstract void onExit();
        public abstract string getName();

    }
}