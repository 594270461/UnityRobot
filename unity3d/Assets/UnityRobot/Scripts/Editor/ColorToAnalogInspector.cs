using UnityEngine;
using System.Collections;
using UnityEditor;
using System;
using UnityRobot;

[CustomEditor(typeof(ColorToAnalog))]
public class ColorToAnalogInspector : Editor
{
	public override void OnInspectorGUI()
	{
		ColorToAnalog colorToAnalog = (ColorToAnalog)target;

		colorToAnalog.pwmRed = (DigitalPin)EditorGUILayout.ObjectField("PWM Red", colorToAnalog.pwmRed, typeof(DigitalPin), true);
		colorToAnalog.pwmGreen = (DigitalPin)EditorGUILayout.ObjectField("PWM Green", colorToAnalog.pwmGreen, typeof(DigitalPin), true);
		colorToAnalog.pwmBlue = (DigitalPin)EditorGUILayout.ObjectField("PWM Blue", colorToAnalog.pwmBlue, typeof(DigitalPin), true);
		colorToAnalog.color = EditorGUILayout.ColorField("Color", colorToAnalog.color);
	}
}
