using UnityEngine;
using System;
using System.Collections;
using UnityRobot;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("UnityRobot")]
	[Tooltip("Search enable ports")]
	public class UnityRobotSearch : FsmStateAction
	{
		[RequiredField]
		public UnityRobot.UnityRobot unityRobot;

		[Tooltip("Search Completed Event")]
		public FsmEvent searchCompletedEvent;

		public override void OnEnter()
		{
			if(unityRobot != null)
			{
				unityRobot.OnSearchCompleted += OnSearchCompleted;
				unityRobot.PortSearch();
			}
		}

		public override void OnExit ()
		{
			base.OnExit ();
			
			if(unityRobot != null)
			{
				unityRobot.OnSearchCompleted -= OnSearchCompleted;
			}
		}
		
		void OnSearchCompleted(object sender, EventArgs e)
		{
			Fsm.Event(searchCompletedEvent);
			Finish();
		}
	}
}
