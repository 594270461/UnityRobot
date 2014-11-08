using UnityEngine;
using System;
using System.Collections;
using UnityRobot;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("UnityRobot")]
	[Tooltip("Listen OnDisconnected from UnityRobot")]
	public class UnityRobotOnDisconnected : FsmStateAction
	{
		[RequiredField]
		public UnityRobot.UnityRobot unityRobot;
		
		[Tooltip("Disconnected Event")]
		public FsmEvent disconnectedEvent;

		public override void OnEnter()
		{
			base.OnEnter();

			if(unityRobot != null)
			{
				unityRobot.OnDisconnected += OnDisconnected;
				if(unityRobot.Connected == false)
				{
					Fsm.Event(disconnectedEvent);
					Finish();
				}
			}
		}

		public override void OnExit ()
		{
			base.OnExit ();
			
			if(unityRobot != null)
			{
				unityRobot.OnDisconnected -= OnDisconnected;
			}
		}
		
		void OnDisconnected(object sender, EventArgs e)
		{
			Fsm.Event(disconnectedEvent);
			Finish();
		}
	}
}
