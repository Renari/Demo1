using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlaneController : MonoBehaviour {

    private const float MOVEMENT_SPEED = 0.05f;
    private Transform planeTransform;

	// Use this for initialization
	void Start () {
        planeTransform = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            planeTransform.position = new Vector3(planeTransform.position.x - MOVEMENT_SPEED, planeTransform.position.y, planeTransform.position.z);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            planeTransform.position = new Vector3(planeTransform.position.x + MOVEMENT_SPEED, planeTransform.position.y, planeTransform.position.z);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            planeTransform.position = new Vector3(planeTransform.position.x, planeTransform.position.y + MOVEMENT_SPEED, planeTransform.position.z);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            planeTransform.position = new Vector3(planeTransform.position.x, planeTransform.position.y - MOVEMENT_SPEED, planeTransform.position.z);
        }
    }
}
