using UnityEngine;
using System;
using System.Collections;
using UnityRobot;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("UnityRobot")]
	[Tooltip("Listen OnConnected from UnityModule")]
	public class UnityModuleOnConnected : FsmStateAction
	{
		[RequiredField]
		public UnityModule unityModule;
		
		[Tooltip("Connected Event")]
		public FsmEvent connectedEvent;
		
		public override void OnEnter()
		{
			if(unityModule != null)
			{
				unityModule.OnConnected += OnConnected;
				if(unityModule.Connected == true)
				{
					Fsm.Event(connectedEvent);
					Finish();
				}
			}
		}
		
		public override void OnExit ()
		{
			base.OnExit ();
			
			if(unityModule != null)
			{
				unityModule.OnConnected -= OnConnected;
			}
		}
		
		void OnConnected(object sender, EventArgs e)
		{
			Fsm.Event(connectedEvent);
			Finish();
		}
	}
}
