using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundSwitch : Core.Effective
{
  [Header("cinemachineConfiner")]
  public Cinemachine.CinemachineConfiner cinemachineConfiner;
  [Header("边界collider")]
  public PolygonCollider2D _collider;
  [Header("复活之后需要恢复的边界")]
  public BoundSwitch BoundAfterDie;


  public int number;
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }


  protected override void processObjectEnter(GameObject gameObject)
  {
  }

  protected override void processObjectExit(GameObject gameObject)
  {
    if (gameObject.tag == "Player"
    && gameObject.transform.position.x > this.transform.position.x + this.col.offset.x + this.col.bounds.size.x)
    {
      setBound();
    }
  }

  protected override void processObjectUpdate()
  {

  }

  public void setBound()
  {
    cinemachineConfiner.m_BoundingShape2D = _collider;
    this.col.isTrigger = false;
    Core.GameManagerData.GetInstance().gameBoundNumber = this.BoundAfterDie.number;
  }


}
