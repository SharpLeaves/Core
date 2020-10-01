using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{

  [Header("对话框")]
  public DialogBase DialogFrame;
  [Header("主摄像机")]
  public Camera mainCamera;
  [Header("文本文件")]
  public TextAsset text;

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
  public void Dialog(Vector3 dialogPosition)
  {
    if (!isDialogStart)
    {
      dialog = Instantiate(DialogFrame.gameObject, dialogPosition, Quaternion.identity, this.transform);
      dialog.GetComponent<DialogBase>().setTextFile(text);
      dialog.GetComponent<DialogBase>().setCamera(mainCamera);
      isDialogStart = true;
    }
    isDialogStart = dialog.GetComponent<DialogBase>().Dialog();

  }
}
