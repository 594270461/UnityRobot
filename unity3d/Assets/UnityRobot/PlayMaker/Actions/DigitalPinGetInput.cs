using UnityEngine;
using System;
using System.Collections;
using UnityRobot;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("UnityRobot")]
	[Tooltip("")]
	public class DigitalPinGetInput : FsmStateAction
	{
		[RequiredField]
		public DigitalPin digitalPin;
		
		[Tooltip("Digital Input Value")]
		public FsmBool digitalValue;

		public bool everyFrame;
		
		public override void OnEnter()
		{
			DoGetInput();
			
			if (!everyFrame)
				Finish();
		}

		public override void OnUpdate()
		{
			DoGetInput();
		}
		
		void DoGetInput()
		{
			if(digitalPin != null)
				digitalValue.Value = digitalPin.digitalValue;
		}
	}
}
