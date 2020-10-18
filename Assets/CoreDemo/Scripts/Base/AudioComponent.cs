using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
  public class AudioComponent : MonoBehaviour
  {

    public AudioSource audioSource;
    // Start is called before the first frame update
    public bool IsAutoPlay;

    private void Start()
    {
      if (IsAutoPlay)
        this.audioSource.Play();
    }
    public void Play()
    {
      audioSource.Play();
    }

    public void Play(string name, bool isLoop)
    {
      //这里目标文件处在 Resources/Sounds/目标文件name
      AudioClip clip = Resources.Load<AudioClip>("Sounds/" + name);
      audioSource.clip = clip;
      audioSource.loop = isLoop;
      audioSource.Play();
    }


    public void Stop()
    {
      audioSource.Stop();
    }
    public void PlayOneShot(string name, float vol)
    {
      AudioClip clip = Resources.Load<AudioClip>("Sounds/" + name);
      audioSource.PlayOneShot(clip, vol);
    }

    public void PlayOnPoint(string name, Vector2 position, float vol)
    {
      AudioClip clip = Resources.Load<AudioClip>("Sounds/" + name);
      if (position == null)
        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, vol);
      else
        AudioSource.PlayClipAtPoint(clip, position, vol);
    }
  }

}
