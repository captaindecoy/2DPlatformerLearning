using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy2_Spawn : MonoBehaviour
{
    [SerializeField]
    GameObject enemy2;
    [SerializeField]
    TMP_Text scoreText;
    // Start is called before the first frame update
    int score = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Random.Range(0f, 60f) > 58f)
        {
            var position = new Vector3(-12f, Random.Range(-10.0f, 10.0f), 1f);
            GameObject newEnemy2 = Object.Instantiate(enemy2, position, enemy2.transform.rotation);
            //newEnemy2.transform.position = position
        }
        //score += 100;
        score++;
        scoreText.SetText(score.ToString());
    }
}
