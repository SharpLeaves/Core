using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StorySystem : MonoBehaviour
{

  [Header("对话框")]
  public StoryBase DialogFrame;
  [Header("文本文件")]
  public TextAsset text;

  public bool IsDialogEnd = false;

  private GameObject dialog;
  private bool isDialogStart = false;
  // Start is called before the first frame update
  void OnEnable()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }
  public void Dialog()
  {
    if (!isDialogStart)
    {
      IsDialogEnd = false;
      dialog = Instantiate(DialogFrame.gameObject, new Vector3(0, 0, 0), Quaternion.identity, this.transform);
      dialog.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
      dialog.GetComponent<StoryBase>().setTextFile(text);
      isDialogStart = true;
    }
    isDialogStart = dialog.GetComponent<StoryBase>().Dialog();
    if (!isDialogStart)
      IsDialogEnd = true;
  }

  public void setText(TextAsset t)
  {
    this.text = t;
  }
}
