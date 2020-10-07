using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentInterface : MonoBehaviour
{
  [Header("所属玩家")]
  public PlayerCTL player;
  [Header("装备装载的位置")]
  public Transform EquipTransfrom;
  //将游戏中所有的装备都加载在这里，得到相应的装备时调用swtichEquipment来更换角色身上的装备
  [Header("装备列表")]
  public List<EquipmentBase> EquipList;

  protected EquipmentBase CurrentEquipment;
  // Start is called before the first frame update
  void Start()
  {

  }
  // Update is called once per frame
  void Update()
  {

  }

  //切换装备
  public void swtichEquipment(string EquipName)
  {
    EquipmentBase e = GetEquip(EquipName);
    if (e == null)
    {
      Debug.LogWarningFormat("装备错误：装备【{0}】不存在", EquipName);
    }
    else
    {
      //删除现有的装备
      foreach (Transform child in transform)
        Destroy(child.gameObject);
      //实例化新的装备
      EquipmentBase newEquip = Instantiate(e, EquipTransfrom.position, EquipTransfrom.rotation, this.transform);
      this.CurrentEquipment = newEquip;
      //给新的装备设置玩家脚本的实例
      newEquip.SetPlayer(player);
    }
  }


  //通过装备名在装备列表中获取装备的组件
  EquipmentBase GetEquip(string EquipName)
  {
    foreach (EquipmentBase e in EquipList)
    {
      if (e.GetName() == EquipName)
        return e;
    }
    return null;
  }
  //游戏开始时用于检查装备列表中是否有重名的装备，待实现
  void ChecduplicateNames()
  {

  }
}
