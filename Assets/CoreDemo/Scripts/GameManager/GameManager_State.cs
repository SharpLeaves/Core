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
      Time.timeScale = 0;
      this.gameManager.ShowSettingInterface();
    }

    public override void update()
    {
      if (Input.GetKeyDown(KeyCode.Escape))
      {
        this.belongTO.switchState("playing");
      }
    }
    public override void onExit()
    {
      Time.timeScale = 1;
      this.gameManager.HideSettingInterface();

    }

    public override string getName()
    {
      return "setting";
    }
  }

  public class GameState_ToPlay : GameState
  {
    public GameState_ToPlay(GameManager gm)
    {
      this.gameManager = gm;
      belongTO = GameManagerData.GetInstance().stateMachine;
    }
    public override void onEnter()
    {
      this.gameManager.AnimCTL.play = "fadein";
      this.gameManager.wed.Wed_Init();
      this.belongTO.switchState("playing");
    }

    public override void update()
    {

    }

    public override void onExit()
    {
    }

    public override string getName()
    {
      return "toplay";
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
      this.gameManager.wed.inputController.InputEnable = true;
    }

    public override void update()
    {
      if (Input.GetKeyDown(KeyCode.Escape))
        this.belongTO.switchState("setting");
      if (gameManager.IsPlayerDead())
        this.belongTO.switchState("dead");
      if (GameManagerData.GetInstance().IsStory)
        this.belongTO.switchState("story");
    }

    public override void onExit()
    {
      this.gameManager.wed.inputController.InputEnable = false;
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
      this.gameManager.AnimCTL.play = "dead";
    }

    public override void update()
    {
      if (this.gameManager.AnimCTL.animInfo.IsName("dead") &&
          this.gameManager.AnimCTL.animInfo.normalizedTime >= 1.0f)
      {
        this.belongTO.switchState("toplay");
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

  public class GameState_Story : GameState
  {
    public GameState_Story(GameManager gm)
    {
      this.gameManager = gm;
      belongTO = GameManagerData.GetInstance().stateMachine;
    }
    public override void onEnter()
    {
      this.gameManager.storysystem.Dialog();
    }

    public override void update()
    {
      if (Input.GetKeyDown(KeyCode.E))
        this.gameManager.storysystem.Dialog();
      if (this.gameManager.storysystem.IsDialogEnd)
        this.belongTO.switchState("playing");
    }

    public override void onExit()
    {
      GameManagerData.GetInstance().IsStory = false;
    }

    public override string getName()
    {
      return "story";
    }
  }
}


