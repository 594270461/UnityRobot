using UnityEngine;
using System;
using System.Collections;
using UnityRobot;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("UnityRobot")]
	[Tooltip("Get Port Names")]
	public class UnityRobotGetPortNames : FsmStateAction
	{
		[RequiredField]
		public UnityRobot.UnityRobot unityRobot;
		[UIHint(UIHint.Variable)]
		public FsmString storeValue;
		
		public override void OnEnter()
		{
			base.OnEnter();
			
			if(unityRobot != null)
			{
				string portNames = "";
				for(int i=0; i<unityRobot.portNames.Count; i++)
				{
					if(i > 0)
						portNames += Environment.NewLine;
					portNames += unityRobot.portNames[i];
				}
				storeValue.Value = portNames;
			}
			
			Finish();
		}
	}
}
