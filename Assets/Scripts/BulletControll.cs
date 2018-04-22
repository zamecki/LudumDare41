using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControll : MonoBehaviour {


    public float speed = 1f;
    Rigidbody2D rb;
    Color currentColor;
    string actionTag = "Action";
    void Start () {
        rb = GetComponent<Rigidbody2D>();
    }
    public void SetAction(string _actionTag, Color color) {
        actionTag = _actionTag;
        currentColor = color;
        GetComponent<SpriteRenderer>().color = color;
    }

	void Update () {
		
	}
    private void FixedUpdate()
    {
        rb.velocity = transform.up * -speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(actionTag == ActionTags.JUMP)
                collision.GetComponent<PlayerMovement>().Jump();
            else if(actionTag == ActionTags.ATTACK)
                collision.GetComponent<PlayerMovement>().Attack();
            else if (actionTag == ActionTags.FLIP)
                collision.GetComponent<PlayerMovement>().Flip();
            Destroy(gameObject);
        }
        
    }
}
