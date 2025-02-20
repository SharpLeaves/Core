﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{



  [Header("当前场景编号")]
  /* 当前场景编号 */
  public int CurSceneIndex;
  [Header("场景出生点")]
  public Transform FirstSpwanPoint;

  [Header("设置组件")]
  public GameManager_Setting settingComponent;

  [Header("故事组件")]
  public StorySystem storysystem;

  [Header("边界管理器")]
  public BoundSwitchManager boundSwitchManager;
  /* 
    [Header("剧情对话组件")]
    public  */

  /* 游戏UI动画控制器 */
  public AnimatorController AnimCTL;
  /* WED */
  public Core.Character.Wed wed;

  private void Awake()
  {
    GameManagerData.GetInstance().GameManagerInit(this);
  }
  // Start is called before the first frame update
  void Start()
  {
    GameManagerData.GetInstance().statemachineInit();
    GameInit();
    if (GameManagerData.GetInstance().curBGM != null)
      AudioManager._instance.PlayMusicByName(GameManagerData.GetInstance().curBGM, GameManagerData.GetInstance().curVol);
  }

  // Update is called once per frame
  void Update()
  {
    GameManagerData.GetInstance().stateMachine.update();
  }

  void GameInit()
  {
    SetBound();
  }

  public bool IsPlayerDead()
  {
    if (wed.IsDead)
      return true;
    else
      return false;
  }

  public void ShowSettingInterface()
  {
    this.settingComponent.gameObject.SetActive(true);
  }

  public void HideSettingInterface()
  {
    this.settingComponent.gameObject.SetActive(false);
  }

  public void ReLoadScene()
  {
    SceneManager.LoadScene(CurSceneIndex);
  }

  public void SetBound()
  {
    if (GameManagerData.GetInstance().gameBoundNumber != -1)
      this.boundSwitchManager.SetBoundByNumber(GameManagerData.GetInstance().gameBoundNumber);
  }

}
