using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AwardType
{
	Gun,
	DualSword
}

public class AwardItem : MonoBehaviour {
    public AwardType type;
    public float speed = 8;

    private bool startMove=false;
    private Transform player;
    public AudioClip pickupClip;

    private Rigidbody rigidbody;//私有变量
    private Animator anim;
    void Start()
    {
        anim = this.GetComponent<Animator>();
        rigidbody = this.GetComponent<Rigidbody>();//给变量获取Rigidbody组件，然后就可以了
        rigidbody.velocity = new Vector3(Random.Range(-5, 5), 0, Random.Range(-5, 5));
    }
    
    void Update()
    {
        if(startMove)
        {
            transform.position = Vector3.Lerp(transform.position, player.position+Vector3 .up,speed *Time.deltaTime);
            if(Vector3.Distance (transform .position ,player .position+Vector3 .up )< 0.5f)
            {
                player.GetComponent<PlayerAward>().GetAward(type);
                Destroy (this.gameObject);
                AudioSource.PlayClipAtPoint(pickupClip, transform.position, 1f);
            }
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag==Tags.ground)
        {
            rigidbody.useGravity = false;
            rigidbody.isKinematic = true;
            SphereCollider col=this.GetComponent <SphereCollider>();
            col.isTrigger = true;
            col.radius = 2;
        }
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == Tags.player)
        {
            startMove = true;
            player = col.transform;
        }
    }
}
