﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core{
  public class AudioManager : MonoBehaviour{

    public AudioSource audiosource;

    public static AudioManager _instance;
    void Awake(){
      audiosource = gameObject.AddComponent<AudioSource>();

      audiosource.playOnAwake = false;  //playOnAwake设为false时，通过调用play()方法启用
      audiosource.loop = true;
      audiosource.volume = 0.05f;

      _instance = this; //通过Sound._instance.方法调用
    }

    //在指定位置播放音频 PlayClipAtPoint()
    public void PlayAudioByName(string name, Vector2 position){
      //这里目标文件处在 Resources/Sounds/目标文件name
      AudioClip clip = Resources.Load<AudioClip>("Sounds/" + name);
      if (position == null)
        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
      else
        AudioSource.PlayClipAtPoint(clip, position);
    }

    //如果当前有其他音频正在播放，停止当前音频，播放下一个
    public void PlayMusicByName(string name, float vol){
      AudioClip clip = Resources.Load<AudioClip>("Sounds/" + name);

      if (audiosource.isPlaying){
        audiosource.Stop();
      }
      audiosource.volume = vol;
      audiosource.clip = clip;
      audiosource.Play();
    }
  }
}

