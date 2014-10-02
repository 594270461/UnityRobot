using UnityEngine;
using System;
using System.Collections;
using UnityRobot;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("UnityRobot")]
	[Tooltip("")]
	public class RobotProxyDisconnect : FsmStateAction
	{
		[Tooltip("Disconnected Event")]
		public FsmEvent disconnectedEvent;

		private RobotProxy _robotProxy;


		public override void OnEnter()
		{
			_robotProxy = Owner.GetComponent<RobotProxy>();
			if(_robotProxy == null)
				Debug.LogWarning("There exist no RobotProxy!");
			else
				_robotProxy.Disconnect();

			Fsm.BroadcastEvent(disconnectedEvent);
			Finish();
		}
	}
}
