using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.StateController;
using Core.Animation;
using Core.Character;

namespace Core{
    public abstract class IEquipment : Entity{
        public Character_MainController main;
        public void setPlayer(Character_MainController character){
            main = character;
        }
        public abstract void function();
        public abstract string getName();
    }

    public abstract class IEquipmentHand : IEquipment{
        protected void FixedUpdate(){
            if( main.inputController.OffHand ){
                function();
            }
        }
    }

    public abstract class IEquipmentBack : IEquipment{
        protected void FixedUpdate(){
            if( main.inputController.Special ){
                function();
            }
        }
    }
}




