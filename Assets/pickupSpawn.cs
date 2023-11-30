using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupSpawn : MonoBehaviour
{
    [SerializeField] List<GameObject> pickups = new List<GameObject>();
    [SerializeField] int amtOfPickups;
    // Start is called before the first frame update
    void Start()
    {
        int max = pickups.Count;

        for (int i = 0; i < amtOfPickups; i++)
        {
            GameObject pickup = Instantiate(pickups[UnityEngine.Random.Range(0, max)]);

            pickup.transform.position = this.transform.position +
                new Vector3(UnityEngine.Random.Range(-0.5f, 0.5f),
                                    UnityEngine.Random.Range(-0.5f, 0.5f),
                                        0);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
