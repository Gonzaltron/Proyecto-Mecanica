using UnityEngine;
using UnityEngine.InputSystem;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] Canvas mainMenu;
    [SerializeField] Canvas options;
    [SerializeField] Canvas game;
    [SerializeField] Canvas pause;
    Canvas prev;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainMenu.enabled = true;
        options.enabled = false;
        game.enabled = false;
        Cursor.visible = true;
        pause.enabled = false;
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void Pause()
    {
        game.enabled = false;
        pause.enabled = true;
        Time.timeScale = 0;
        Cursor.visible = true;
    }

    public void Unpause()
    {
        game.enabled = true;
        pause.enabled = false;
        Time.timeScale = 1;
        Cursor.visible = false;
    }

    public void MainToOptions()
    {
        mainMenu.enabled = false;
        options.enabled = true;
        prev = mainMenu;
    }

    public void ExitOptions()
    {
        options.enabled = false;
        prev.enabled = true;
    }

    public void PauseToOptions()
    {
        pause.enabled = false;
        options.enabled = true;
        prev = pause;
    }

    public void Game()
    {
        mainMenu.enabled = false;
        game.enabled = true;
        Time.timeScale = 1;
        Cursor.visible = false;
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        mainMenu.enabled = true;
        pause.enabled = false;
    }
}
