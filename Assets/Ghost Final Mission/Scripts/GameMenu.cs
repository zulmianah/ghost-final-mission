using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenu : MonoBehaviour
{
    public GameObject GM, GM1;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void SetGameMenu()
    {
        GM.SetActive(!GM.activeSelf);
        GM1.SetActive(!GM1.activeSelf);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
