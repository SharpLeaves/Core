using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using Core;
using Core.Character;


public class LightFollow : MonoBehaviour
{
    public Light2D _light;
    public Wed aimAt;
    public Rigidbody2D gate;


    private bool warning = false;
    public float alertX = 30.0f;

    private float t = 1.0f;


    void Start()
    {

    }


    private void FixedUpdate()
    {
        float dis = aimAt.rigidbodyComponent.position.x - this.transform.position.x;
        if(dis > -alertX && dis < 5.0f){

            
            float degree = 180 + Mathf.Atan2(dis,17)/Mathf.PI * 180;

            Quaternion targetRotation = Quaternion.Euler(0.0f,0.0f,degree);

            // t+=Time.fixedDeltaTime;


            this._light.transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, t);
    

            warning = true;

        }
        else{
            warning = false;
        }


        if(warning){
            this._light.intensity = 1.5f;
        }
        else{
            this._light.intensity = 0;
            gate.AddForce(new Vector2(0,50));
        }
    }


}