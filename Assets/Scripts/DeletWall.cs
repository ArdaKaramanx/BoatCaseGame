using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeletWall : MonoBehaviour
{
    int boatCount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("boat"))
        {
            Destroy(collision.gameObject);
            boatCount++;
            if (boatCount == 3)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
