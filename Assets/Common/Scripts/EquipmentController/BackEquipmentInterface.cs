using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackEquipmentInterface : EquipmentInterface
{

  Animation Anim;
  // Start is called before the first frame update
  void Start()
  {
    this.Anim = GetComponent<Animation>();
    //swtichEquipment("package");
  }

  // Update is called once per frame
  void Update()
  {
    if (CurrentEquipment != null)
      if (Input.GetKeyDown(KeyCode.C))
      {
        this.CurrentEquipment.Function();
      }
  }
}
