using UnityEngine;
using System.Collections;
using UnityRobot;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("UnityRobot")]
	[Tooltip("Convert Analog value to Balance parameter")]
	public class ConvertAnalogToBalance : FsmStateAction
	{
		[RequiredField]
		[Tooltip("ADC +X axis")]
		public ADCModule pxAxis;

		[RequiredField]
		[Tooltip("ADC -X axis")]
		public ADCModule mxAxis;

		[RequiredField]
		[Tooltip("ADC +Y axis")]
		public ADCModule pyAxis;

		[RequiredField]
		[Tooltip("ADC -Y axis")]
		public ADCModule myAxis;

		[Tooltip("Sensitivity Value")]
		public FsmFloat sensitivity;

		[Tooltip("Angle scale value")]
		public FsmFloat scaleAngle;

		[Tooltip("Height scale value")]
		public FsmFloat scaleHeight;
		
		[RequiredField]
		[UIHint(UIHint.Variable)]
		[Tooltip("Angle Value")]
		public FsmVector2 angleValue;

		[RequiredField]
		[UIHint(UIHint.Variable)]
		[Tooltip("Height Value")]
		public FsmFloat heightValue;


		ArrayList _buffer = new ArrayList();
		float _sensitivity;
		ushort _pxValue;
		ushort _mxValue;
		ushort _pyValue;
		ushort _myValue;
		Vector2 _angle = new Vector2();
		float _height;		
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			
			if(pxAxis == null)
				Debug.LogWarning("There exist no ADCModule for +X axis!");
			
			if(mxAxis == null)
				Debug.LogWarning("There exist no ADCModule for -X axis!");
			
			if(pyAxis == null)
				Debug.LogWarning("There exist no ADCModule for +Y axis!");

			if(myAxis == null)
				Debug.LogWarning("There exist no ADCModule for -Y axis!");
		}
		
		
		public override void OnUpdate()
		{
			if(pxAxis != null && mxAxis != null && pyAxis != null && myAxis != null)
			{

			}
		}
	}
}