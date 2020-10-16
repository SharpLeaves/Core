using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

namespace Core.Character
{

  public class Wed_DeathJudgeBody : MonoBehaviour
  {
    public Wed main;

    public float horizontalMax = 5.0f;
    public float dashAdjust = 10.0f;

    public bool onDash = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        bool death = false;
        Rigidbody2D otherRigidbody = other.gameObject.GetComponentInChildren<Rigidbody2D>();
        if( otherRigidbody != null){
            if(otherRigidbody.tag == "Wall"){
            
            
                if(onDash){
                    if(Mathf.Abs(main.rigidbodyComponent.velocity.x - otherRigidbody.velocity.x) > horizontalMax + dashAdjust){
                        death = true;  
                    }
                }
                else{
                    if(Mathf.Abs(main.rigidbodyComponent.velocity.x - otherRigidbody.velocity.x) > horizontalMax){
                        death = true;  
                    }
                }

            
            }

        }


        

        if(death){
            main.Wed_Die();        
        }
    }

    private void LateUpdate(){
        onDash = false;
        
    }
  }
}

