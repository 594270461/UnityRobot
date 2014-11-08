using UnityEngine;
using System;
using System.Collections;
using UnityRobot;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("UnityRobot")]
	[Tooltip("Listen OnChangedDigitalInput from DigitalPin")]
	public class DigitalPinOnChangedInput : FsmStateAction
	{
		[RequiredField]
		public DigitalPin digitalPin;
		
		[Tooltip("Changed Digital Input Event")]
		public FsmEvent changedInputEvent;
		
		public override void OnEnter()
		{
			if(digitalPin != null)
			{
				digitalPin.OnChangedDigitalInput += OnChangedInput;
			}
		}
		
		public override void OnExit ()
		{
			base.OnExit ();
			
			if(digitalPin != null)
			{
				digitalPin.OnChangedDigitalInput -= OnChangedInput;
			}
		}
		
		void OnChangedInput(object sender, EventArgs e)
		{
			Fsm.Event(changedInputEvent);
			Finish();
		}
	}
}
