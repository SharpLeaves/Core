using UnityEngine;
using Core;

namespace Core.Dog{
    public class DiskTop_Effective : Effective{
        public DiskTop main;

        protected override void processObjectUpdate(){
            if(main.GetStateMachine.curState.getName() ==  "active"){
                Debug.Log("DiskTop : active");
                foreach(GameObject gameObject in effectedObjects){
                    Creature creature = gameObject.GetComponentInChildren<Creature>();
                    if(creature != null){
                        Debug.Log(creature.name);
                        creature.physicsController.addForce(0,this.main.power);
                    }
                }
            }
        }

        protected override void processObjectExit(GameObject gameObject){

        }

        protected override void processObjectEnter(GameObject gameObject){

        }
        
    }
}