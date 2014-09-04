using UnityEngine;
using System;
using System.Collections;
using UnityRobot;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("UnityRobot")]
	[Tooltip("")]
	public class RobotProxyConnect : FsmStateAction
	{
		public RobotProxy robotProxy;

		[Tooltip("Port name")]
		public FsmString portName;

		[Tooltip("Baudrate(bps)")]
		public FsmInt baudrate;

		[Tooltip("Timeout(sec)")]
		public FsmFloat timeoutSec;

		[Tooltip("Connected Event")]
		public FsmEvent connectedEvent;

		[Tooltip("Connection Failed Event")]
		public FsmEvent connectionFailedEvent;


		public override void Awake ()
		{
			base.Awake ();

			if(robotProxy != null)
			{
				robotProxy.OnConnected += OnConnected;
				robotProxy.OnConnectionFailed += OnConnectionFailed;
			}
		}

		public override void OnEnter()
		{
			if(portName.UseVariable == true)
				robotProxy.portName = portName.Value;

			if(baudrate.UseVariable == true)
				robotProxy.baudrate = baudrate.Value;

			if(timeoutSec.UseVariable == true)
				robotProxy.timeoutSec = timeoutSec.Value;

			robotProxy.Connect();
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
