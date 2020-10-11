using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class PointLightCTL : MonoBehaviour
{
  public Light2D _light;
  [Header("闪烁频率")]
  public float flickerRate;
  [Header("最长闪烁时长")]
  public float flickerTimeMax;
  [Header("最短闪烁时长")]
  public float flickerTimeMin;
  [Header("最大亮度")]
  public float MaxIntensity;
  [Header("最小亮度")]
  public float MinIntensity;

  /* 当前亮度*/
  private float curIntensity;
  /* 一次闪烁是否正在进行 */
  private bool isFlicking;
  /* 本次闪烁的亮度 */
  private float IntensityTargetThisTime;
  /* 本次亮度增长速度 */
  private float IntensityIncreaseThisTime;


  // Start is called before the first frame update
  void Start()
  {

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
    if (isFlicking)
    {
      this.curIntensity += this.IntensityIncreaseThisTime;
      this._light.intensity = this.curIntensity;
      if (this.curIntensity >= this.IntensityTargetThisTime)
        isFlicking = false;

    }
  }

  void Init()
  {
    this.curIntensity = 0;
    isFlicking = false;
  }

  IEnumerator Timeout()
  {
    yield return new WaitForSeconds(1 / flickerRate);
    this.curIntensity = 0;
    this._light.intensity = this.curIntensity;
    IntensityTargetThisTime = Random.Range(MinIntensity, MaxIntensity);
    isFlicking = true;
  }

}
