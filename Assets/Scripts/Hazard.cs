using UnityEngine;
using UnityEngine.SceneManagement;

public class Hazard : MonoBehaviour {

    public float fuseTime;
    private float detonationTime;
    private const float TIME_ALIVE = 2f;
    private bool detonated = false;
    private ParticleSystem particle;

	// Use this for initialization
	void Start () {
        detonationTime = fuseTime + Time.time;
        particle = GetComponent<ParticleSystem>();
        particle.Stop();
    }
	
	// Update is called once per frame
	void Update () {
        if (Time.time > detonationTime && !detonated)
        {
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<CircleCollider2D>().enabled = true;
            particle.Play();
            detonated = true;
            Destroy(gameObject, TIME_ALIVE);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Plane")
        {
            Destroy(GameObject.FindGameObjectWithTag("HazardController"));
            Destroy(GameObject.FindGameObjectWithTag("Plane"));
            ScoreController scoreController = (ScoreController) GameObject.FindGameObjectWithTag("ScoreController").GetComponent(typeof(ScoreController));
            scoreController.SaveScore();
            if (scoreController.CheckHighScore())
            {
                GameObject.FindGameObjectWithTag("HighScoreCanvas").GetComponent<Canvas>().enabled = true;
            }
            else
            {
                SceneManager.LoadScene("Score");
            }
        }
    }
}
