using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalBehavior : MonoBehaviour
{
    //[SerializeField] Object nextScene;
    private int currentSceneBuildIndex;
    private string nextScene;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Scene count: " + SceneManager.sceneCount);
        Debug.Log("By build index: " + SceneManager.GetSceneByBuildIndex(1).name);
        currentSceneBuildIndex = SceneManager.GetActiveScene().buildIndex;
        nextScene = SceneManager.GetSceneByBuildIndex(currentSceneBuildIndex + 1).name;
        Debug.Log("Next scene name: " + nextScene);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadNextScene()
    {
        SceneManager.LoadScene(nextScene);
    }
}
