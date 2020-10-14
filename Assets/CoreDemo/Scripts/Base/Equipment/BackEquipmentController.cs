using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Core
{
  public class BackEquipmentController : EquipmentController
  {
    // Start is called before the first frame update
    public new void switchEquipment(IEquipmentBack equipment)
    {
      if (equipment == null)
        return;

      foreach (Transform child in transform)
      {
        Destroy(child.gameObject);
      }

      IEquipment newEquipment = Instantiate(equipment, this.transform.position, this.transform.rotation, this.transform);
      curEquipment = newEquipment;
      curEquipment.setCharacter(main);
    }
  }

}
