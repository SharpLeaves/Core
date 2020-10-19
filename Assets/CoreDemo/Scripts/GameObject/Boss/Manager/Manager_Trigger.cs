using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_Trigger : MonoBehaviour
{
  public Manager_main main;
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.tag == "Player")
    {
      main.SetAllActive(true);
    }
  }
}
