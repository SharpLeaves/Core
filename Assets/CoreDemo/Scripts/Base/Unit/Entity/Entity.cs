using UnityEngine;

namespace Core{
    public abstract class Entity : MonoBehaviour{
        protected StateMachine stateMachine;
        public AnimatorController animationController;
        public Rigidbody2D rigidbodyComponent;

        protected abstract void StateMachineInit();

        public StateMachine GetStateMachine{
            get{
                return stateMachine;
            }
        }
    }
}
