using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

	private CharacterController cc;
	private Animator animator;
	public float speed = 4;

	void Awake()
	{
		cc = this.GetComponent<CharacterController>();
		animator = this.GetComponent<Animator>();
	}
	
	
	// Update is called once per frame
	void Update () {
		float h = Input.GetAxis("Horizontal");//水平位置
		float v = Input.GetAxis("Vertical");//垂直位置
		
		//按键的取值，以虚拟杆中的值优先；
		if (Joystick.h != 0 || Joystick.v != 0)
		{
			h = Joystick.h;v = Joystick.v;
		}


		if (Mathf.Abs(h) > 0.1f || Mathf.Abs(v) > 0.1)
		{
			animator.SetBool("Walk", true);
			if (animator.GetCurrentAnimatorStateInfo(0).IsName("PlayerRun"))
			{
				Vector3 targetDir = new Vector3(h, 0, v);
				//targetDir.y = transform.position.y;//Y轴不变
				transform.LookAt(targetDir + transform.position);//朝向目标位置,这个算上了Y轴不变

				cc.SimpleMove(transform.forward * speed);
			}
		}
		else
		{
			animator.SetBool("Walk", false);
		}
	}
}
