using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

namespace Core.Test{
    public class Npc_Interact : InteractableC{
        public Npc_MainController main;
        protected override void processInteract(){
            main.GetStateMachine.switchState("eat");
            IEquipment equipment = main.container.getByName("Dash");
            Debug.Log(equipment.getName());
            foreach (GameObject gameObject in effectedObjects){
                if( gameObject.tag == "Player" ){
                    EquipmentController[] equipmentControllers = gameObject.GetComponentsInChildren<EquipmentController>();
                    foreach(EquipmentController equipmentController in equipmentControllers){
                        if(equipmentController.name == "BackEquipment"){
                            equipmentController.switchEquipment(equipment);
                        }
                    }
                }
            }
        }

        protected override void processObjectEnter(GameObject gameObject){
            base.processObjectEnter(gameObject);
            Debug.Log("Enter");
        }
    }
}