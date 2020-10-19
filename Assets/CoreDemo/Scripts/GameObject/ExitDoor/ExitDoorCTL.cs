using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoorCTL : Core.Effective
{
  public bool Active;
  public bool IsDoorOpen;

  public GameObject interact;
  public Animator animator;
  // Start is called before the first frame update
  void Start()
  {
    IsDoorOpen = false;
    Active = false;
    interact.SetActive(false);
  }


  public void Activetrigger()
  {
    Active = true;
    interact.SetActive(true);
  }

  protected override void processObjectEnter(GameObject gameObject)
  {
    if (Active)
      if (gameObject.tag == "Player")
      {
        doorOpen();
      }

  }

  protected override void processObjectExit(GameObject gameObject)
  {
    if (Active)
      if (gameObject.tag == "Player")
      {
        doorClose();
      }

  }

  protected override void processObjectUpdate()
  {

  }

  void doorOpen()
  {
    animator.Play("doorOpen");
  }

  void doorClose()
  {
    animator.Play("doorClose");
  }




}
