using UnityEngine;
using System;
using System.Collections;
using UnityRobot;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("UnityRobot")]
	[Tooltip("Listen OnDisconnected from UnityModule")]
	public class UnityModuleOnDisconnected : FsmStateAction
	{
		[RequiredField]
		public UnityModule unityModule;
		
		[Tooltip("Disconnected Event")]
		public FsmEvent disconnectedEvent;
		
		public override void OnEnter()
		{
			if(unityModule != null)
			{
				unityModule.OnDisconnected += OnDisconnected;
				if(unityModule.Connected == false)
				{
					Fsm.Event(disconnectedEvent);
					Finish();
				}
			}
		}
		
		public override void OnExit ()
		{
			base.OnExit ();
			
			if(unityModule != null)
			{
				unityModule.OnDisconnected -= OnDisconnected;
			}
		}
		
		void OnDisconnected(object sender, EventArgs e)
		{
			Fsm.Event(disconnectedEvent);
			Finish();
		}
	}
}
