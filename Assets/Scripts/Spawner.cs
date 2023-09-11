using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Boats")]
    public GameObject[] allBoat;

    [Header("Eeat Object")]
    public GameObject meat; 
    public GameObject grass; 
    public GameObject meatAndGrass;

    [Header("Eeat Object Point")]
    public GameObject meatPoint; 
    public GameObject grassPoint;
    public GameObject meatAndGrassPoint;

    void Start()
    {
       StartCoroutine(BoatSpawning()); 
    }

    IEnumerator BoatSpawning()
    {
        Instantiate(allBoat[0]).transform.position = transform.position;
        yield return new WaitForSeconds(25);
        Instantiate(allBoat[1]).transform.position = transform.position;
        yield return new WaitForSeconds(25);
        Instantiate(allBoat[2]).transform.position = transform.position;
    }

    public IEnumerator SpawningLaunchObject(int objectNum)
    {
        yield return new WaitForSeconds(3);
        switch (objectNum)
        {
            case 0:
                GameObject meatObject = Instantiate(meat);
                meatObject.transform.position = meatPoint.transform.position;
                meatObject.GetComponent<SpringJoint2D>().connectedBody = meatPoint.GetComponent<Rigidbody2D>();
                meatObject.GetComponent<LaunchEats>().sp = this;
                break;
            case 1:
                GameObject grassObject = Instantiate(grass);
                grassObject.transform.position = grassPoint.transform.position;
                grassObject.GetComponent<SpringJoint2D>().connectedBody = grassPoint.GetComponent<Rigidbody2D>();
                grassObject.GetComponent<LaunchEats>().sp = this;
                break;
            case 2:
                GameObject meatAndGrassPointObject = Instantiate(meatAndGrass);
                meatAndGrassPointObject.transform.position = meatAndGrassPoint.transform.position;
                meatAndGrassPointObject.GetComponent<SpringJoint2D>().connectedBody = meatAndGrassPoint.GetComponent<Rigidbody2D>();
                meatAndGrassPointObject.GetComponent<LaunchEats>().sp = this;
                break;
        }
    }

}
