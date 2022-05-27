using Ink.Runtime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InkManager : MonoBehaviour
{
    #region PARAMETERS

    [SerializeField]
    protected List<TextAsset> inkJsonAssets;

    #endregion

    #region CACHES



    #endregion

    #region STATES

    protected Story story;

    #endregion

    protected void Start()
    {
        StartStory();
    }

    protected void StartStory()
    {
        story = new Story(inkJsonAssets[0].text);
        DisplayNextLine();
    }

    public abstract void DisplayNextLine();
}
