using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private int _mainGameSceneIndex = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Quando o bot�o de play for pressionado
    /// </summary>
    public void OnPlayButtonPressed()
    {
        SceneManager.LoadScene(_mainGameSceneIndex, LoadSceneMode.Single);
    }

    /// <summary>
    /// Quando o bot�o de settings for pressionado
    /// </summary>
    public void OnSettingsButtonPressed()
    {
        // TODO: Exibir o menu de configura��es
        return;
    }

    /// <summary>
    /// Quando o bot�o de exit for pressionado
    /// </summary>
    public void OnExitButtonPressed()
    {
        Application.Quit();
    }
}
