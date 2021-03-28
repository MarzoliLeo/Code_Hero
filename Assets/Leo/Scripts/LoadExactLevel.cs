using System.Collections;
using System.Collections.Generic;
using Leo.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadExactLevel : MonoBehaviour
{
    private int timeToWait = 5;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadIndexLevel", timeToWait);
    }

    private void LoadIndexLevel()
    {
        SceneManager.LoadScene(GameManager.Instance.DestinationWaypoint.levelIndex);
    }
}
