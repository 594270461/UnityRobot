using UnityEngine;
using System.Collections;
using System;

namespace UnityRobot
{
	public class imuModule : UnityModule
	{
		public GameObject target;
		private Quaternion _rotation;

		protected short _yaw;
		protected short _pitch;
		protected short _roll;
		
		
		protected override void OnAwake ()
		{
			_rotation = Quaternion.identity;
			outputOnly = false;
		}
		
		protected override void OnUpdate ()
		{
			if(target != null)
				target.transform.localRotation = _rotation;
		}
		
		protected override void OnModuleStart ()
		{
			_rotation = Quaternion.identity;
		}
		
		protected override void OnModuleStop ()
		{
			if(target != null)
				target.transform.localRotation = Quaternion.identity;
		}
		
		protected override void OnAction ()
		{
			_rotation.eulerAngles = new Vector3(-(float)_pitch * 0.01f
			                                    ,(float)_yaw * 0.01f
			                                    ,-(float)_roll * 0.01f);

		//	Debug.Log(string.Format("Yaw:{0:d} Pitch:{1:d} Roll:{2:d}", _yaw, _pitch, _roll));
		}
		
		protected override void OnPop ()
		{
			Pop(ref _yaw);
			Pop(ref _pitch);
			Pop(ref _roll);
		}
		
		protected override void OnPush ()
		{
		}
		
		public Quaternion Rotation
		{
			get
			{
				return _rotation;
			}
		}
	}
}
