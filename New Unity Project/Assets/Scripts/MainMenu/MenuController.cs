using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [Header("Levels to load")]
    [SerializeField] private GameObject noSavedGameDialogue = null;
    public string newGameLoad;
    private string levelToLoad;



    public void NewGameDialogueYes()
    {
        SceneManager.LoadScene(newGameLoad);
    }

    public void LoadGameDialogueYes()
    {
        if (PlayerPrefs.HasKey("SavedGame"))
        {
            levelToLoad = PlayerPrefs.GetString("SavedGame");
            SceneManager.LoadScene(levelToLoad);
        }

        else
        {
            noSavedGameDialogue.SetActive(true);
        }
    }


    public void QuitGameButton()
    {
        Application.Quit();
    }
}
