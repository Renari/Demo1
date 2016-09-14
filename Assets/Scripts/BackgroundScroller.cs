using UnityEngine;
using System.Collections;

public class BackgroundScroller : MonoBehaviour {

    private GameObject background;
    private Transform backgroundTransform;
    private Vector2 savedOffset;
    private Renderer renderer;

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
        float BackgroundHeight = Camera.main.orthographicSize * 3.6f;
        float BackgroundWidth = BackgroundHeight * Screen.width / Screen.height;

        backgroundTransform.localScale = new Vector3(BackgroundHeight, BackgroundWidth, 1);

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
