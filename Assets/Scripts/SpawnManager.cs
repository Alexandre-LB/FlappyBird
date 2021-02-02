using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private bool canSpawn = true;
    public GameObject Rock;
    private static SpawnManager _instance;
    public static SpawnManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("The SapwnManger is NULL.");
            }

            return _instance;
        }
    }

    public void Awake()
    {
        _instance = this;
    }

    public void StartSpawning()
    {
        if (canSpawn)
        {
            canSpawn = false;
            GameObject Go;
            Go = Instantiate(Rock, transform.position, Quaternion.identity);
            Go.name = "Rock";
            transform.position = new Vector3(transform.position.x, Random.Range(2.4f, -2.2f), transform.position.z);
            StartCoroutine(SpawnPause());
        }
    }

    IEnumerator SpawnPause()
    {
        canSpawn = false;
        yield return new WaitForSeconds(2.3f);
        canSpawn = true;
    }
}
