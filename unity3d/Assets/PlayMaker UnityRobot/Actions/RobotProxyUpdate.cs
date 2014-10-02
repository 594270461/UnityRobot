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
		[Tooltip("Disconnected Event")]
		public FsmEvent disconnectedEvent;
		
		[Tooltip("Updated Event")]
		public FsmEvent updatedEvent;
		
		private RobotProxy _robotProxy;


		public override void OnEnter()
		{
			_robotProxy = Owner.GetComponent<RobotProxy>();
			if(_robotProxy == null)
				Debug.LogWarning("There exist no RobotProxy!");
			else
			{
				_robotProxy.OnDisconnected += OnDisconnected;
				_robotProxy.OnUpdated += OnUpdated;
			}
		}

		public override void OnExit ()
		{
			base.OnExit ();
			
			if(_robotProxy != null)
			{
				_robotProxy.OnDisconnected -= OnDisconnected;
				_robotProxy.OnUpdated -= OnUpdated;
				
			}
		}
		
		void OnDisconnected(object sender, EventArgs e)
		{
			Fsm.BroadcastEvent(disconnectedEvent);
			Finish();
		}
		
		void OnUpdated(object sender, EventArgs e)
		{
			Fsm.Event(updatedEvent);
		}
	}
}
