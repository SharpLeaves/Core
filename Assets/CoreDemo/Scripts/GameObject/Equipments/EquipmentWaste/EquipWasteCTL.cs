using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
namespace Core
{
  public class EquipWasteCTL : Core.InteractableC
  {
    [Header("装备容器")]
    public Container container;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    protected override void processInteract()
    {
      IEquipment equipment = container.getByName("DashUp");
      foreach (GameObject gameObject in effectedObjects)
      {
        if (gameObject.tag == "Player")
        {
          EquipmentController[] equipmentControllers = gameObject.GetComponentsInChildren<EquipmentController>();
          foreach (EquipmentController equipmentController in equipmentControllers)
          {
            if (equipmentController.name == "BackEquipment")
            {
              equipmentController.switchEquipment(equipment);
            }
          }
        }
      }
    }
  }
}

