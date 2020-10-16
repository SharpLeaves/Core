using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundSwitchManager : MonoBehaviour
{
  public List<BoundSwitch> BoundSwitches;
  // Start is called before the first frame update
  void Awake()
  {
    setNumber();
  }

  // Update is called once per frame
  void Update()
  {

  }

  public void SetBoundByNumber(int number)
  {
    if (number >= 0)
      BoundSwitches[number].setBound();
  }

  public void setNumber()
  {
    for (int i = 0; i < BoundSwitches.ToArray().Length; i++)
    {
      BoundSwitches[i].number = i;
    }
  }
}
