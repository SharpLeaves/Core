using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

namespace Core.Character
{

  public class Wed_DeathJudgeBottom : MonoBehaviour
  {
    public Wed main;

    public float verticalMax = 5.0f;


    private void OnTriggerEnter2D(Collider2D other)
    {
        bool death = false;
        Rigidbody2D otherRigidbody = other.gameObject.GetComponentInChildren<Rigidbody2D>();
        if( otherRigidbody != null){
            if(otherRigidbody.tag == "Wall"){
            
                if(main.upTester.IsGrounded){
                    if(otherRigidbody.velocity.y > verticalMax){
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

