using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

	private Transform player;

	public float speed = 2;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag(Tags.player).transform;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 targetPos = player.position + new Vector3(0, 3f, -3f);//摄像机注视
		transform.position = Vector3.Lerp(transform.position, targetPos, speed * Time.deltaTime);
		Quaternion targetRotation= Quaternion.LookRotation(player.position - transform.position);//摄像机旋转角度注视
		transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);
	}
}
