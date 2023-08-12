using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectedWarp : MonoBehaviour
{
    [SerializeField]
    GameObject connectedWarp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public GameObject getTopWarp()
    {
        return connectedWarp;
    }
}
