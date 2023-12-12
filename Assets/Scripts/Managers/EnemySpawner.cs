using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> enemyTypes = new List<GameObject>();
    [SerializeField] List<GameObject> destruction = new List<GameObject>();
        
    [SerializeField] int amtOfEnemies;
    [SerializeField] int destructionAmt;

    [SerializeField] List<GameObject> pickups = new List<GameObject>();
    [SerializeField] int amtOfPickups;

    [SerializeField] bool isEnemySpawner;
    // Start is called before the first frame update
    void Start()
    {
        if (isEnemySpawner)
        {
            int max = enemyTypes.Count;

            for (int i = 0; i < amtOfEnemies; i++)
            {
                GameObject enemy = Instantiate(enemyTypes[UnityEngine.Random.Range(0, max)]);

                enemy.transform.SetParent(this.transform, transform.parent);

                enemy.transform.position = this.transform.position +
                    new Vector3(UnityEngine.Random.Range(-0.5f, 0.5f),
                                        UnityEngine.Random.Range(-0.5f, 0.5f),
                                            0);
            }

            int destructionAmt = destruction.Count;

            for (int i = 0; i < destructionAmt; i++)
            {
                GameObject des = Instantiate(destruction[UnityEngine.Random.Range(0, max)]);

                des.transform.SetParent(this.transform, transform.parent);

                des.transform.position = this.transform.position +
                    new Vector3(UnityEngine.Random.Range(-0.8f, 0.8f),
                                        UnityEngine.Random.Range(-0.8f, 0.8f),
                                            0);
            }
        }
        else if (!isEnemySpawner)
        {
            int max = pickups.Count;

            for (int i = 0; i < amtOfPickups; i++)
            {
                GameObject pickup = Instantiate(pickups[UnityEngine.Random.Range(0, max)]);

                pickup.transform.SetParent(this.transform, transform.parent);

                pickup.transform.position = this.transform.position +
                    new Vector3(UnityEngine.Random.Range(-0.5f, 0.5f),
                                        UnityEngine.Random.Range(-0.5f, 0.5f),
                                            0);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
