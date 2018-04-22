using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public GameObject haha;
    public GameObject pop;
    private bool play = true;
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Weapon")
        {
            transform.tag = "Untagged";
            Instantiate(pop);
            Destroy(gameObject);
        } else if (collision.tag == "Player")
        {
            if (!play)
                return;
            Instantiate(haha);
        }
            
    }
}
