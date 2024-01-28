using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string nameScene;

    public void NextScene()
    {
        StartCoroutine(WaitTime());
        SceneManager.LoadScene(nameScene);
    }

    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(2f);
    }

    
}
