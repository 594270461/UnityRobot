using UnityEngine;
using System;
using System.Collections;
using UnityRobot;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("UnityRobot")]
	[Tooltip("")]
	public class DigitalPinSetPWM : FsmStateAction
	{
		[RequiredField]
		public DigitalPin digitalPin;
		
		[Tooltip("PWM Value")]
		public FsmFloat pwmValue;

		public bool everyFrame;
		
		public override void OnEnter()
		{
			DoSetPWM();
			
			if (!everyFrame)
				Finish();
		}

		public override void OnUpdate()
		{
			DoSetPWM();
		}
		
		void DoSetPWM()
		{
			if(digitalPin != null)
				digitalPin.analogValue = pwmValue.Value;
		}
	}
}
