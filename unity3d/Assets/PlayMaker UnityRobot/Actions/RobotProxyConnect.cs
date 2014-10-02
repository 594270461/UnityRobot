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

		private RobotProxy _robotProxy;


		public override void OnEnter()
		{
			_robotProxy = Owner.GetComponent<RobotProxy>();
			if(_robotProxy == null)
				Debug.LogWarning("There exist no RobotProxy!");
			else
			{
				_robotProxy.OnConnected += OnConnected;
				_robotProxy.OnConnectionFailed += OnConnectionFailed;

				if(portName.UseVariable == true)
					_robotProxy.portName = portName.Value;
				
				if(baudrate.UseVariable == true)
					_robotProxy.baudrate = baudrate.Value;
				
				if(timeoutSec.UseVariable == true)
					_robotProxy.timeoutSec = timeoutSec.Value;
				
				_robotProxy.Connect();
			}
		}

		public override void OnExit ()
		{
			base.OnExit ();

			if(_robotProxy != null)
			{
				_robotProxy.OnConnected -= OnConnected;
				_robotProxy.OnConnectionFailed -= OnConnectionFailed;

			}
		}

		void OnConnected(object sender, EventArgs e)
		{
			Fsm.BroadcastEvent(connectedEvent);
			Finish();
		}
		
		void OnConnectionFailed(object sender, EventArgs e)
		{
			Fsm.Event(connectionFailedEvent);
			Finish();
		}
	}
}
