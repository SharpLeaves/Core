using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightFlick : MonoBehaviour
{
  public Light2D _light;

  public float Flickrate;
  private float lightIntensity;


  void Start()
  {
    Init();
    //Core.AudioManager._instance.PlayAudioByName("light_flick2", this.transform.position);
  }


  private void FixedUpdate()
  {
    lightFlick();

  }

  void lightFlick()
  {
    float rand = Random.Range(0, 100) / 100f;
    Debug.Log(rand);
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
    this.lightIntensity = this._light.intensity;
  }

}