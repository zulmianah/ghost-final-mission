using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class InkPrologueManager : InkManager
{
    #region PARAMETERS

    public TextMeshProUGUI Text;
    public float delay = 0.05f;
    public float fastForwardDelay = 0.001f;
    public GameObject ToActivate;

    #endregion

    #region CACHES



    #endregion

    #region STATES

    private string currentText = "";

    #endregion

    public override void DisplayNextLine()
    {
        if (!story.canContinue)
        {
            gameObject.SetActive(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            return;
        }
        string text = story.Continue();
        text = text?.Trim();
        StartCoroutine(ShowText(text));
    }

    IEnumerator ShowText(string fullText)
    {
        for (int i = 0; i <= fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            currentText += "<color=#00000000>" + fullText.Substring(i) + "</color>";
            Text.text = currentText;
            int rand = UnityEngine.Random.Range(1, 5);
            if (i%2!=0) Audio.instance.Play("thocc"+rand);
            yield return new WaitForSeconds(delay);
        }
        yield return new WaitForSeconds(2f);
        ToActivate.SetActive(true);
        DisplayNextLine();
    }
}
