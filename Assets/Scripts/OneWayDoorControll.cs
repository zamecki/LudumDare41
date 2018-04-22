using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayDoorControll : MonoBehaviour {

    private Collider2D collider;
    private Transform player;
    private bool leftToRight = false;
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        collider = GetComponent<Collider2D>();
        leftToRight = transform.localScale.x < 0;

    }
	
	// Update is called once per frame
	void Update () {
        if (leftToRight)
            collider.enabled = player.position.x > transform.position.x + 0.5f;
        else collider.enabled = transform.position.x - player.position.x > 0.5f;
    }
}
