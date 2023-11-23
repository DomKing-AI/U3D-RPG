using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDress : MonoBehaviour {

	public SkinnedMeshRenderer headRender;
	public SkinnedMeshRenderer handRender;

	public SkinnedMeshRenderer[] bodyArray; 

	// Use this for initialization
	void Start () {
		InitDress();
	}
	private void InitDress()
	{
		int headMeshIndex = PlayerPrefs.GetInt("HeadMeshIndex");
		int handMeshIndex = PlayerPrefs.GetInt("HandMeshIndex");
		int colorIndex = PlayerPrefs.GetInt("ColorIndex");
		headRender.sharedMesh = MenuController._instance.headMeshArray[headMeshIndex];
		handRender.sharedMesh = MenuController._instance.handMeshArray[handMeshIndex];
		//MenuController ._instance.headMeshArray[headMeshIndex] 
		foreach (SkinnedMeshRenderer render in bodyArray)
		{
			render.material.color = MenuController._instance.colorArray[colorIndex];  
		}
    }
}
