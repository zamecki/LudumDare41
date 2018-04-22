using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float downForce = 1f;
    public float jumpForce = 1f;
    public float downMaxSpeed = 1f;
    public float speed = 1f;
    private bool jump = false;
    private bool jumping = false;
    public LayerMask groundLayer;
    public bool attacking = false;
    public bool attack = false;
    public float engageSpeed;
    private bool dead = false;
    private bool hasFinished = false;
    private Rigidbody2D rb;
    public Transform weapon;
    private Quaternion heldRotation;
    private RaycastHit2D hit;

    public Transform upFace;
    public Transform downFace;

    public AudioClip walk;
    private AudioSource audioSource;
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = walk;
        audioSource.playOnAwake = true;
        audioSource.Play();
        audioSource.loop = true;
        audioSource.volume = 0.05f;
        heldRotation = weapon.rotation;
    }
	
	void Update () {
        if (dead || hasFinished)
        {
            return;
        }
        Debug.DrawRay(transform.position, -transform.up, Color.red);
        jumping = !Physics2D.Raycast(transform.position, -transform.up, 0.1f, groundLayer);
        if (jumping)
            audioSource.Pause();
        else audioSource.UnPause();
        Debug.DrawLine(upFace.position, downFace.position, Color.red);
        if(Physics2D.Linecast(upFace.position, downFace.position, groundLayer))
        {
            Flip();
        }

    }
    void FixedUpdate()
    {
        if (dead || hasFinished)
        {
            return;
        }
        rb.velocity = new Vector2(speed * transform.localScale.x, rb.velocity.y);
        if (jump)
        {
            rb.velocity = new Vector2(speed, 0);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jump = false;
        }

        if (rb.velocity.y < 0)
            if (rb.velocity.y > -downMaxSpeed)
                rb.AddForce(Vector2.up * Physics2D.gravity.y * downForce, ForceMode2D.Force);
            else rb.velocity = new Vector2(rb.velocity.x, -downMaxSpeed);
    }
    public void Finished() {
        hasFinished = true;
    }
    public void Die()
    {
        dead = true;
    }
    public void Flip()
    {
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
    public void Jump()
    {
        if (jumping)
            return;

        jump = true;
    }
    public void Attack()
    {
        if (attacking)
            return;

        StartCoroutine(AttackMovement());
    }
    IEnumerator AttackMovement() {
        attacking = true;
        weapon.localRotation = Quaternion.Euler(0, 0, -90);

        yield return new WaitForSeconds(1f);

        weapon.localRotation = Quaternion.Euler(0, 0, 0);
        attacking = false;
    }
}
