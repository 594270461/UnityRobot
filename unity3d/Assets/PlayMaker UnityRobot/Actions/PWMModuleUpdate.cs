using UnityEngine;
using System.Collections;
using System;
using UnityRobot;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("UnityRobot")]
	[Tooltip("")]
	public class PWMModuleUpdate : FsmStateAction
	{
		public PWMModule pwmModule;

		[Tooltip("PWM Value")]
		public FsmInt pwmValue;
		
		[Tooltip("Disconnected Event")]
		public FsmEvent disconnectedEvent;		

		
		public override void OnUpdate()
		{
			if(pwmModule.owner != null)
			{
				if(pwmModule.owner.Connected == false)
				{
					Fsm.Event(disconnectedEvent);
					Finish();
				}
			}

			pwmModule.Value = pwmValue.Value;
		}
	}
}