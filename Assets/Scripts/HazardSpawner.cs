using UnityEngine;
using UnityEditor;

public class HazardSpawner : MonoBehaviour {

    // Seconds until first spawn
    public float initialSpawn;
    private float spawnRate = 0;
    private float lastSpawn = 0;
    private GameObject hazard;

	// Use this for initialization
	void Start () {
        hazard = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Hazard.prefab");
	}
	
	// Update is called once per frame
	void Update () {
        spawnRate = (float)(initialSpawn / Mathf.Sqrt(Time.time));
        if (Time.time > lastSpawn + spawnRate)
        {
            lastSpawn = Time.time;
            GameObject explosion = Instantiate(hazard);
            Vector3 location = new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), 1);
            explosion.transform.position = Camera.main.ScreenToWorldPoint(location);
        }
	}
}
