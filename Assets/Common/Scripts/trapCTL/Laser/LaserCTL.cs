using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCTL : MonoBehaviour
{
  [Header("所属核")]
  public TrapCoreCTL belongTo;
  [Header("旋转速度")]
  public float rotateSpeed;
  [Header("最大旋转角度")]
  public float rotateMax = 60;
  [Header("射线的长度")]
  public float LaserLength;
  [Header("射线的Line")]
  public LineRenderer line;
  [Header("需要射线检测的图层")]
  public LayerMask layer;
  private int rotateDir;
  private float currentRotate = 0;

  private RaycastHit2D hit;
  void Start()
  {
    rotateDir = 1;
  }

  // Update is called once per frame
  void Update()
  {
    Debug.DrawRay(transform.position, transform.rotation * Vector3.up * 1000, Color.black);
  }

  private void FixedUpdate()
  {
    rotate();
    LaserRay();
  }

  void rotate()
  {

    transform.Rotate(new Vector3(0, 0, rotateDir * rotateSpeed));
    currentRotate += rotateDir * rotateSpeed;
    if (Mathf.Abs(currentRotate) >= rotateMax)
      rotateDir = -rotateDir;
  }

  void LaserRay()
  {
    hit = Physics2D.Raycast(transform.position, transform.rotation * Vector3.up, LaserLength, layer);
    if (hit.collider != null)
    {
      if (hit.collider.gameObject.tag == "Platform")
      {
        float dis = Vector2.Distance(hit.point, (Vector2)transform.position);
        this.line.SetPosition(1, new Vector3(0, dis, 0));
        //Debug.Log(dis);
      }
    }
  }

}
