using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using Core;

public class LightFlickStable : MonoBehaviour
{
  public Light2D _light;

  public float Flickrate;
  private float lightIntensity;
  public float stableTimeMax = 8.0f;
  public float stableTimeMin = 2.0f;
  public float flickTime = 0.5f;

  private float stableTimer;
  private float flickTimer;
  private float closeTimer;


  private bool isFlick = false;
  private bool isStable = true;
  private bool isClose = false;

  public float closeQOn = 0.2f;



  void Start()
  {
    Init();
    //Core.AudioManager._instance.PlayAudioByName("light_flick2", this.transform.position);
  }


  private void FixedUpdate()
  {
    if(isStable){
      stableTimer -= Time.fixedDeltaTime;
      this._light.intensity = this.lightIntensity;
      if(stableTimer < 0){
        flickTimer = flickTime;
        isStable = false;
        isFlick = true;
      }
    }

    if(isFlick){
      flickTime -= Time.fixedDeltaTime;
      lightFlick();
      if(flickTime < 0){
        float randQ = Random.Range(0.1f, 1.0f);
        if(randQ > closeQOn){

          float rand = Random.Range(stableTimeMin, stableTimeMax);
          stableTimer = rand; 
          isStable = true;
          isFlick = false;
        }
        else{
          float rand = Random.Range(stableTimeMin/2, stableTimeMin);
          closeTimer = rand; 
          isClose = true;
          isFlick = false;
        }

        
      }
    }

    if(isClose){
      closeTimer -= Time.fixedDeltaTime;
      this._light.intensity = 0;
      if(closeTimer < 0){
        flickTimer = flickTime;
        isClose = false;
        isFlick = true;
      }
    }
    


  }

  void lightFlick()
  {
    float rand = Random.Range(0, 100) / 100f;
    if (rand >= Flickrate)
    {
      
      this._light.intensity = this.lightIntensity;
    }
    else
    {
      this._light.intensity = 0;
    }
  }

  void Init()
  {
    float rand = Random.Range(0, 10);
    this.stableTimer = rand;
    this.lightIntensity = this._light.intensity;
  }

}