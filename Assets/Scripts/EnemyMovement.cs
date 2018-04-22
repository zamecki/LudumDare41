using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public float speed;
    public Transform pointA;
    public Transform pointB;
    private Transform target;
    private bool tB = true;
    void Start () {
        SwapTarget();

    }
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        if (Mathf.Abs(transform.position.x - target.position.x) <= 0.1f)
        {
            SwapTarget();
        }
	}
    void SwapTarget() {
        if (tB)
            target = pointA;
        else target = pointB;

        tB = !tB;
    }
}
