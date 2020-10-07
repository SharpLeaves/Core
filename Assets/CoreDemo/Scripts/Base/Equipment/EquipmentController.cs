using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Character;

namespace Core{
    public class EquipmentController : MonoBehaviour{
        public Character_MainController main;
        protected IEquipment curEquipment;

        public void switchEquipment(IEquipment equipment){
            foreach( Transform child in transform){
                Destroy(child.gameObject);
            }

            IEquipment newEquipment = Instantiate(equipment, this.transform.position, this.transform.rotation, this.transform );
            curEquipment = newEquipment;
            curEquipment.setCharacter(main);
        }
    }
}