using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

  public FSM.StateMachine sm;
  public enum GameProgress
  {
    MENU,
    FORWORD,
    Chapter1
  }

  public enum PlayerState
  {
    Controlable,
    Dead,
    UnControable,
  }


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

  }
}
