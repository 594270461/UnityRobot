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
		[Tooltip("Digital Value")]
		public FsmBool digitalValue;
		
		[Tooltip("Mode Changed Event")]
		public FsmEvent modeChangedEvent;	


		private DigitalModule _digitalModule;

		
		public override void OnEnter ()
		{
			base.OnEnter ();
			
			_digitalModule = Owner.GetComponent<DigitalModule>();
			if(_digitalModule == null)
				Debug.LogWarning("There exist no DigitalModule!");
		}
		
		public override void OnUpdate()
		{
			if(_digitalModule != null)
			{
				if(_digitalModule.mode != DigitalModule.Mode.OUTPUT)
				{
					Fsm.Event(modeChangedEvent);
					Finish();
				}
				
				if(digitalValue.Value == false)
					_digitalModule.Value = 0;
				else
					_digitalModule.Value = 1;
			}
		}
	}
}