using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;


namespace Core
{
  public abstract class GameState : Core.IState
  {
    protected GameManager gameManager;
    protected StateMachine belongTO;
  }


  public class GameState_Setting : GameState
  {
    public GameState_Setting(GameManager gm)
    {
      this.gameManager = gm;
      belongTO = GameManagerData.GetInstance().stateMachine;
    }
    public override void onEnter()
    {

    }

    public override void update()
    {
    }

    public override void onExit()
    {
    }

    public override string getName()
    {
      return "setting";
    }
  }

  public class GameState_Playing : GameState
  {
    public GameState_Playing(GameManager gm)
    {
      this.gameManager = gm;
      belongTO = GameManagerData.GetInstance().stateMachine;
    }
    public override void onEnter()
    {
      this.gameManager.AnimCTL.play = "fadein";
      this.gameManager.wed.Wed_Init();
    }

    public override void update()
    {
      gameManager.IsPlayerDead();
    }

    public override void onExit()
    {
    }

    public override string getName()
    {
      return "playing";
    }
  }

  public class GameState_DEAD : GameState
  {
    public GameState_DEAD(GameManager gm)
    {
      this.gameManager = gm;
      belongTO = GameManagerData.GetInstance().stateMachine;
    }
    public override void onEnter()
    {
      Debug.Log("dead");
      this.gameManager.AnimCTL.play = "dead";
    }

    public override void update()
    {
      if (this.gameManager.AnimCTL.animInfo.IsName("dead") &&
          this.gameManager.AnimCTL.animInfo.normalizedTime >= 1.0f)
      {
        this.belongTO.switchState("playing");
      }
    }

    public override void onExit()
    {
      this.gameManager.ReLoadScene();
    }

    public override string getName()
    {
      return "dead";
    }
  }

  public class GameState_SwitchScenes : GameState
  {
    public GameState_SwitchScenes(GameManager gm)
    {
      this.gameManager = gm;
      belongTO = GameManagerData.GetInstance().stateMachine;
    }
    public override void onEnter()
    {

    }

    public override void update()
    {
    }

    public override void onExit()
    {
    }

    public override string getName()
    {
      return "switchscenes";
    }
  }
}


