using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayGame()
    {
        // Loads the next scene in the queue
        UnityEngine.SceneManagement.SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        // Quits the game
        Debug.Log("Quit");
        Application.Quit();
    }

    public void backToMenu()
    {
        // Loads the main menu
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
