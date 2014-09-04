using UnityEngine;
using System.Collections;
using System;
using UnityRobot;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("UnityRobot")]
	[Tooltip("")]
	public class DigitalModuleOutputUpdate : FsmStateAction
	{
		public DigitalModule digitalModule;
		
		[Tooltip("Digital Value")]
		public FsmBool digitalValue;
		
		[Tooltip("Mode Changed Event")]
		public FsmEvent modeChangedEvent;
		
		[Tooltip("Disconnected Event")]
		public FsmEvent disconnectedEvent;

		
		public override void Awake ()
		{
			base.Awake ();
		}
		
		public override void OnUpdate()
		{
			if(digitalModule.owner != null)
			{
				if(digitalModule.owner.Connected == false)
				{
					Fsm.Event(disconnectedEvent);
					Finish();
				}
			}
			
			if(digitalModule.mode != DigitalModule.Mode.OUTPUT)
			{
				Fsm.Event(modeChangedEvent);
				Finish();
			}
			
			if(digitalValue.Value == false)
				digitalModule.Value = 0;
			else
				digitalModule.Value = 1;
		}
	}
}