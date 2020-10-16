using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

namespace Core.Character
{

  public class Wed_DeathJudgeTop : MonoBehaviour
  {
    public Wed main;

    public float verticalMax = 30.0f;
    public float verticalGroundMax = 10.0f;


    private void OnTriggerEnter2D(Collider2D other)
    {
        bool death = false;
        Rigidbody2D otherRigidbody = other.gameObject.GetComponentInChildren<Rigidbody2D>();
        if( otherRigidbody != null){
            if(otherRigidbody.tag == "Wall"){
            

                if(main.groundedTester.IsGrounded){
                    if(Mathf.Abs(main.rigidbodyComponent.velocity.y - otherRigidbody.velocity.y) > verticalGroundMax){
                        death = true;  

                    }
                }
                else{
                    if(Mathf.Abs(main.rigidbodyComponent.velocity.y - otherRigidbody.velocity.y) > verticalMax){
                        death = true;  

                    }
                }
            
            }

        }


        

        if(death){
            main.Wed_Die();        
        }
    }
  }
}

