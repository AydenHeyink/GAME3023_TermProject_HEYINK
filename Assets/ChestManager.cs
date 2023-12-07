using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestManager : MonoBehaviour
{
    [SerializeField] List<GameObject> pickups= new List<GameObject>();

    public void OpenChest()
    {
        int max = pickups.Count;
        int rand = UnityEngine.Random.Range(6, (18 + PlayerStats.luck));

        for (int i = 0; i < rand; i++) 
        {
            GameObject pick = Instantiate(pickups[UnityEngine.Random.Range(0, max)]);

            pick.transform.position = this.transform.position +
                 new Vector3(UnityEngine.Random.Range(-0.3f, 0.3f),
                                     UnityEngine.Random.Range(-0.3f, 0.3f),
                                         0);
        }

        Destroy(this.gameObject);
    }
}
