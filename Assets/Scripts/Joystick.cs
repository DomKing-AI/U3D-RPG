using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick : MonoBehaviour
{

	private bool isPress = false;
	private Transform button;//定义按键
	public static float h = 0;
	public static float v = 0;
	void Awake()
	{
		button = transform.Find("Button");
	}

	void OnPress(bool isPress)
	{
		this.isPress = isPress;
		if (isPress == false)
		{
			button.localPosition = Vector3.zero;//鼠标抬起按键归0;
			h = 0;v = 0;
		}
	}

	void Update()
	{
		if (isPress)
		{
			Vector2 touchPos = UICamera.lastTouchPosition;
			touchPos -= new Vector2(120, 120);
			float distance = Vector2.Distance(Vector2.zero, touchPos);
			if (distance > 90)//限制范围；
			{
				touchPos = touchPos.normalized * 90;
			}
			else
			{
				button.localPosition = touchPos;//把触摸位置直接给按键；
			}
			//print(UICamera.lastTouchPosition);//检测位移变化
			h = touchPos.x / 90;
			v = touchPos.y / 90;
		}
	}
}