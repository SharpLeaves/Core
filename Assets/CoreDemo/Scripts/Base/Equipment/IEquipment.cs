using UnityEngine;
using Core.Character;

namespace Core{
    public abstract class IEquipment : Entity{
        public Wed main;
        public void setCharacter(Wed character){
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




