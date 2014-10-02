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
		[Tooltip("Port name list")]
		public FsmString[] portNames;
		
		[Tooltip("Search Completed Event")]
		public FsmEvent searchCompletedEvent;

		private RobotProxy _robotProxy;


		public override void OnEnter()
		{
			_robotProxy = Owner.GetComponent<RobotProxy>();
			if(_robotProxy == null)
				Debug.LogWarning("There exist no RobotProxy!");
			else
			{
				_robotProxy.OnSearchCompleted += OnSearchCompleted;

				_robotProxy.PortSearch();
			}
		}

		public override void OnExit ()
		{
			base.OnExit ();
			
			if(_robotProxy != null)
			{
				_robotProxy.OnSearchCompleted -= OnSearchCompleted;
			}
		}
		
		void OnSearchCompleted(object sender, EventArgs e)
		{
			if(_robotProxy != null)
			{
				portNames = new FsmString[_robotProxy.portNames.Count];
				for(int i=0; i<_robotProxy.portNames.Count; i++)
					portNames[i] = _robotProxy.portNames[i];
			}

			Fsm.Event(searchCompletedEvent);
			Finish();
		}
	}
}
