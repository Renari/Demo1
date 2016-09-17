using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreDrawer : MonoBehaviour {

    Text text;
    ScoreController scoreController;

	// Use this for initialization
	void Start ()
    {
        text = GameObject.FindGameObjectWithTag("ScoreDisplay").GetComponent<Text>();
        scoreController = GameObject.FindGameObjectWithTag("ScoreController").GetComponent<ScoreController>();
    }
	
	// Update is called once per frame
	void Update () {
        text.text = scoreController.GetCurrentScore().ToString();
	}
}
