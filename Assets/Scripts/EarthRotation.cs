using UnityEngine;
using System.Collections;

public class EarthRotation : MonoBehaviour
{
    // models
    public GameObject model;
    public float degreesToRotate;

    float AsiaRotation = 355.0f;
    float EuropeRotation = 310.0f;
    float OceaniaRotation = 35.0f;
    float AfricaRotation = 297.0f;
    float NorthAmericaRotation = 200.0f;
    float SouthAmericaRotation = 225.0f;

    bool snapped = false;
    float snapRotationSpeed = 400.0f;
    float targetSnapRotation = 0.0f;

	// Use this for initialization
	void Start ()
    {
         
	}

    // Update is called once per frame
    void Update ()
    {
        if (!snapped)
        {
            model.GetComponent<Transform>().Rotate(degreesToRotate * Vector3.up * Time.deltaTime, Space.World);
        }
        else
        {
            float currentRotation = model.GetComponent<Transform>().rotation.eulerAngles.y;
            if (currentRotation < targetSnapRotation - 4.0f || currentRotation > targetSnapRotation + 4.0f)
            {
                model.GetComponent<Transform>().Rotate(snapRotationSpeed * Vector3.up * Time.deltaTime, Space.World);
            }
        }
    }

    public void SnapToContinent(string continent)
    {
        Debug.Log(continent);
        switch(continent)
        {
            case "ASIA":
                {
                    targetSnapRotation = AsiaRotation;
                }
                break;
            case "EUROPE":
                {
                    targetSnapRotation = EuropeRotation;
                }
                break;
            case "AFRICA":
                {
                    targetSnapRotation = AfricaRotation;
                }
                break;
            case "AUSTRALIA":
                {
                    targetSnapRotation = OceaniaRotation;
                }
                break;
            case "NORTHAMERICA":
                {
                    targetSnapRotation = NorthAmericaRotation;
                }
                break;
            case "SOUTHAMERICA":
                {
                    targetSnapRotation = SouthAmericaRotation;
                }
                break;
            default: break;
        }
        snapped = true;
    }

    public void SnapBackToRotation()
    {
        snapped = false;
    }
}
