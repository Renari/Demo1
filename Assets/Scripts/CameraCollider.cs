using UnityEngine;
using System.Collections;

public class CameraCollider : MonoBehaviour {

    private GameObject topColliderObject;
    private GameObject leftColliderObject;
    private GameObject rightColliderObject;
    private GameObject bottomColliderObject;

    private EdgeCollider2D topCollider;
    private EdgeCollider2D leftCollider;
    private EdgeCollider2D rightCollider;
    private EdgeCollider2D bottomCollider;

    // Use this for initialization
    void Start () {
        topColliderObject = new GameObject();
        leftColliderObject = new GameObject();
        rightColliderObject = new GameObject();
        bottomColliderObject = new GameObject();

        topCollider = topColliderObject.AddComponent<EdgeCollider2D>();
        leftCollider = leftColliderObject.AddComponent<EdgeCollider2D>();
        rightCollider = rightColliderObject.AddComponent<EdgeCollider2D>();
        bottomCollider = bottomColliderObject.AddComponent<EdgeCollider2D>();

        topColliderObject.name = "TopCollider";
        leftColliderObject.name = "LeftCollider";
        rightColliderObject.name = "RightCollider";
        bottomColliderObject.name = "BottomCollider";

        topColliderObject.transform.SetParent(transform);
        leftColliderObject.transform.SetParent(transform);
        rightColliderObject.transform.SetParent(transform);
        bottomColliderObject.transform.SetParent(transform);
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 topLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height));
        Vector3 topRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
        Vector3 bottomLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0));
        Vector3 bottomRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0));

        topColliderObject.transform.position = topLeft;
        leftColliderObject.transform.position = bottomLeft;
        rightColliderObject.transform.position = bottomRight;
        bottomColliderObject.transform.position = bottomLeft;

        topCollider.points = new Vector2[]
        {
            new Vector2(0, 0),
            new Vector2(topRight.x - topLeft.x, 0)
        };
        leftCollider.points = new Vector2[]
        {
            new Vector2(0, 0),
            new Vector2(0, topLeft.y - bottomLeft.y)
        };
        rightCollider.points = new Vector2[]
        {
            new Vector2(0, 0),
            new Vector2(0, topRight.y - bottomRight.y)
        };
        bottomCollider.points = new Vector2[]
        {
            new Vector2(0, 0),
            new Vector2(bottomRight.x - bottomLeft.x, 0)
        };
    }
}
