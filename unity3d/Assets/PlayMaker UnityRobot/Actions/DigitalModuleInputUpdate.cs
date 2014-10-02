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
		[Tooltip("Digital Value")]
		public FsmBool digitalValue;

		[Tooltip("Mode Changed Event")]
		public FsmEvent modeChangedEvent;

		[Tooltip("Signal Rising Event")]
		public FsmEvent risingEvent;
		
		[Tooltip("Signal Falling Event")]
		public FsmEvent fallingEvent;

		private DigitalModule _digitalModule;
		

		public override void OnEnter ()
		{
			base.OnEnter ();

			_digitalModule = Owner.GetComponent<DigitalModule>();
			if(_digitalModule == null)
				Debug.LogWarning("There exist no DigitalModule!");
			else
			{
				_digitalModule.OnRisingEdge += OnRisingEdge;
				_digitalModule.OnFallingEdge += OnFallingEdge;
			}
		}
		
		public override void OnUpdate()
		{
			if(_digitalModule != null)
			{
				if(_digitalModule.mode == DigitalModule.Mode.OUTPUT)
				{
					Fsm.Event(modeChangedEvent);
					Finish();
				}

				if(_digitalModule.Value == 0)
					digitalValue.Value = false;
				else
					digitalValue.Value = true;
			}
		}

		public override void OnExit ()
		{
			base.OnExit ();

			if(_digitalModule != null)
			{
				_digitalModule.OnRisingEdge -= OnRisingEdge;
				_digitalModule.OnFallingEdge -= OnFallingEdge;
			}
		}
		
		void OnRisingEdge(object sender, EventArgs e)
		{
			Fsm.BroadcastEvent(risingEvent);
		}
		
		void OnFallingEdge(object sender, EventArgs e)
		{
			Fsm.BroadcastEvent(fallingEvent);
		}
	}
}