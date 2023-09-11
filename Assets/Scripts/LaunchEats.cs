using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class LaunchEats : MonoBehaviour
{
    bool isPressed;

    float releaseDelay;
    float maxDragDistance = 3f;

    Rigidbody2D rb;
    SpringJoint2D sj;
    Rigidbody2D slingrb;

    AudioSource source;

    public bool isDroped;

    public AudioClip launch, stretching;

    public int mainNum;

    public Spawner sp;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sj = GetComponent<SpringJoint2D>();
        slingrb = sj.connectedBody;

        source = GetComponent<AudioSource>();

        releaseDelay = 1 / (sj.frequency * 4);
    }

    void Update()
    {
        if (isPressed)
        {
            DragLaunch();
        }
    }

    private void DragLaunch()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float distance = Vector2.Distance(mousePosition, slingrb.position);

        if (distance > maxDragDistance)
        {
            Vector2 direction = (mousePosition - slingrb.position).normalized;
            rb.position = slingrb.position + direction * maxDragDistance;
        }
        else
        {
            rb.position = mousePosition;
        }
    }

    private void OnMouseDown()
    {
        isPressed = true;
        rb.isKinematic = true;
        source.Stop();
        source.pitch = 2.5f;
        source.PlayOneShot(stretching);
    }

    private void OnMouseUp()
    {
        isPressed = false;
        rb.isKinematic = false;
        StartCoroutine(IsDrop());
        StartCoroutine(Release());
        source.Stop();
        source.pitch = 1f;
        source.PlayOneShot(launch);
    }

    IEnumerator IsDrop()
    {
        yield return new WaitForSeconds(0.5f);
        isDroped = true;
    }

    IEnumerator Release()
    {
        yield return new WaitForSeconds(releaseDelay);
        sj.enabled = false;
        StartCoroutine(sp.SpawningLaunchObject(mainNum));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("boat"))
        {
            Boat a = collision.GetComponent<Boat>();
            if (!a.requestCompleted && !a.isOutputFromAngle)
            {
                if (a.typeNum == mainNum)
                {
                    a.requestCompleted = true;
                    a.successObject.SetActive(true);
                    a.SoundPlayBell();
                    Destroy(gameObject);
                }
            }
        }
    }
}
