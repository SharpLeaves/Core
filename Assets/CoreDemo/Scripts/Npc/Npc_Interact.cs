using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

namespace Core.Npc{
    public class Npc_Interact : InteractableC{
        public Creature main;
        protected override void processInteract(){
            main.GetStateMachine.switchState("eat");
        }

        protected override void processObjectEnter(GameObject gameObject){
            base.processObjectEnter(gameObject);
            Debug.Log("Enter");
        }
    }
}