using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiltrationSpell : MonoBehaviour
{
    [SerializeField] private bool isInfiltrationActive = false;
    [SerializeField] private RaycastHit hitBottom;
    [SerializeField] private RaycastHit hitUp;
    [SerializeField] private GameObject portalTexture;

    // Update is called once per frame
    void Update()
    {

        if(isInfiltrationActive)
        {
            if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), out hitBottom, Mathf.Infinity))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up) * hitBottom.distance, Color.red);
                portalTexture.transform.position = hitBottom.point + (Vector3.down * 0.1f);
            }else
            {
                portalTexture.transform.position = Vector3.up * 1000;
            }
        }

        // Debug.DrawRay(transform.position + (Vector3.up * 1000), transform.TransformDirection(Vector3.down) * hitUp.distance, Color.green);
        if(Physics.Raycast(transform.position + (Vector3.up * 1000), transform.TransformDirection(Vector3.down), out hitUp, Mathf.Infinity))
        {
          //  Debug.Log("dit hitUp " + hitUp.transform.gameObject.name);
        }



        //active the spell when the player press the left mouse button and the spell is not launched
        if(Input.GetMouseButton(1) && !isInfiltrationActive)
        {
            isInfiltrationActive = true;
        }

        //launch the spell infiltration
        if(Input.GetMouseButton(0) && isInfiltrationActive)
        {
            iTween.MoveTo(this.gameObject, hitUp.transform.position, 3f);
            portalTexture.transform.position = new Vector3(portalTexture.transform.position.x, 1000, portalTexture.transform.position.z);
            isInfiltrationActive = false;
        }
    }
}
