using UnityEngine;
using System.Collections;
using System;
using UnityRobot;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("UnityRobot")]
	[Tooltip("")]
	public class DigitalModuleInputUpdate : FsmStateAction
	{
		public DigitalModule digitalModule;

		[Tooltip("Digital Value")]
		public FsmBool digitalValue;

		[Tooltip("Mode Changed Event")]
		public FsmEvent modeChangedEvent;

		[Tooltip("Disconnected Event")]
		public FsmEvent disconnectedEvent;
		
		[Tooltip("Signal Rising Event")]
		public FsmEvent risingEvent;
		
		[Tooltip("Signal Falling Event")]
		public FsmEvent fallingEvent;
		
		
		public override void Awake ()
		{
			base.Awake ();
			
			if(digitalModule != null)
			{
				digitalModule.OnRisingEdge += OnRisingEdge;
				digitalModule.OnFallingEdge += OnFallingEdge;
			}
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

			if(digitalModule.mode == DigitalModule.Mode.OUTPUT)
			{
				Fsm.Event(modeChangedEvent);
				Finish();
			}

			if(digitalModule.Value == 0)
				digitalValue.Value = false;
			else
				digitalValue.Value = true;
		}
		
		void OnRisingEdge(object sender, EventArgs e)
		{
			Fsm.Event(risingEvent);
		}
		
		void OnFallingEdge(object sender, EventArgs e)
		{
			Fsm.Event(fallingEvent);
		}
	}
}