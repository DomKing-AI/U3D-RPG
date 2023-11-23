using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVillageAnimation : MonoBehaviour {

    private Rigidbody playerRigidbody;//私有变量
    private Animator anim;
    void Start()
    {
        anim = this.GetComponent<Animator>();
        playerRigidbody = this.GetComponent<Rigidbody>();//给变量获取Rigidbody组件，然后就可以了
    }


    void Update()
    {
        if (playerRigidbody.velocity.magnitude > 0.5)
        {

        }
    }
}
