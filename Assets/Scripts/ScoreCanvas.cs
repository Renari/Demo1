using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class ScoreCanvas : MonoBehaviour {

    public ScoreController scoreController;

	// Use this for initialization
	void Start ()
    {
        DrawScores();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void DrawScores()
    {
        foreach (ScoreController.NameKey item in Enum.GetValues(typeof(ScoreController.NameKey)))
        {
            Text text = (Text)GameObject.FindGameObjectWithTag(Enum.GetName(typeof(ScoreController.NameKey), item)).GetComponent(typeof(Text));
            text.text = PlayerPrefs.GetString(Enum.GetName(typeof(ScoreController.NameKey), item));
        }
        foreach (ScoreController.ScoreKey item in Enum.GetValues(typeof(ScoreController.ScoreKey)))
        {
            Text text = (Text)GameObject.FindGameObjectWithTag(Enum.GetName(typeof(ScoreController.ScoreKey), item)).GetComponent(typeof(Text));
            int score = PlayerPrefs.GetInt(Enum.GetName(typeof(ScoreController.ScoreKey), item));
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
