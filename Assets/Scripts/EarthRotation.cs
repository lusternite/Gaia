using UnityEngine;
using System.Collections;

public class EarthRotation : MonoBehaviour
{
    // models
    public GameObject[] model;

    public float degreesToRotate;
    GameObject currentModel;
    int modelIndex = 0;

	// Use this for initialization
	void Start ()
    {
        currentModel = model[modelIndex];
	}
	
	// Update is called once per frame
	void Update ()
    {
        currentModel.GetComponent<Transform>().Rotate(degreesToRotate * Vector3.up * Time.deltaTime, Space.World);
    }

    public void ChangeModel()
    {
        modelIndex++;
        currentModel = model[modelIndex];
    }
}
