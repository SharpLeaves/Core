using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIInput : MonoBehaviour
{
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
    SceneManager.LoadScene(1);
  }

  public void LoadChapter1()
  {
    SceneManager.LoadScene(4);
  }
}
