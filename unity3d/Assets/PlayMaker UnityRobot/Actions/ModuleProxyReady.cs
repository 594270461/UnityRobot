using UnityEngine;
using System.Collections;
using System;
using UnityRobot;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("UnityRobot")]
	[Tooltip("")]
	public class ModuleProxyReady : FsmStateAction
	{
		public ModuleProxy module;
		
		[Tooltip("Connected Event")]
		public FsmEvent connectedEvent;
		
		public override void Awake ()
		{
			base.Awake ();
		}
		
		public override void OnUpdate()
		{
			if(module.owner != null)
			{
				if(module.owner.Connected == true)
				{
					Fsm.Event(connectedEvent);
					Finish();
				}
			}
		}
	}
}