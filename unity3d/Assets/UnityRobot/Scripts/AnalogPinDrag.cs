using UnityEngine;
using System.Collections;
using System;
using UnityRobot;

namespace UnityRobot
{
	[AddComponentMenu("UnityRobot/AnalogPinDrag")]
	public class AnalogPinDrag : MonoBehaviour
	{
		public AnalogPin analogPin;
		public float dragMinRatio = 0.1f;
		public float dragMaxRatio = 0.9f;
		public float dragForceTolerance = 0.001f;
		public float dragForceScaler = 1f;

		public EventHandler OnDragStart;
		public EventHandler OnDragMove;
		public EventHandler OnDragEnd;

		private bool _drag;
		private float _preDiff;
		private float _preValue;
		private float _value;
		private float _startValue;
		private float _accelIntegral;

		// Use this for initialization
		void Start ()
		{
			Reset();
		}
		
		// Update is called once per frame
		void Update ()
		{
			if(analogPin != null)
			{
				if(analogPin.Started == true)
				{
					float curValue = analogPin.Value;
					if(_drag == true)
					{
						if(curValue > dragMinRatio && curValue < dragMaxRatio)
						{
							float diff = _value - _preValue;
							float accel = Mathf.Abs(diff - _preDiff);
							if(accel < dragForceTolerance)
								_accelIntegral = 0f;
							else
								_accelIntegral += accel;
							_preDiff = diff;
							_preValue = _value;
							_value = curValue;
							if(_value != _preValue)
							{
								if(OnDragMove != null)
									OnDragMove(this, null);
							}
						}
						else
						{
							_drag = false;
							if(OnDragEnd != null)
								OnDragEnd(this, null);
						}
					}
					else
					{
						if(curValue > dragMinRatio && curValue < dragMaxRatio)
						{
							_drag = true;
							_value = curValue;
							_startValue = _value;
							_preValue = _value;
							_preDiff = 0f;
							_accelIntegral = 0f;
							if(OnDragStart != null)
								OnDragStart(this, null);
						}
					}
				}
				else
				{
					if(_drag == true)
					{
						Reset();
						if(OnDragEnd != null)
							OnDragEnd(this, null);
					}
				}
			}		
		}

		void Reset()
		{
			_drag = false;
			_value = 0f;
			_startValue = _value;
			_preValue = _value;
			_preDiff = 0f;
			_accelIntegral = 0f;
		}

		public bool isDragging
		{
			get
			{
				return _drag;
			}
		}

		public float Value
		{
			get
			{
				return _value;
			}
		}

		public float DragForce
		{
			get
			{
				return (_value - _startValue) * _accelIntegral * dragForceScaler;
			}
		}
	}
}
