using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

namespace Core.Deer{
    public class Deer_Interact : InteractableC{
        public Deer main;
        protected override void processInteract(){
            main.GetStateMachine.switchState("eat");
            IEquipment equipment = main.container.getByName("Dash");
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
        }
    }
}