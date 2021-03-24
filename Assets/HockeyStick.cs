using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HockeyStick : MonoBehaviour
{
    /*
    * Credit for code goes to:
    * https://www.youtube.com/watch?v=WxHdWiyQB1g&ab_channel=DeanomiteGames
    */

    public GameObject player;
    public float distance = 2f;
    public Rigidbody2D rb;

    private Vector3 v3Pos;
    private float angle;

    void FixedUpdate()
    {
        v3Pos = Input.mousePosition;
        v3Pos.z = player.transform.position.z - Camera.main.transform.position.z;
        v3Pos = Camera.main.ScreenToWorldPoint(v3Pos);
        v3Pos -= player.transform.position;
        angle = Mathf.Atan2(v3Pos.y, v3Pos.x) * Mathf.Rad2Deg;
        if (angle < 0f)
        {
            angle += 360f;
        }
        transform.localEulerAngles = new Vector3(0, 0, angle);
        float xpos = Mathf.Cos(angle * Mathf.Deg2Rad) * distance;
        float ypos = Mathf.Sin(angle * Mathf.Deg2Rad) * distance;
        Vector3 updatedPos = new Vector3(xpos * transform.localScale.x + player.transform.position.x, ypos * transform.localScale.y + player.transform.position.y, 0);
        //updatedPos = transform.TransformDirection(updatedPos);
        rb.MovePosition(updatedPos);
    }
}
