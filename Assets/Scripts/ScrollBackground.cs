using UnityEngine;
using System.Collections;

public class ScrollBackground : MonoBehaviour
{
    public float scrollSpeed;
    public float tileSizeZ;

    Vector3 startPosition;

	// Use this for initialization
	void Start ()
    {
        startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);
        transform.position = startPosition + -Vector3.right * newPosition;
	}
}
