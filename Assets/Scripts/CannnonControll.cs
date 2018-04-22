using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannnonControll : MonoBehaviour {


    public Color neutralColor;
    public Color jumpColor;
    public Color attackColor;
    public Color flipColor;

    string currentAction = "Action";
    bool shoot = false;
    public Transform barrel;
    public GameObject bulletPrefab;
    SpriteRenderer sr;
    Quaternion rot;
    AudioSource audio;
    private KeyCode lastKey;
    private bool QActive = true;
    public bool WActive;
    public bool EActive;
    private bool start = true;
    void Start () {
        sr = GetComponent<SpriteRenderer>();
        audio = GetComponent<AudioSource>();
        lastKey = KeyCode.Q;
    }
	
	// Update is called once per frame
	void Update () {
        float camDis = Camera.main.transform.position.y - transform.position.y;

        // Get the mouse position in world space. Using camDis for the Z axis.
        Vector3 mouse = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, camDis));

        float AngleRad = Mathf.Atan2(mouse.y - transform.position.y, mouse.x - transform.position.x);
        float angle = (180 / Mathf.PI) * AngleRad;
        rot = Quaternion.Euler(0, 0, angle + 90);
        transform.rotation = rot;

        if (Input.GetMouseButtonDown(0))
        {
            ChangeAction(lastKey);
            shoot = true;
        }
        if(Input.GetKeyDown(KeyCode.Q) && QActive)
        {
            ChangeAction(KeyCode.Q);
            shoot = true;
        }
        else if (Input.GetKeyDown(KeyCode.W) && WActive)
        {
            shoot = true;
            ChangeAction(KeyCode.W);
        }
        else if (Input.GetKeyDown(KeyCode.E) && EActive)
        {
            shoot = true;
            ChangeAction(KeyCode.E);
        }
    }
    public void ChangeAction(KeyCode key)
    {
        lastKey = key;
        switch (key)
        {
            case KeyCode.Q:
                currentAction = ActionTags.JUMP;
                sr.color = GetActionColor(currentAction);
                break;
            case KeyCode.W:
                currentAction = ActionTags.FLIP;
                sr.color = GetActionColor(currentAction);
                break;
            case KeyCode.E:
                currentAction = ActionTags.ATTACK;
                sr.color = GetActionColor(currentAction);
                break;

        }
        if (start)
        {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().StartLevel();
            start = false;
        }
    }
    public Color GetActionColor(string actionTag) {
        if (actionTag == ActionTags.JUMP)
            return jumpColor;
        else if (actionTag == ActionTags.ATTACK)
            return attackColor;
        else if (actionTag == ActionTags.FLIP)
            return flipColor;
        return neutralColor;
    }

    private void FixedUpdate()
    {
        if(shoot)
        {
            audio.Play();

            GameObject bullet = Instantiate(bulletPrefab, barrel.position, rot);
            bullet.GetComponent<BulletControll>().SetAction(currentAction, GetActionColor(currentAction));
            shoot = false;
        }
    }
}
