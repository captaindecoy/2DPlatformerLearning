using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    [SerializeField]
    int duration = 180;
    int timer = 180; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position;
    }

	private void FixedUpdate()
	{
        if (timer > 0)
        {
            timer--;
        }
        else
        {
            timer = duration;
            gameObject.SetActive(false);
        }
	}

	private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Object.Destroy(collision.gameObject);
            //SceneManager.LoadScene("Level1-1");
        }
    }
}
