using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PGoal : MonoBehaviour
{
    public PLevelManager lm;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Puck")
        {
            lm.Goal();
        }
    }
}
