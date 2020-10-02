using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LabelVisual : MonoBehaviour
{
  [Header("字体变换速度")]
  public float TransSpeed = 0.05f;

  private Text label;
  private float alpha;
  private Color oricolor;
  private bool dir = false;
  // Start is called before the first frame update
  void Start()
  {
    label = GetComponent<Text>();
    oricolor = label.color;
    alpha = label.color.a;
  }

  // Update is called once per frame
  void FixedUpdate()
  {
    setAlpha();
  }

  void setAlpha()
  {
    if (this.alpha >= 1.0f) dir = false;
    else if (this.alpha <= 0.1f) dir = true;
    if (dir) alpha += TransSpeed;
    else alpha -= TransSpeed;
    label.color = new Color(oricolor.r, oricolor.g, oricolor.b, alpha);
  }
}
