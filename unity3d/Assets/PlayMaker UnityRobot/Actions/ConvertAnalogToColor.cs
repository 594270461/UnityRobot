using UnityEngine;
using System.Collections;
using UnityRobot;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("UnityRobot")]
	[Tooltip("Convert Analog value to Color")]
	public class ConvertAnalogToColor : FsmStateAction
	{
		[RequiredField]
		[Tooltip("ADC Red")]
		public ADCModule adcRed;

		[RequiredField]
		[Tooltip("ADC Green")]
		public ADCModule adcGreen;

		[RequiredField]
		[Tooltip("ADC Blue")]
		public ADCModule adcBlue;

		[RequiredField]
		[UIHint(UIHint.Variable)]
		[Tooltip("Color Value")]
		public FsmColor colorValue;


		public override void OnEnter ()
		{
			base.OnEnter ();

			if(adcRed == null)
				Debug.LogWarning("There exist no ADCModule for Red!");

			if(adcGreen == null)
				Debug.LogWarning("There exist no ADCModule for Green!");

			if(adcBlue == null)
				Debug.LogWarning("There exist no ADCModule for Blue!");
		}
		
		
		public override void OnUpdate()
		{
			if(adcRed != null && adcGreen != null && adcBlue != null)
			{
				colorValue.Value = new Color((1024 - adcRed.Value) / 1024f
				                             ,(1024 - adcGreen.Value) / 1024f
				                             ,(1024 - adcBlue.Value) / 1024f);
			}
		}
	}
}