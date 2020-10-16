using UnityEngine;
using Core;
using Site;

namespace Core.Dog{
    public class DiskTop_Effective : Effective{
        public DiskTop main;

        

        protected override void processObjectUpdate(){
            IronBlock[] blocks = this.main.rigidbodyComponent.GetComponentsInChildren<IronBlock>();
            if(main.search){
                foreach(IronBlock block in blocks){
                    block.rigidbodyComponent.simulated = false;
                }
            }

            if(main.GetStateMachine.curState.getName() ==  "active"){
                foreach(GameObject gameObject in effectedObjects){
                    Creature creature = gameObject.GetComponentInChildren<Creature>();
                    if(creature != null){
                        creature.physicsController.setForce(0,this.main.power);
                        creature.physicsController.setDamp(this.main.addAirDamp,0);

                        IronBlock block = gameObject.GetComponentInChildren<IronBlock>();
                        if(block != null ){
                            if(block.upTester.IsGrounded ){
                                block.rigidbodyComponent.transform.parent = this.main.rigidbodyComponent.transform;
                                block.rigidbodyComponent.transform.gameObject.layer = 9;
                            }
                        }
                    }
                }
            }
            
            if(main.GetStateMachine.curState.getName() == "normal"){

                foreach(IronBlock block in blocks){
                    block.rigidbodyComponent.transform.gameObject.layer = 8;

                    block.rigidbodyComponent.simulated = true;
                    block.rigidbodyComponent.transform.parent = GameObject.Find("Blocks").transform;
                    
                }
            }
        }

        protected override void processObjectExit(GameObject gameObject){
        }

        protected override void processObjectEnter(GameObject gameObject){
        }
    }
}