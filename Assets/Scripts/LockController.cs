using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockController : MonoBehaviour {

    public bool locked = true;
    private Collider2D collider;
    public GameObject topPart;
	void Start () {
        collider = GetComponent<Collider2D>();

    }
	
	// Update is called once per frame
	void Update () {
        collider.enabled = locked;

    }


    public void Unlock() {
        locked = false;
        topPart.transform.localPosition = new Vector3(0.5f, 0, 0);
    }
}
