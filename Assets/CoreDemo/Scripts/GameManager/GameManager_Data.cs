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

    public GameManager gameManager;


    /* 角色出生点 */
    public Vector2 SpwanPoint { get; set; }
    /* 游戏状态机 */
    public Core.StateMachine stateMachine;
    public void statemachineInit()
    {
      this.stateMachine = new Core.StateMachine();
      this.stateMachine.addState(new GameState_Playing(this.gameManager));
      this.stateMachine.addState(new GameState_SwitchScenes(this.gameManager));
      this.stateMachine.addState(new GameState_DEAD(this.gameManager));
      this.stateMachine.addState(new GameState_Setting(this.gameManager));
      this.stateMachine.switchState("playing");
    }

    public void GameManagerInit(GameManager gm)
    {
      this.gameManager = gm;
    }

  }

}
