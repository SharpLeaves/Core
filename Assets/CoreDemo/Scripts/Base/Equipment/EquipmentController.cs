using UnityEngine;
using Core.Character;

namespace Core{
  public class EquipmentController : MonoBehaviour{
    public Wed main;
    protected IEquipment curEquipment;

    public void switchEquipment(IEquipment equipment){
      if (equipment == null)
        return;

      ClearEquipment();

      IEquipment newEquipment = Instantiate(equipment, this.transform.position, this.transform.rotation, this.transform);
      curEquipment = newEquipment;
      curEquipment.setCharacter(main);

      if (this.name == "BackEquipment"){
        GameManagerData.GetInstance().WEDcurEquipmentBack = equipment;
      }
      if (this.name == "HandEquipment"){
        GameManagerData.GetInstance().WEDcurEquipmentHand = equipment;
      }
    }

    public void ClearEquipment(){
      foreach (Transform child in transform){
        Destroy(child.gameObject);
      }
    }
  }
}