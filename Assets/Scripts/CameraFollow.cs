using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform player;
    private Vector2 velocity;
    public Vector2 offset;
    public float smoothTime;
    private float poz;
    void Start () {
        poz = transform.position.z;
    }

    private void Update()
    {

        Vector2 playerCameraPos = Camera.main.WorldToScreenPoint(player.position);

        float pox = transform.position.x;        
        if (playerCameraPos.x > Screen.width * 0.7 || playerCameraPos.x < Screen.width * 0.3)
        {
            pox = AjustX();
        }

        float poy = transform.position.y;
        if (playerCameraPos.y > Screen.height * 0.7 || playerCameraPos.y < Screen.height * 0.3)
        {
            pox = AjustY();
        }
        transform.position = new Vector3(pox, poy, poz);
    }

    float AjustX()
    {
        return Mathf.SmoothDamp(transform.position.x, player.position.x + offset.x, ref velocity.x, smoothTime);
    }
    float AjustY()
    {
        return Mathf.SmoothDamp(transform.position.y, player.position.y + offset.y, ref velocity.y, smoothTime);
    }
}
