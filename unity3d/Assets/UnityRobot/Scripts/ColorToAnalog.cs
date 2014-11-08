using UnityEngine;
using System.Collections;
using System;

namespace UnityRobot
{
	[AddComponentMenu("UnityRobot/ColorToAnalog")]
	public class ColorToAnalog : MonoBehaviour
	{
		public DigitalPin pwmRed;
		public DigitalPin pwmGreen;
		public DigitalPin pwmBlue;

		private Color _color;

		void Awake()
		{
			if(pwmRed != null)
				pwmRed.OnConnected += OnConnectedRed;
			if(pwmGreen != null)
				pwmGreen.OnConnected += OnConnectedGreen;
			if(pwmBlue != null)
				pwmBlue.OnConnected += OnConnectedBlue;
		}

		// Use this for initialization
		void Start ()
		{
		
		}
		
		// Update is called once per frame
		void Update ()
		{
		
		}

		public Color color
		{
			get
			{
				return _color;
			}
			set
			{
				if(_color != value)
				{
					_color = value;
					if(pwmRed != null)
						pwmRed.analogValue = _color.r;
					if(pwmGreen != null)
						pwmGreen.analogValue = _color.g;
					if(pwmBlue != null)
						pwmBlue.analogValue = _color.b;
				}
			}
		}

		private void OnConnectedRed(object sender, EventArgs e)
		{
			_color.r = pwmRed.analogValue;
		}

		private void OnConnectedGreen(object sender, EventArgs e)
		{
			_color.g = pwmGreen.analogValue;
		}

		private void OnConnectedBlue(object sender, EventArgs e)
		{
			_color.b = pwmBlue.analogValue;
		}
	}
}