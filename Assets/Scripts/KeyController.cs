using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour {

	public GameObject locker;
    public AudioClip keySound;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        locker.GetComponent<LockController>().Unlock();
        GameObject sound = new GameObject();
        sound.AddComponent<AudioSource>();
        AudioSource audio = sound.GetComponent<AudioSource>();
        audio.playOnAwake = true;
        audio.clip = keySound;
        Instantiate(sound, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
