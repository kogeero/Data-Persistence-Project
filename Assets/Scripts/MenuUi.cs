using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUi : MonoBehaviour
{
    public InputField nameField;

    public void StartGame()
    {
        UpdateName();
        SceneManager.LoadScene(1);
    }

    public void UpdateName()
    {
        MainestManager.Instance.currentName = nameField.text.ToString();
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
