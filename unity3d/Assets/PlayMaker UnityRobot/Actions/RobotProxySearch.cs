using UnityEngine;
using System;
using System.Collections;
using UnityRobot;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("UnityRobot")]
	[Tooltip("")]
	public class RobotProxySearch : FsmStateAction
	{
		public RobotProxy robotProxy;

		[Tooltip("Port name list")]
		public FsmString[] portNames;
		
		[Tooltip("Search Completed Event")]
		public FsmEvent searchCompletedEvent;

		
		public override void Awake ()
		{
			base.Awake ();

			if(robotProxy != null)
				robotProxy.OnSearchCompleted += OnSearchCompleted;
		}
		
		public override void OnEnter()
		{
			robotProxy.PortSearch();
		}
		
		void OnSearchCompleted(object sender, EventArgs e)
		{
			portNames = new FsmString[robotProxy.portNames.Count];
			for(int i=0; i<robotProxy.portNames.Count; i++)
				portNames[i] = robotProxy.portNames[i];

			Fsm.Event(searchCompletedEvent);
			Finish();
		}
	}
}
