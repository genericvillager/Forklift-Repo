using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerSettingsManager : MonoBehaviour
{
    [SerializeField] private int sceneToLoad;
    [SerializeField] private string playerName;
    [SerializeField] private Color playerColor;
    
    private static PlayerSettingsManager instance;
    private PlayerMovement player;
    private void Awake()
    {
        SceneManager.sceneLoaded += OnSceneChange;
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    private void OnSceneChange(Scene scene, LoadSceneMode sceneMode)
    {
        player = FindObjectOfType<PlayerMovement>(true);
        ApplyPlayerSettings();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ApplyPlayerSettings();
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            StartGame();
        }
    }

    public void ApplyPlayerSettings()
    {
        if(player == null) return;
        player.GetComponentInChildren<MeshRenderer>().material.color = playerColor;

        TMP_Text nameText = player.GetComponentInChildren<TMP_Text>(true);
        if (nameText != null)
        {
            nameText.text = playerName;
            nameText.gameObject.SetActive(true);
        }
    }

    public void SetPlayerName(TMP_InputField inputField)
    {
        playerName = inputField.text;
    }

    public void SetPlayerColour(Slider colourSlider)
    {
        playerColor = Color.HSVToRGB(colourSlider.value, 255,255);
    }

    public void SetLevelToLoad(TMP_Dropdown dropdown)
    {
        sceneToLoad = dropdown.value;
    }
    
    public void StartGame()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
