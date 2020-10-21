using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
using UnityEngine.Experimental.Rendering.Universal;
namespace Core
{
  public class EquipWasteCTL : Core.InteractableC
  {




    [Header("装备容器")]
    public Container container;
    [Header("废品主体")]
    public WasteFloat Main;
    [Header("该废品对应的装备名称")]
    public string EquipmentName;
    [Header("装备类型，false表示背部，true表示手部")]
    public bool EquipmentType;
    [Header("反馈灯光")]
    public Light2D FeedBackLight;

    public GameObject Player;
    private bool IsRecycleStart;

    public float RecycleSpeed = 50;

    private float RecycleProcess;

    private float RecycleDestination;

    // Start is called before the first frame update
    void Start()
    {
      IsRecycleStart = false;
      RecycleProcess = 0;
      RecycleDestination = 100;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
      if (IsRecycleStart)
      {
        Recycle();

      }
    }

    protected override void processInteract()
    {

      foreach (GameObject gameObject in effectedObjects)
      {
        if (gameObject.tag == "Player" && !IsRecycleStart)
        {
          Player = gameObject;
          IsRecycleStart = true;
          Player.GetComponentInChildren<Core.Character.Wed>().GetStateMachine.switchState("remodel");
          Core.AudioManager._instance.PlayAudioByName("recycleWaste", this.transform.position);
        }
      }
    }

    void Recycle()
    {
      if (Player.GetComponentInChildren<Core.Character.Wed>().inputController.InteractInput)
      {
        this.RecycleProcess += this.RecycleSpeed * Time.deltaTime;
        this.FeedBackLight.intensity += 50 * Time.deltaTime;
        if (this.RecycleProcess >= this.RecycleDestination)
        {
          switchEquipment(EquipmentName);
          Destroy(this.FeedBackLight);
        }
      }
      else
      {
        this.RecycleProcess = 0;
        IsRecycleStart = false;
        this.FeedBackLight.intensity = 0;
      }
    }


    void switchEquipment(string EquipmentName)
    {
      AudioManager._instance.PlayAudioByName("recycleFinish", this.transform.position);
      IEquipment equipment = container.getByName(EquipmentName);
      EquipmentController[] equipmentControllers = Player.gameObject.GetComponentsInChildren<EquipmentController>();
      foreach (EquipmentController equipmentController in equipmentControllers)
      {
        if (EquipmentType)
        {
          if (equipmentController.name == "BackEquipment")
          {
            equipmentController.switchEquipment(equipment);
            Destroy(Main.gameObject);
            Destroy(this);
          }
        }
        else
        {
          if (equipmentController.name == "HandEquipment")
          {
            equipmentController.switchEquipment(equipment);
            Destroy(Main.gameObject);
            Destroy(this);
          }
        }

      }
    }
  }
}

