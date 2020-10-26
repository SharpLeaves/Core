using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UIInput : MonoBehaviour
{
  public Canvas canvas;
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }

  public void LoadChapter0()
  {
    Core.GameManagerData.GetInstance().SwitchScene(7);
    canvas.gameObject.SetActive(false);
  }

  public void LoadChapter1()
  {
    Core.GameManagerData.GetInstance().SwitchScene(4);
    canvas.gameObject.SetActive(false);
  }
}
