using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy2_Spawn : MonoBehaviour
{
    [SerializeField]
    GameObject enemy2;
    [SerializeField]
    GameObject coin;
    [SerializeField]
    TMP_Text scoreText;
    [SerializeField]
    TMP_Text timeText;
    // Start is called before the first frame update
    public int score = 0;
    [SerializeField]
    int spawnRate;
    int spawnTimer;
    int gameTimer = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameTimer > 1000)
        {
            spawnRate = 60;
        }
        if (gameTimer > 2000)
        {
            spawnRate = 40;
        }
        /*
        if (Random.Range(0f, 60f) > 58f)
        {
            var position = new Vector3(-12f, Random.Range(-5.0f, 5.0f), 1f);
            GameObject newEnemy2 = Object.Instantiate(enemy2, position, enemy2.transform.rotation);
            //newEnemy2.transform.position = position
        }
        */
        /*
        if (spawnTimer != 0)
        {
            spawnTimer--;
        }
        else
        {
            Debug.Log("Game Timer: " + gameTimer);
            spawnTimer = spawnRate;
            spawnGameObject(enemy2);
            spawnGameObject(coin);
        }
        */
        if(gameTimer % spawnRate == 0)
        {
            Debug.Log("Game Timer: " + gameTimer);
            spawnTimer = spawnRate;
            spawnGameObject(enemy2);
            //spawnGameObject(coin);
        }
        else if (gameTimer % (spawnRate/2) == 0)
        {
            Debug.Log("Game Timer: " + gameTimer);
            spawnTimer = spawnRate;
            //spawnGameObject(enemy2);
            spawnGameObject(coin);
        }


        //score += 100;
        //score++;
        scoreText.SetText(score.ToString());

        gameTimer++;
        timeText.SetText(gameTimer.ToString());
    }

    void spawnGameObject(GameObject obj)
    {
        float xPos = -12f;
        //Debug.Log(Random.Range(0, 2));
        if (Random.Range(0, 2) == 1)
        {
            xPos = 12f;
        }
        var position = new Vector3(xPos, Random.Range(-4.5f, 4.5f), 1f);
        GameObject newGameObject = Object.Instantiate(obj, position, obj.transform.rotation);
        if (xPos == 12f)
        {
            newGameObject.transform.Rotate(0f, 0f, 180f, Space.Self);
            EnemyMovement2 enemyMovement2 = newGameObject.GetComponent<EnemyMovement2>();
            enemyMovement2.startingDirection = -1;
        }
    }
}
