using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;


namespace Core
{
  public abstract class GameState : Core.IState
  {

  }


  public class GameState_Setting : GameState
  {
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
      return "playing";
    }
  }

  public class GameState_DEAD : GameState
  {
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
      return "dead";
    }
  }

  public class GameState_SwitchScenes : GameState
  {
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


