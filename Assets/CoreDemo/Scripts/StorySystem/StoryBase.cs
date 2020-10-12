using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryBase : MonoBehaviour
{
  [Header("UI组件")]
  public Text text;

  private TextAsset textfile;

  private List<string> textList = new List<string>();

  private int index;
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }

  void LoadTextFormFile()
  {

    textList.Clear();
    index = 0;
    var linedata = textfile.text.Split('\n');
    foreach (var line in linedata)
    {
      textList.Add(line);
    }

  }

  public bool Dialog()
  {
    if (index > textList.ToArray().Length - 1)
    {
      Destroy(this.gameObject);
      return false;
    }
    Debug.Log(index);
    text.text = textList.ToArray()[index];
    index++;
    return true;
  }


  public void setTextFile(TextAsset t)
  {
    textfile = t;
    LoadTextFormFile();
    Debug.Log(textList.ToArray().Length);
  }
}
