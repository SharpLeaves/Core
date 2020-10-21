using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

public class StorySystem_Point : Effective
{
  // Start is called before the first frame update

  [Header("本次剧情需要的对话")]
  public TextAsset text;
  [Header("是否自动触发")]
  public bool IsAuto;
  private void Start()
  {

  }

  protected override void processObjectEnter(GameObject gameObject)
  {
    if (IsAuto)
    {
      if (gameObject.tag == "Player")
      {
        GameManagerData.GetInstance().StartStory(text);
        Destroy(this.gameObject);
        //Core.AudioManager._instance.PlayMusicByName("depressBGM1");
      }
    }
  }

  protected override void processObjectExit(GameObject gameObject)
  {

  }

  protected override void processObjectUpdate()
  {

  }

  public void Dialog()
  {
    GameManagerData.GetInstance().StartStory(text);
  }
}
