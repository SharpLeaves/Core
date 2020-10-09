using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

namespace Core
{
	public abstract class Laser_State : IState
	{
		protected Laser_CTL main;
	}

	public class Laser_Normal : Laser_State
	{
		public Laser_Normal(Laser_CTL _main)
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

	public class Laser_Disable : Laser_State
	{
		public Laser_Disable(Laser_CTL _main)
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
