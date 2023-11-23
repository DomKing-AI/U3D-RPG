using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulBossATKAndDamage : ATKAndDamage {

    private Transform player;
    public AudioClip attackClip;
    void Awake()
    {
        base.Awake();
        player = GameObject.FindGameObjectWithTag(Tags.player).transform;
    }

    public void Attack1()
	{
        AudioSource.PlayClipAtPoint(attackClip, transform.position, 0.5f);
        if (Vector3.Distance(transform.position, player.position) < attackDistance)
        {
            player.GetComponent<ATKAndDamage>().TakeDamage(normalAttack);
        }
    }
	public void Attack2()
	{
        AudioSource.PlayClipAtPoint(attackClip, transform.position, 1f);
        if (Vector3.Distance(transform.position, player.position) < attackDistance)
        {
            player.GetComponent<ATKAndDamage>().TakeDamage(normalAttack);
        }
    }
}
