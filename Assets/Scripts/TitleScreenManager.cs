using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScreenManager : MonoBehaviour {

    private GameObject StartButton;
    private GameObject ScoreButton;
    private GameObject QuitButton;

    private RectTransform TitleTextTransform;
    private RectTransform StartButtonTransform;
    private RectTransform ScoreButtonTransform;
    private RectTransform QuitButtonTransform;

    private int selected;

    // Use this for initialization
    void Start ()
    {
        TitleTextTransform = GameObject.FindGameObjectWithTag("TitleText").GetComponent<RectTransform>();

        StartButton = GameObject.FindGameObjectWithTag("StartButton");
        ScoreButton = GameObject.FindGameObjectWithTag("ScoreButton");
        QuitButton = GameObject.FindGameObjectWithTag("QuitButton");

        StartButtonTransform = StartButton.GetComponent<RectTransform>();
        ScoreButtonTransform = ScoreButton.GetComponent<RectTransform>();
        QuitButtonTransform = QuitButton.GetComponent<RectTransform>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (selected == 3)
            {
                selected = 1;
                StartButton.GetComponent<Button>().Select();
            }
            else
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
                QuitButton.GetComponent<Button>().Select();
            }
            else
            {
                selected--;
            }
            SelectionMode();
        }
        float HalfCameraWidth = (Camera.main.pixelWidth / 2);

        // Position the title text
        float TitleXLocation = Camera.main.rect.x + HalfCameraWidth;
        float TitleYLocation = Camera.main.pixelHeight * .75f + Camera.main.pixelRect.y;

        TitleTextTransform.position = new Vector3(TitleXLocation, TitleYLocation, 0);

        // Position the quit button
        float QuitXLocation = Camera.main.rect.x + Camera.main.pixelWidth - QuitButtonTransform.rect.width / 2;
        float QuitYLocation = Camera.main.rect.y + QuitButtonTransform.rect.height / 2;

        QuitButtonTransform.position = new Vector3(QuitXLocation, QuitYLocation, 0);

        // Position the start button
        float ScoreXLocation = Camera.main.rect.x + Camera.main.pixelWidth - StartButtonTransform.rect.width / 2;
        float ScoreYLocation = Camera.main.rect.y + QuitButtonTransform.position.y + ScoreButtonTransform.rect.height;

        ScoreButtonTransform.position = new Vector3(ScoreXLocation, ScoreYLocation);

        // Position the start button
        float StartXLocation = Camera.main.rect.x + Camera.main.pixelWidth - StartButtonTransform.rect.width / 2;
        float StartYLocation = Camera.main.rect.y + ScoreButtonTransform.position.y + StartButtonTransform.rect.height;

        StartButtonTransform.position = new Vector3(StartXLocation, StartYLocation, 0);
    }

    private void SelectionMode()
    {
        if (selected == 0)
        {
            StartButton.GetComponent<Button>().Select();
            selected = 1;
        }
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
