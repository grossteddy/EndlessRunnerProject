using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Spawner : MonoBehaviour
{
    [SerializeField] Pool[] pools;

    [SerializeField] PlayerMovment playerMovment;
    private Vector2 maxRange;

    [SerializeField] PlayerEvents playerEvents;

    // Start is called before the first frame update
    void Start()
    {
        if (playerMovment == null)
        {
            playerMovment = GameObject.Find("Ship").GetComponent<PlayerMovment>();
        }
        maxRange = playerMovment.GetComponent<PlayerMovment>().GetXYMaxRange();

        if (playerEvents == null)
        {
            playerEvents = GameObject.Find("ShipParent").GetComponent<PlayerEvents>();
        }
    }

    
    void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("SpawnTrigger"))
        {
            Quaternion quaternion = gameObject.transform.rotation;
            Vector3 pos = gameObject.transform.position;
            //SpawnPickUp(quaternion, pos);

            int rand = Random.Range(0, 100);

            if(rand <= 30)
            {
                SpawnEnemy(quaternion, pos);
            }

            else if (rand <= 90)
            {
                SpawnForceField(quaternion, pos);
            }

            else
            {
                SpawnHP(quaternion, pos);
            }
            
        }
    }

    private void SpawnEnemy(Quaternion quaternion, Vector3 pos)
    {
        GameObject pulled = pools[0].Pull(new Vector3(maxRange.y + pos.x, Random.Range(-maxRange.x + pos.y, maxRange.x + pos.y), pos.z),
                quaternion);
        pulled.GetComponent<Enemy>().collisionEvent = playerEvents;
        pulled.transform.parent = gameObject.transform;
    }

    private void SpawnForceField(Quaternion quaternion, Vector3 pos)
    {
        GameObject pulled = pools[1].Pull(new Vector3(Random.Range(0 + pos.x, maxRange.y + pos.x), pos.y, pos.z),
                quaternion);
        pulled.GetComponent<ForceField>().collisionEvent = playerEvents;
        pulled.transform.parent = gameObject.transform;
    }

    private void SpawnHP(Quaternion quaternion, Vector3 pos)
    {
        GameObject pulled = pools[2].Pull(new Vector3(Random.Range(-maxRange.y + pos.x, maxRange.y + pos.x), Random.Range(-maxRange.x + pos.y, maxRange.x + pos.y), pos.z),
                quaternion);
        pulled.GetComponent<HPScript>().collisionEvent = playerEvents;
        pulled.transform.parent = gameObject.transform;
    }
}
