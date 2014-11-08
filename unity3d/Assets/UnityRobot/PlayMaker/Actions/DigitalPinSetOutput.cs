using UnityEngine;
using System;
using System.Collections;
using UnityRobot;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("UnityRobot")]
	[Tooltip("")]
	public class DigitalPinSetOutput : FsmStateAction
	{
		[RequiredField]
		public DigitalPin digitalPin;

		[Tooltip("Digital Output Value")]
		public FsmBool digitalValue;

		public bool everyFrame;

		public override void OnEnter()
		{
			DoSetOutput();
			
			if (!everyFrame)
				Finish();
		}

		public override void OnUpdate()
		{
			DoSetOutput();
		}

		void DoSetOutput()
		{
			if(digitalPin != null)
				digitalPin.digitalValue = digitalValue.Value;
		}
	}
}
