using UnityEngine;
using System.Collections;

public class EarthRotation : MonoBehaviour
{
    public GameObject sphere;
    public float degreesToRotate;

    Transform thisTransform;

	// Use this for initialization
	void Start ()
    {
        thisTransform = sphere.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	    thisTransform.Rotate(degreesToRotate * Vector3.right * Time.deltaTime, Space.World);
    }
}
