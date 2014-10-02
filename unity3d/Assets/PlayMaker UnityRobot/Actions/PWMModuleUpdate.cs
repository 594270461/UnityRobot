using UnityEngine;
using System.Collections;
using System;
using UnityRobot;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("UnityRobot")]
	[Tooltip("")]
	public class PWMModuleUpdate : FsmStateAction
	{
		[Tooltip("PWM Value")]
		public FsmInt pwmValue;
		
		private PWMModule _pwmModule;

		public override void OnEnter ()
		{
			base.OnEnter ();
			
			_pwmModule = Owner.GetComponent<PWMModule>();
			if(_pwmModule == null)
				Debug.LogWarning("There exist no PWMModule!");
		}

		
		public override void OnUpdate()
		{
			if(_pwmModule != null)
			{
				_pwmModule.Value = pwmValue.Value;
			}
		}
	}
}