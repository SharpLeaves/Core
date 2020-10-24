using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using Core;
using Core.Dog;

public class DogLight : MonoBehaviour
{
    public Dog dog;
    public Light2D core;
    public Light2D effect;

    public float coreMinIntensity = 0.0f;
    public float coreMaxIntensity = 0.5f;

    public float effectMinIntensity = 0.0f;
    public float effectMaxIntensity = 0.5f;

    public float effectMaxOpacity = 1.0f;


    void Start()
    {

    }


    private void FixedUpdate()
    {
        switch (dog.GetStateMachine.curState.getName()){
            case "normal":
                break;
            case "powerdecrease":
                if(effect.intensity < effectMaxIntensity){
                    Debug.Log("increase");
                    effect.intensity += 0.01f;
                }
                break;
            case "powerincrease":
                if(core.intensity < coreMaxIntensity){
                    core.intensity += 0.01f;
                }
                break;
            case "chargestart":
                if(effect.intensity > effectMinIntensity){
                    effect.intensity -= 0.01f;
                }

                if(core.intensity > coreMinIntensity){
                    core.intensity -= 0.01f;
                }
                break;
            case "chargeover":
                break;
        }
    }



}
