using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class InkNarrationManager : InkManager
{
    #region PARAMETERS

    public TextMeshProUGUI NarrationText;

    #endregion

    #region CACHES



    #endregion

    #region STATES



    #endregion

    public override void DisplayNextLine()
    {
        if (!story.canContinue)
        {
            gameObject.SetActive(false);
            return;
        }
        string text = story.Continue();
        text = text?.Trim();
        NarrationText.text = text;
    }

    public void Skip()
    {
        gameObject.SetActive(false);
    }
}
