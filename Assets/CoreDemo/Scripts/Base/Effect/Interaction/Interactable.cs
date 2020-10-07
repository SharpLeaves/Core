using System.Collections;
using System.Collections.Generic;
using Core.Character;
using UnityEngine;

namespace Core{
    public abstract class InteractableC : Effective{
        // 全局可复用
        public bool reusable;
        // 单次交互可复用
        public bool repeatable;

        public GameObject interactSign;
        protected Vector3 signPosition;
        

        private void setSignPosition(){
            
            this.signPosition  = new Vector3(transform.position.x, 
            transform.position.y + col.offset.y + col.bounds.size.y/2, 0); 
        }
        
        override protected void processObjectUpdate(){
            foreach (GameObject gameObject in effectedObjects){
                if( gameObject.tag == "Player" ){
                    Character_InputController playerInput = gameObject.GetComponentInChildren<Character_InputController>();                    
                    if(playerInput.Interact){
                        processInteract();
                        if( !repeatable ){
                            foreach (Transform child in transform)
                                Destroy(child.gameObject);
                        }
                        if (!reusable)
                            Destroy(this);
                    }
                }
            }
        }

        protected override void processObjectEnter(GameObject gameObject){
            if (gameObject.tag == "Player"){
                setSignPosition();
                GameObject sign = Instantiate(interactSign, signPosition, Quaternion.identity, this.transform);
            }
        }

        protected override void processObjectExit(GameObject gameObject){
            if (gameObject.tag == "Player"){
                foreach (Transform child in transform)
                    Destroy(child.gameObject);
            }
        }

        protected abstract void processInteract();

    }
}
