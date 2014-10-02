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
		[Tooltip("Threshold Value")]
		public FsmInt threshold;
		
		[Tooltip("Analog Value")]
		public FsmInt analogValue;

		[Tooltip("Enter Threshold Event")]
		public FsmEvent enterThresholdEvent;
		
		[Tooltip("Exit Threshold Event")]
		public FsmEvent exitThresholdEvent;

		private ADCModule _adcModule;


		public override void OnEnter ()
		{
			base.OnEnter ();

			_adcModule = Owner.GetComponent<ADCModule>();
			if(_adcModule == null)
				Debug.LogWarning("There exist no ADCModule!");
			else
			{
				_adcModule.OnEnter += OnThresholdEnter;
				_adcModule.OnExit += OnThresholdExit;
			}
		}
		
		public override void OnUpdate()
		{
			if(_adcModule != null)
			{
				_adcModule.threshold = threshold.Value;
				analogValue.Value = (int)_adcModule.Value;
			}
		}

		public override void OnExit ()
		{
			base.OnExit ();

			if(_adcModule != null)
			{
				_adcModule.OnEnter -= OnThresholdEnter;
				_adcModule.OnExit -= OnThresholdExit;
			}
		}

		void OnThresholdEnter(object sender, EventArgs e)
		{
			Fsm.BroadcastEvent(enterThresholdEvent);
		}
		
		void OnThresholdExit(object sender, EventArgs e)
		{
			Fsm.BroadcastEvent(exitThresholdEvent);
		}
	}
}