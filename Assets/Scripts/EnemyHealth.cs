using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public AudioClip haha;
    public AudioClip pop;
    private AudioSource source;
    private bool play = true;
    void Start () {
        source = GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Weapon")
        {
            transform.tag = "Untagged";
            source.clip = pop;
            source.Play();
            play = false;
            Destroy(gameObject, 0.1f);
        } else if (collision.tag == "Player")
        {
            if (!play)
                return;
            source.clip = haha;
            source.Play();
        }
            
    }
}
