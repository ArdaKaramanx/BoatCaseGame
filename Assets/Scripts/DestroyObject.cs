using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{

    AudioSource source;
    public AudioClip dropSeaObject;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Launch") && collision.GetComponent<LaunchEats>().isDroped)
        {
            GameObject a = collision.gameObject;
            source.PlayOneShot(dropSeaObject);
            a.GetComponent<SpriteRenderer>().enabled = false;
            a.GetComponent<BoxCollider2D>().enabled = false;
            StartCoroutine(DestroyA(a));
        }
    }

    IEnumerator DestroyA(GameObject a)
    {
        yield return new WaitForSeconds(5);
        Destroy(a.gameObject);
    }

}
