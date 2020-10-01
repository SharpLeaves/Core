using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
  [Header("是否可复用")]
  public bool reusable;
  [Header("是否一次交互中需要重复使用")]
  public bool repeatable;
  [Header("交互标志的预制体")]
  public GameObject interactSign;
  //交互对象的碰撞箱
  protected Collider2D col;
  //交互标志出现的位置
  protected Vector3 signPosition;
  // Start is called before the first frame update
  void Start()
  {
    col = GetComponent<Collider2D>();
    setSignPosition();
    ExStart();
  }

  // Update is called once per frame
  void Update()
  {
    ExUpdate();
  }

  //设置交互按钮的位置
  private void setSignPosition()
  {
    this.signPosition = new Vector3(transform.position.x, transform.position.y + col.offset.y + col.bounds.size.y, 0);
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    //如果进入触发器的是Player
    if (other.gameObject.tag == "Player")
    {
      //生成交互标识
      GameObject sign = Instantiate(interactSign, signPosition, Quaternion.identity, this.transform);
    }

  }

  private void OnTriggerStayUpdate()
  {
    
  }
  private void OnTriggerStay2D(Collider2D other)
  {
    if (other.gameObject.tag == "Player")
    {
      //检测输入
      if (Input.GetKeyDown(KeyCode.E))
      {
        //检测到输入后执行需要的功能
        InteractFunction();
        if (!repeatable)
        {
          //执行完后删除标志提示
          foreach (Transform child in transform)
            Destroy(child.gameObject);
        }

        //如果不是可复用的，则destory脚本
        if (!reusable)
          Destroy(this);
      }


    }
  }

  private void OnTriggerExit2D(Collider2D other)
  {
    //如果离开触发器的是Player
    if (other.gameObject.tag == "Player")
    {
      //删除交互标识
      foreach (Transform child in transform)
        Destroy(child.gameObject);
    }
  }

  //子类需要重写交互功能
  protected abstract void InteractFunction();

  protected abstract void ExStart();

  protected abstract void ExUpdate();

}
