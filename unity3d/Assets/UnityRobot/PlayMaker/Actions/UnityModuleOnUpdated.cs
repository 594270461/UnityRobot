using UnityEngine;
using System;
using System.Collections;
using UnityRobot;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("UnityRobot")]
	[Tooltip("Listen OnUpdated from UnityModule")]
	public class UnityModuleOnUpdated : FsmStateAction
	{
		[RequiredField]
		public UnityModule unityModule;
		
		[Tooltip("Updated Event")]
		public FsmEvent updatedEvent;
		
		public override void OnEnter()
		{
			if(unityModule != null)
			{
				unityModule.OnUpdated += OnUpdated;
			}
		}
		
		public override void OnExit ()
		{
			base.OnExit ();
			
			if(unityModule != null)
			{
				unityModule.OnUpdated -= OnUpdated;
			}
		}
		
		void OnUpdated(object sender, EventArgs e)
		{
			Fsm.Event(updatedEvent);
			Finish();
		}
	}
}
