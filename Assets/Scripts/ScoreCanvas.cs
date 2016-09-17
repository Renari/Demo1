using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class ScoreCanvas : MonoBehaviour {

    public static ScoreController scoreController;

	// Use this for initialization
	void Start ()
    {
        DrawScores();
    }

    public static void DrawScores()
    {
        foreach (ScoreController.NameKey item in Enum.GetValues(typeof(ScoreController.NameKey)))
        {
            String key = Enum.GetName(typeof(ScoreController.NameKey), item);
            Text text = GameObject.FindGameObjectWithTag(key).GetComponent<Text>();
            text.text = PlayerPrefs.GetString(key);
        }
        foreach (ScoreController.ScoreKey item in Enum.GetValues(typeof(ScoreController.ScoreKey)))
        {
            String key = Enum.GetName(typeof(ScoreController.ScoreKey), item);
            Text text = GameObject.FindGameObjectWithTag(key).GetComponent<Text>();
            int score = PlayerPrefs.GetInt(key);
            if (score != 0)
            {
                text.text = score.ToString();
            }
            else
            {
                text.text = "";
            }
        }
    }
}
