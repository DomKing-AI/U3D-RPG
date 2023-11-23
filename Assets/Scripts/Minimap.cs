using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour {

	public static Minimap _instance;
	private Transform playerIcon;
	public GameObject enemyIconPrefab;

	void Awake()
	{
		_instance = this;
		playerIcon = transform.Find("PlayerIcon");
	}

	public Transform GetPlayerIcon()
	{
		return playerIcon;
	}

	public GameObject GetBossIcon()
	{
		GameObject go= NGUITools.AddChild(this.gameObject, enemyIconPrefab);
		go.GetComponent<UISprite>().spriteName = "BossIcon";
		return go;
	}
	public GameObject GetMonsterIcon()
	{
        GameObject go = NGUITools.AddChild(this.gameObject, enemyIconPrefab);
        go.GetComponent<UISprite>().spriteName = "EnemyIcon";
        return go;
    }
}
