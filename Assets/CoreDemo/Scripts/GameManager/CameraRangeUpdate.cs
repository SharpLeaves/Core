using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraRangeUpdate : Core.Effective
{
  public float TargetSize;
  public Cinemachine.CinemachineVirtualCamera cinemachineVirtualCamera;

  public float currentSize;

  private bool IsUpdate;

  private float Increase;

  // Start is called before the first frame update
  void Start()
  {
    this.currentSize = cinemachineVirtualCamera.m_Lens.OrthographicSize;
    IsUpdate = false;
  }

  // Update is called once per frame
  void Update()
  {

  }

  private void FixedUpdate()
  {
    if (IsUpdate)
      UpdateRange();
  }


  void UpdateRange()
  {
    this.cinemachineVirtualCamera.m_Lens.OrthographicSize += Increase * Time.deltaTime;
    if (this.cinemachineVirtualCamera.m_Lens.OrthographicSize >= this.TargetSize)
    {
      Destroy(this);
    }
  }

  void UpdateTrigger()
  {
    Increase = this.TargetSize - this.cinemachineVirtualCamera.m_Lens.OrthographicSize;
    this.IsUpdate = true;
  }


  protected override void processObjectEnter(GameObject gameObject)
  {
    if (gameObject.tag == "Player")
      this.UpdateTrigger();
  }

  protected override void processObjectExit(GameObject gameObject)
  {

  }

  protected override void processObjectUpdate()
  {

  }

}
