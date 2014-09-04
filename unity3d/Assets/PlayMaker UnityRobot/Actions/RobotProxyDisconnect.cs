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
		public RobotProxy robotProxy;
		
		public override void OnEnter()
		{
			robotProxy.Disconnect();
			Finish();
		}
	}
}
