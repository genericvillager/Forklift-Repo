using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerSettingsManagerExample : MonoBehaviour
{
    [SerializeField] private string playerName;
    [SerializeField] private Color playerColor;
    private int targetScene;
    
    private static PlayerSettingsManagerExample instance;
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
        
        DontDestroyOnLoad(this);
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneChange;
    }

    private void OnSceneChange(Scene scene, LoadSceneMode sceneMode)
    {
        player = FindObjectOfType<PlayerMovement>(true);
        ApplyPlayerSettings();
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
        ApplyPlayerSettings();
    }

    public void SetPlayerColour(Slider slider)
    {
        playerColor = Color.HSVToRGB(slider.value, 255, 255);
        ApplyPlayerSettings();
    }

    public void SetTargetLevel(int targetLevel)
    {
        targetScene = targetLevel;
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(targetScene);
    }
}
