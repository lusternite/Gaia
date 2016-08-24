using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CardBehaviour : MonoBehaviour {

    Animator anim;
    float HoverDelay;
    bool IsHovered;
    bool IsSelected = false;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                //StartCoroutine(ScaleMe(hit.transform));
                Debug.Log("You selected the " + hit.transform.name); // ensure you picked right object
            }
        }

        if (HoverDelay > 0.0f)
        {
            HoverDelay -= Time.deltaTime;
            if (HoverDelay <= 0.0f)
            {
                HoverDelay = 0.0f;
            }
        }
	}

    public void OnMouseHover()
    {
        if (HoverDelay == 0.0f)
        {
            anim.SetTrigger("Hovering");
            IsHovered = true;
        }
    }

    public void OnMouseExit()
    {
        if (IsHovered)
        {
            anim.SetTrigger("OffHovering");
            HoverDelay = 0.2f;
            IsHovered = false;
        }
    }

    public void OnMouseClick()
    {
        IsSelected = !IsSelected;
        if (IsSelected)
        {
            GetComponent<Image>().color = new Color(0.8f, 1.0f, 0.0f, 1.0f);
        }
        else
        {
            GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }
    }

}
