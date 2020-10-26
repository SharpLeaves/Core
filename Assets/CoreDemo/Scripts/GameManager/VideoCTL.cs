using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
public class VideoCTL : MonoBehaviour
{
  private bool IsSwitch;
  private bool inputEnable;
  public VideoPlayer videoPlayer;
  // Start is called before the first frame update
  void Start()
  {
    IsSwitch = false;
    inputEnable = false;
    StartCoroutine(switchScene());
    StartCoroutine(InputEnable());
  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Space) && inputEnable)
    {
      videoPlayer.Stop();
      Core.GameManagerData.GetInstance().SwitchScene(1);
    }

  }

  IEnumerator switchScene()
  {
    yield return new WaitForSeconds(34);
    if (!IsSwitch)
      Core.GameManagerData.GetInstance().SwitchScene(1);
  }

  IEnumerator InputEnable()
  {
    yield return new WaitForSeconds(1.5f);
    inputEnable = true;
  }

}
