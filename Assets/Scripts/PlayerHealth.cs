using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public bool dead = false;
    private bool notifyDeath = true;
    public int hp = 3;
    public int maxHp = 5;
    public float spacing = 1;
    private Transform heartsHolder;
    public GameObject hearts;
    public GameObject heartSound;
    private AudioSource audioSource;
    public AudioClip hurtClip;
    public bool isStartScene = false;
    // Use this for initialization
    void Start () {
        heartsHolder = GameObject.Find("HeartsHolder").transform;
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        StartCoroutine(DrawHearts());

    }
    IEnumerator DrawHearts()
    {
        for (int i = 0; i < heartsHolder.childCount; i++)
        {
            Destroy(heartsHolder.GetChild(i).gameObject);
        }
        yield return new WaitForEndOfFrame();
        for (int i = heartsHolder.childCount; i < hp; i++)
        {
            Vector2 pos = new Vector2(heartsHolder.position.x + i * spacing, heartsHolder.position.y);
            GameObject heart = Instantiate(hearts, pos, Quaternion.identity);
            heart.transform.parent = heartsHolder;
            yield return new WaitForSeconds(0.1f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isStartScene)
        {
            if (collision.tag == "Bullet")
            {
                GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().EndLevel();
                isStartScene = false;
            }
        }
        if (collision.tag == "Enemy")
        {
            hp--;
            audioSource.clip = hurtClip;
            audioSource.Play();
            if (hp <= 0)
            {
                dead = true;
                if (notifyDeath)
                {
                    GetComponent<PlayerMovement>().Die();
                    GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().PlayerDied();
                    notifyDeath = false;
                }
                
            }
            StartCoroutine(DrawHearts());
        }
        if (collision.tag == "Heart")
        {
            if (hp < maxHp)
            {
                hp++;
                StartCoroutine(DrawHearts());
                Instantiate(heartSound, transform.position, Quaternion.identity);
                Destroy(collision.gameObject);
            }
            StartCoroutine(DrawHearts());
        }
        if (collision.tag == "Finish")
        {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().EndLevel();
            GetComponent<PlayerMovement>().Finished();
        }
    }
}
