using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    //public GameObject lastCheckpoint;
    public static SaveData Instance;
    public Vector3 lastCheckpoint;
    public GameObject[] test;
    public List<GameObject> test2;
	private void Awake()
	{
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
