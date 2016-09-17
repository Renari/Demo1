using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreController : MonoBehaviour {

    public enum ScoreKey
    {
        AMScore1,
        AMScore2,
        AMScore3,
        AMScore4,
        AMScore5,
        AMScore6,
        AMScore7,
        AMScore8,
        AMScore9,
        AMScore10
    }

    public enum NameKey
    {
        AMName1,
        AMName2,
        AMName3,
        AMName4,
        AMName5,
        AMName6,
        AMName7,
        AMName8,
        AMName9,
        AMName10
    }

    private float startTime;
    private int score = 0;

	// Use this for initialization
	void Start () {
        startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SaveScore()
    {
        score = GetCurrentScore();
    }

    public int GetCurrentScore()
    {
        if (score == 0)
        {
            return (int)(Time.time - startTime);
        }
        return score;
    }

    public void SubmitScore(String name)
    {
        if (CheckHighScore())
        {
            int previousScore = 0;
            string previousName = "";
            bool saved = false;
            foreach (ScoreKey item in Enum.GetValues(typeof(ScoreKey)))
            {
                int currentScore = PlayerPrefs.GetInt(Enum.GetName(typeof(ScoreKey), item));
                if (previousName != "" && previousScore != 0)
                {
                    int tempScore = PlayerPrefs.GetInt(Enum.GetName(typeof(ScoreKey), item));
                    string tempName = PlayerPrefs.GetString(Enum.GetName(typeof(NameKey), item));
                    PlayerPrefs.SetInt(Enum.GetName(typeof(ScoreKey), item), previousScore);
                    PlayerPrefs.SetString(Enum.GetName(typeof(NameKey), item), previousName);
                    previousScore = tempScore;
                    previousName = tempName;
                }
                else if(score > currentScore)
                {
                    if (saved)
                    {
                        break;
                    }
                    previousScore = PlayerPrefs.GetInt(Enum.GetName(typeof(ScoreKey), item));
                    previousName = PlayerPrefs.GetString(Enum.GetName(typeof(NameKey), item));
                    PlayerPrefs.SetInt(Enum.GetName(typeof(ScoreKey), item), score);
                    PlayerPrefs.SetString(Enum.GetName(typeof(NameKey), item), name);
                    saved = true;
                }
            }
        }
        PlayerPrefs.Save();
        SceneManager.LoadScene("Score");
    }

    public bool CheckHighScore()
    {
        foreach (ScoreKey item in Enum.GetValues(typeof(ScoreKey)))
        {
            int currentScore = PlayerPrefs.GetInt(Enum.GetName(typeof(ScoreKey), item));
            if (score > currentScore)
            {
                return true;
            }
        }
        return false;
    }

    public void ResetScores()
    {
        PlayerPrefs.DeleteAll();
    }
}
