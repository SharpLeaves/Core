using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
public class BGMPoint : Effective
{
  [Header("音乐文件名称")]
  public string MusicName;
  [Header("音乐音量")]
  public float vol;

  public string sceondBGM;
  protected override void processObjectEnter(GameObject gameObject)
  {
    AudioManager._instance.PlayMusicByName(MusicName, vol);
    GameManagerData.GetInstance().curBGM = sceondBGM;
    GameManagerData.GetInstance().curVol = vol;
    Destroy(this);
  }

  protected override void processObjectExit(GameObject gameObject)
  {

  }

  protected override void processObjectUpdate()
  {

  }
}
