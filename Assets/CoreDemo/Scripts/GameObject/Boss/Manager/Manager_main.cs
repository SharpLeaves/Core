using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_main : MonoBehaviour
{

  public List<Manager_ArmCTL> Arms;

  public bool Active;

  // Start is called before the first frame update
  void Start()
  {
    Active = false;
  }

  // Update is called once per frame
  void Update()
  {

  }

  private void FixedUpdate()
  {

  }

  public void setActive(int index, bool active)
  {
    if (index >= Arms.ToArray().Length)
      Debug.LogWarning("超出范围");

    Arms[index].Active = active;

  }

  public void SetAllActive(bool active)
  {
    foreach (Manager_ArmCTL arm in Arms)
    {
      arm.Active = active;
    }
  }


}
