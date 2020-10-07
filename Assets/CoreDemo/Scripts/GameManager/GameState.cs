using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameState:FSM.IState 
{
	
}


public class GameState_MENU : GameState
{
	public override void onEnter()
	{

	}

	public override void onUpdate()
	{
	}

	public override void onExit()
	{
	}

	public override string GetState()
	{
		return "menu";
	}
}

public class GameState_MAINGAME : GameState
{
	public override void onEnter()
	{

	}

	public override void onUpdate()
	{
	}

	public override void onExit()
	{
	}

	public override string GetState()
	{
		return "maingame";
	}
}

public class GameState_DEAD : GameState
{
	public override void onEnter()
	{

	}

	public override void onUpdate()
	{

	}

	public override void onExit()
	{

	}

	public override string GetState()
	{
		return "dead";
	}
}


