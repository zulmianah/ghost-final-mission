using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneSwitcher : MonoBehaviour
{
    public void playGame()
    {
        StartCoroutine(NextScene());
    }

    public IEnumerator NextScene()
    {
        yield return new WaitForSeconds(0.5f);
        if (SceneManager.sceneCountInBuildSettings - 1 == SceneManager.GetActiveScene().buildIndex)
            SceneManager.LoadScene(0);
        else SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void GoGame(int i)
    {
        StartCoroutine(GoScene(i));
    }

    private IEnumerator GoScene(int i)
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(i);
    }

    public void QuitGame()
    {
        StartCoroutine(QuitScene());
    }

    private IEnumerator QuitScene()
    {
        yield return new WaitForSeconds(0.5f);
        Application.Quit();
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
