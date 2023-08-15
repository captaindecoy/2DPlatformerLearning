using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
        Debug.Log("HIT");
        if (collision.gameObject.CompareTag("Coin") || collision.gameObject.CompareTag("Enemy"))
        {
            Object.Destroy(collision.gameObject);
        }
    }
}
