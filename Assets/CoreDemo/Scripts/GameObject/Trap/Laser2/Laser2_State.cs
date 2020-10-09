using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

namespace Core
{
	public abstract class Laser2_State : IState
	{
		protected Laser2_CTL main;
	}

	public class Laser2_Normal : Laser2_State
	{
		public Laser2_Normal(Laser2_CTL _main)
		{
			main = _main;
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
			return "normal";
		}
	}

	public class Laser2_Disable : Laser2_State
	{
		public Laser2_Disable(Laser2_CTL _main)
		{
			main = _main;
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
			return "disable";
		}
	}


}
