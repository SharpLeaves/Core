using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentClearPoint : Core.Effective
{
  // Start is called before the first frame update

  public Core.Character.Wed wed;

  protected override void processObjectEnter(GameObject gameObject)
  {
    wed.backEquipment.ClearEquipment();
    wed.handEquipment.ClearEquipment();
    Core.GameManagerData.GetInstance().WEDcurEquipmentBack = null;
    Core.GameManagerData.GetInstance().WEDcurEquipmentHand = null;
  }

  protected override void processObjectExit(GameObject gameObject)
  {

  }

  protected override void processObjectUpdate()
  {

  }

}
