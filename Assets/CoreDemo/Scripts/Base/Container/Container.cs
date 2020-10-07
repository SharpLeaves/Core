using System.Collections.Generic;
using UnityEngine;

namespace Core{
    public class Container : MonoBehaviour{
        public List<IEquipment> equipmentList;

        public IEquipment getByName(string name){
            foreach(IEquipment equipment in equipmentList){
                if(equipment.getName() == name)
                    return equipment;
            }
            return null;
        }

        public void removeByName(string name){
            foreach(IEquipment equipment in equipmentList){
                if(equipment.getName() == name)
                    equipmentList.Remove(equipment);
            }
        }

        public void add(IEquipment equipment){
            equipmentList.Add(equipment);
        }
    }
}