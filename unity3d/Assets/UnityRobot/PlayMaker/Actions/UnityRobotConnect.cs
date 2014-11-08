using UnityEngine;
using System;
using System.Collections;
using UnityRobot;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("UnityRobot")]
	[Tooltip("Connect to UnityRobot")]
	public class UnityRobotConnect : FsmStateAction
	{
		[RequiredField]
		public UnityRobot.UnityRobot unityRobot;

		[Tooltip("Connected Event")]
		public FsmEvent connectedEvent;
		
		[Tooltip("Connection Failed Event")]
		public FsmEvent connectionFailedEvent;

		public override void OnEnter()
		{
			if(unityRobot != null)
			{
				unityRobot.OnConnected += OnConnected;
				unityRobot.OnConnectionFailed += OnConnectionFailed;
				unityRobot.Connect();
			}
		}

		public override void OnExit ()
		{
			base.OnExit ();
			
			if(unityRobot != null)
			{
				unityRobot.OnConnected -= OnConnected;
				unityRobot.OnConnectionFailed -= OnConnectionFailed;
			}
		}
		
		void OnConnected(object sender, EventArgs e)
		{
			Fsm.Event(connectedEvent);
			Finish();
		}

		void OnConnectionFailed(object sender, EventArgs e)
		{
			Fsm.Event(connectionFailedEvent);
			Finish();
		}
	}
}
