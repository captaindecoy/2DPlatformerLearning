using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LockedFloor : MonoBehaviour
{
    public List<GameObject> keys;
    private int emptyCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    // Really shouldn't need to process the key check everyframe
    void Update()
    {
        for (int i = 0; i < keys.Count; i++)
        {
            if (keys[i] == null)
            {
                keys.RemoveAt(i);
            }
        }
        //Debug.Log("Keys: " + keys.Count);
        if (keys.Count == 0)
        {
            Object.Destroy(gameObject);
        }
    }
}
