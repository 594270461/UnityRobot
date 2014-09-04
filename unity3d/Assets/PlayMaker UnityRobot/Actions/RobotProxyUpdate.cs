using UnityEngine;
using System;
using System.Collections;
using UnityRobot;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("UnityRobot")]
	[Tooltip("")]
	public class RobotProxyUpdate : FsmStateAction
	{
		public RobotProxy robotProxy;
		
		[Tooltip("Disconnected Event")]
		public FsmEvent disconnectedEvent;
		
		[Tooltip("Updated Event")]
		public FsmEvent updatedEvent;
		
		
		public override void Awake ()
		{
			base.Awake ();

			if(robotProxy != null)
			{
				robotProxy.OnDisconnected += OnDisconnected;
				robotProxy.OnUpdated += OnUpdated;
			}
		}
		
		void OnDisconnected(object sender, EventArgs e)
		{
			Fsm.Event(disconnectedEvent);
			Finish();
		}
		
		void OnUpdated(object sender, EventArgs e)
		{
			Fsm.Event(updatedEvent);
		}
	}
}
