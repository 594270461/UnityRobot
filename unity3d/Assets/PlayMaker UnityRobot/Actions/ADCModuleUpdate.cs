using UnityEngine;
using System.Collections;
using System;
using UnityRobot;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("UnityRobot")]
	[Tooltip("")]
	public class ADCModuleUpdate : FsmStateAction
	{
		public ADCModule adcModule;
		
		[Tooltip("Threshold Value")]
		public FsmInt threshold;
		
		[Tooltip("Analog Value")]
		public FsmInt analogValue;

		[Tooltip("Disconnected Event")]
		public FsmEvent disconnectedEvent;
		
		[Tooltip("Enter Threshold Event")]
		public FsmEvent enterThresholdEvent;
		
		[Tooltip("Exit Threshold Event")]
		public FsmEvent exitThresholdEvent;


		public override void Awake ()
		{
			base.Awake ();

			if(adcModule != null)
			{
				adcModule.OnEnter += OnThresholdEnter;
				adcModule.OnExit += OnThresholdExit;
			}
		}
		
		public override void OnUpdate()
		{
			if(adcModule.owner != null)
			{
				if(adcModule.owner.Connected == false)
				{
					Fsm.Event(disconnectedEvent);
					Finish();
				}
			}

			adcModule.threshold = threshold.Value;
			analogValue.Value = (int)adcModule.Value;
		}

		void OnThresholdEnter(object sender, EventArgs e)
		{
			Fsm.Event(enterThresholdEvent);
		}
		
		void OnThresholdExit(object sender, EventArgs e)
		{
			Fsm.Event(exitThresholdEvent);
		}
	}
}