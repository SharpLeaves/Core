using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

public class GameManager
{
  /* 单例模式 */
  static public GameManager GetInstance()
  {
    if (instance == null)
      instance = new GameManager();

    return instance;
  }
  static private GameManager instance;
  private GameManager() { }



  /* 角色出生点 */
  public Vector2 SpwanPoint { get; set; }
  /* 游戏状态机 */
  public Core.StateMachine stateMachine;

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }

  void statemachineInit()
  {
    this.stateMachine.addState(new GameState_Playing());
    this.stateMachine.addState(new GameState_SwitchScenes());
    this.stateMachine.addState(new GameState_DEAD());
    this.stateMachine.addState(new GameState_Setting());
  }



}
