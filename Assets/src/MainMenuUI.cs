using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenuUI : MonoBehaviour
{
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        var start_btn = root.Q<Button>("btn-start-game");
        start_btn.clicked += LoadScenario;
    }

    void LoadScenario()
    {
        SceneManager.LoadScene("GameScene");
    }
}
