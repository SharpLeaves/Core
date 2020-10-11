using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightEffect : MonoBehaviour
{
  public Light2D _light;

  public float Flickrate;
  private float lightIntensity;


  // Start is called before the first frame update
  void Start()
  {
    Init();
  }

  // Update is called once per frame
  void Update()
  {

  }

  private void FixedUpdate()
  {
    LightFlick();
  }

  void LightFlick()
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
    this.lightIntensity = this._light.intensity;
  }

}