using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class TitleScreenManager : MonoBehaviour {

    private GameObject startButton;
    private GameObject scoreButton;
    private GameObject quitButton;
    private EventSystem titleEventSystem;

    private RectTransform titleTextTransform;
    private RectTransform startButtonTransform;
    private RectTransform scoreButtonTransform;
    private RectTransform quitButtonTransform;

    private int selected;

    // Use this for initialization
    void Start ()
    {
        titleTextTransform = GameObject.FindGameObjectWithTag("TitleText").GetComponent<RectTransform>();

        startButton = GameObject.FindGameObjectWithTag("StartButton");
        scoreButton = GameObject.FindGameObjectWithTag("ScoreButton");
        quitButton = GameObject.FindGameObjectWithTag("QuitButton");

        startButtonTransform = startButton.GetComponent<RectTransform>();
        scoreButtonTransform = scoreButton.GetComponent<RectTransform>();
        quitButtonTransform = quitButton.GetComponent<RectTransform>();

        titleEventSystem = GameObject.FindGameObjectWithTag("EventSystem").GetComponent<EventSystem>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        CheckKeyInputs();

        float HalfCameraWidth = Screen.width / 2;

        // Position the title text
        float TitleXLocation = Camera.main.rect.x + HalfCameraWidth;
        float TitleYLocation = Camera.main.rect.y + Screen.height * .75f;

        titleTextTransform.position = new Vector3(TitleXLocation, TitleYLocation, 0);

        // Position the quit button
        float QuitXLocation = Camera.main.rect.x + Screen.width - quitButtonTransform.rect.width / 2;
        float QuitYLocation = Camera.main.rect.y + quitButtonTransform.rect.height / 2;

        quitButtonTransform.position = new Vector3(QuitXLocation, QuitYLocation, 0);

        // Position the start button
        float ScoreXLocation = Camera.main.rect.x + Screen.width - startButtonTransform.rect.width / 2;
        float ScoreYLocation = Camera.main.rect.y + quitButtonTransform.position.y + scoreButtonTransform.rect.height;

        scoreButtonTransform.position = new Vector3(ScoreXLocation, ScoreYLocation);

        // Position the start button
        float StartXLocation = Camera.main.rect.x + Screen.width - startButtonTransform.rect.width / 2;
        float StartYLocation = Camera.main.rect.y + scoreButtonTransform.position.y + startButtonTransform.rect.height;

        startButtonTransform.position = new Vector3(StartXLocation, StartYLocation, 0);
    }

    // Checks user inputs and reacts based on their function.
    private void CheckKeyInputs()
    {
        // Allows for the user to use the arrow keys to select menu functions.
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            if (selected == 3)
            {
                selected = 1;
                startButton.GetComponent<Button>().Select();
            }
            else if (!SelectionMode())
            {
                selected++;
            }
            SelectionMode();
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            if (selected == 1)
            {
                selected = 3;
                quitButton.GetComponent<Button>().Select();
            }
            else if (!SelectionMode())
            {
                selected--;
            }
            SelectionMode();
        }
    }

    // Resets selection to it's starting state.
    public void ResetSelectionMode()
    {
        selected = 0;
        titleEventSystem.SetSelectedGameObject(null);
    }

    private bool SelectionMode()
    {
        if (selected == 0)
        {
            startButton.GetComponent<Button>().Select();
            selected = 1;
            return true;
        }
        return false;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void ShowScore()
    {
        SceneManager.LoadScene("Score");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
