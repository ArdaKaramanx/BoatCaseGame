using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class Boat : MonoBehaviour
{

    [Header("Type")]
    public int typeNum;

    [Header("Completed")]
    public bool requestCompleted;
    public bool isOutputFromAngle;
    public GameObject successObject;
    public AudioClip shipBell;
    

    float speed = 1f;

    Rigidbody2D rb;

    AudioSource source;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.right * speed;
        source = GetComponent<AudioSource>();
    }

    public void SoundPlayBell()
    {
        source.PlayOneShot(shipBell);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("catapultMeat") && typeNum == 0)
        {
            isOutputFromAngle = true;
        }
        else if (collision.CompareTag("catapultWeed") && typeNum == 1)
        {
            isOutputFromAngle = true;
        }
        else if(collision.CompareTag("catapultOmnivorous") && typeNum == 2)
        {
            isOutputFromAngle = true;
        }
    }

}
