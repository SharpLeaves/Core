using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

namespace Core
{
  public class GameManagerData
  {
    /* 单例模式 */
    static public GameManagerData GetInstance()
    {
      if (instance == null)
        instance = new GameManagerData();

      return instance;
    }
    static private GameManagerData instance;
    private GameManagerData() { }

    /* 角色身上的装备，角色死亡时更新 */
    public Core.IEquipment WEDcurEquipmentBack = null;
    public Core.IEquipment WEDcurEquipmentHand = null;
    /* 出生时的游戏边界 */
    public int gameBoundNumber = -1;
    /*是否已经设置出生点 */
    public bool IsSetSpwanPoint = false;
    /* 是否在剧情 */
    public bool IsStory = false;
    public GameManager gameManager;
    /* 游戏状态机 */
    public Core.StateMachine stateMachine;
    /* 下一个场景 */
    public int NextSceneNumber;
    /* 角色出生点 */
    private Vector2 spwanpoint;
    public Vector2 SpwanPoint
    {
      get
      {
        if (IsSetSpwanPoint) return spwanpoint;
        else return gameManager.FirstSpwanPoint.position;
      }
      set
      {
        spwanpoint = value;
        IsSetSpwanPoint = true;
      }
    }
    public StorySystem storySystem
    {
      get
      {
        return this.gameManager.storysystem;
      }
    }
    public void statemachineInit()
    {
      this.stateMachine = new Core.StateMachine();
      this.stateMachine.addState(new GameState_ToPlay(this.gameManager));
      this.stateMachine.addState(new GameState_Playing(this.gameManager));
      this.stateMachine.addState(new GameState_SwitchScenes(this.gameManager));
      this.stateMachine.addState(new GameState_DEAD(this.gameManager));
      this.stateMachine.addState(new GameState_Setting(this.gameManager));
      this.stateMachine.addState(new GameState_Story(this.gameManager));
      this.stateMachine.switchState("toplay");
    }

    public void GameManagerInit(GameManager gm)
    {
      this.gameManager = gm;
    }

    public void StartStory(TextAsset t)
    {
      this.gameManager.storysystem.setText(t);
      this.IsStory = true;
    }

    public void SwitchScene(int SceneIndex)
    {
      this.gameBoundNumber = -1;
      NextSceneNumber = SceneIndex;
      GameManagerData.GetInstance().stateMachine.switchState("switchscenes");
    }
  }
}