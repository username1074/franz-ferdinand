using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject canvasElement;
    public Button exitButton;

    // Start is called before the first frame update
    void Start()
    {
        canvasElement.SetActive(true);
        exitButton.onClick.AddListener(() => ExitMainMenu());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ExitMainMenu()
    {
        canvasElement.SetActive(false);
    }
}
