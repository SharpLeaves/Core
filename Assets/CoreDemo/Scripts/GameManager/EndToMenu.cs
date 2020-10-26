using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndToMenu : MonoBehaviour
{
  // Start is called before the first frame update
  void Start()
  {
    StartCoroutine(toMenu());
  }

  // Update is called once per frame
  void Update()
  {

  }

  IEnumerator toMenu()
  {
    yield return new WaitForSeconds(5);
    Core.GameManagerData.GetInstance().SwitchScene(0);
    Core.GameManagerData.GetInstance().WEDcurEquipmentBack = null;
  }
}
