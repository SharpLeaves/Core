using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
public class LightBreath : MonoBehaviour
{
  public Light2D _light;
  /* 最小亮度 */
  public float minIntensity;
  /* 最大亮度 */
  public float maxIntensity;
  /* 每次的呼吸时间 */
  public float breathTime;
  /* 是否呼吸 */
  public bool IsBreath;
  private int breathDir;
  /* 当前亮度 */
  private float curIntensity;


  // Start is called before the first frame update
  void Start()
  {
    IsBreath = true;
    breathDir = 1;
    curIntensity = minIntensity;
  }

  // Update is called once per frame
  void Update()
  {

  }

  private void FixedUpdate()
  {
    if (IsBreath)
      breath();
  }

  private void breath()
  {
    if (curIntensity >= maxIntensity)
      breathDir = -1;
    if (curIntensity <= minIntensity)
      breathDir = 1;

    this.curIntensity += breathDir * ((maxIntensity - minIntensity) / breathTime);
    this._light.intensity = curIntensity;
  }


}
