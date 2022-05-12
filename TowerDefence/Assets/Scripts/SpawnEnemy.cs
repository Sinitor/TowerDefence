using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject[] prefabs;
    public static int rep;
    public int maxSpawn;
    private void Start()
    {
        StartCoroutine(Spawn());
    }
    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(2f);
        Instantiate(prefabs[Random.Range(0, 3)], transform.position, Quaternion.identity);
        Repeat();
    }
    private void Repeat()
    {
        if (rep <= maxSpawn)
        {
            StartCoroutine(Spawn());
        }
    }
}
