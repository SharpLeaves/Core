using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser2_CTL : TrapBase
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public override void FunctionOnDisable()
	{

	}

	protected override void StateMachineInit()
	{
		this.stateMachine = new Core.StateMachine();
	}



}
