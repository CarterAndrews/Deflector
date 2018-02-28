using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour {
    public float initialSpawnRate;
    public Bullet bulletPrefab;
    public float timeSinceLastSpawn;
    public Transform origin;
    public float delay;
    public bool delayed;
	// Use this for initialization
	void Start () {
        transform.LookAt(origin);
        transform.rotation = Quaternion.Euler(new Vector3(transform.eulerAngles.x + 90, transform.eulerAngles.y, transform.eulerAngles.z));
        StartCoroutine(delayer());
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (!delayed)
        {
            timeSinceLastSpawn++;
            if (timeSinceLastSpawn > initialSpawnRate)
            {
                Instantiate(bulletPrefab, transform.position, transform.rotation);
                timeSinceLastSpawn = 0;
            }
        }
    }    
    private IEnumerator delayer()
    {
        delayed = true;
        yield return new WaitForSeconds(delay);
        delayed = false;
    }
}
