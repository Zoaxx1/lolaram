using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HabilityNexus : MonoBehaviour
{
    [SerializeField] private List<GameObject> prefabsList = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject prefab in prefabsList)
        {
            Instantiate(prefab, new Vector3(transform.position.x, 5f, transform.position.z), Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
