using UnityEngine;
using System.Collections;

public class BackgroundScroller : MonoBehaviour {

    private GameObject background;
    private Transform backgroundTransform;
    private Vector2 savedOffset;
    private new Renderer renderer;

    public float scrollSpeed;

    // Use this for initialization
    void Start () {
        background = GameObject.FindGameObjectWithTag("Background");
        backgroundTransform = background.GetComponent<Transform>();
        renderer = GetComponent<Renderer>(); 
        savedOffset = renderer.sharedMaterial.GetTextureOffset("_MainTex");
    }
	
	// Update is called once per frame
	void Update () {
        // Scale the background to fit the camera
        float width = Camera.main.orthographicSize * 2.0f * Screen.width / Screen.height;
        float height = width * 2.25f;
        backgroundTransform.localScale = new Vector3(width, height, 0.1f);

        // Scroll the background
        float y = Mathf.Repeat(Time.time * scrollSpeed, 1);
        Vector2 offset = new Vector2(savedOffset.x, y);
        renderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }

    void OnDisable()
    {
        renderer.sharedMaterial.SetTextureOffset("_MainTex", savedOffset);
    }
}
