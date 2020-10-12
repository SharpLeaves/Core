using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

public class StorySystem_Point : Effective
{
  // Start is called before the first frame update

  [Header("本次剧情需要的对话")]
  public TextAsset text;
  private void Start()
  {

  }

  protected override void processObjectEnter(GameObject gameObject)
  {
    //Debug.Log("111");
    if (gameObject.tag == "Player")
    {
      GameManagerData.GetInstance().StartStory(text);
      Destroy(this.gameObject);
    }

  }

  protected override void processObjectExit(GameObject gameObject)
  {

  }

  protected override void processObjectUpdate()
  {

  }
}
