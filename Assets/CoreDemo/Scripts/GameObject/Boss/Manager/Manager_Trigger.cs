using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Manager_Trigger : MonoBehaviour
{
  public Light2D RoomLight;
  public Manager_main main;

  private float LightTargetIntensity = 0.8f;

  private bool IsStart;
  // Start is called before the first frame update
  void Start()
  {
    IsStart = false;
  }

  // Update is called once per frame
  void Update()
  {

  }

  private void FixedUpdate()
  {
    if (IsStart && this.RoomLight.intensity <= LightTargetIntensity)
      this.RoomLight.intensity += LightTargetIntensity * Time.deltaTime;
    else if (this.RoomLight.intensity >= LightTargetIntensity)
      Destroy(this);
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.tag == "Player")
    {
      main.SetAllActive(true);
      IsStart = true;
    }
  }
}
