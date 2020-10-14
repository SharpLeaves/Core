using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WasteFloat : MonoBehaviour
{
  [Header("浮动速度")]
  public float floatSpeed;
  [Header("浮动距离")]
  public float floatDistance;

  private int floatDir;

  private float curFloatDistance;

  // Start is called before the first frame update
  void Start()
  {
    curFloatDistance = 0;
    floatDir = 1;
  }

  // Update is called once per frame
  void Update()
  {

  }

  private void FixedUpdate()
  {
    Float();
  }


  void Float()
  {
    transform.Translate(0, floatSpeed * Time.deltaTime * floatDir, 0);
    curFloatDistance += floatSpeed * Time.deltaTime;
    if (curFloatDistance >= floatDistance)
    {
      floatDir = -floatDir;
      curFloatDistance = 0;
    }
  }
}
