﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

namespace Core
{
	public abstract class HydroPress_State : IState
	{
		protected HydroPress_CTL main;
	}

	public class HydroPress_Normal : HydroPress_State
	{
		public HydroPress_Normal(HydroPress_CTL _main)
		{
			main = _main;
		}
		public override void onEnter()
		{
		}
		public override void update()
		{

		}

		public void fixedUpdate()
		{

		}
		public override void onExit()
		{
		}

		public override string getName()
		{
			return "normal";
		}
	}

	public class HydroPress_Disable : HydroPress_State
	{
		public HydroPress_Disable(HydroPress_CTL _main)
		{
			main = _main;
		}
		public override void onEnter()
		{
		}
		public override void update()
		{

		}

		public void fixedUpdate()
		{

		}
		public override void onExit()
		{
		}

		public override string getName()
		{
			return "disable";
		}
	}


}
