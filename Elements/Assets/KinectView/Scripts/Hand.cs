using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public Transform mHandMesh;

    // Update is called once per frame
    private void Update()
    {
        mHandMesh.position = Vector3.Lerp(mHandMesh.position, transform.position, Time.deltaTime * 15.0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Fire" && gameObject.tag != "Air"
             && gameObject.tag != "Water" && gameObject.tag != "Earth")
        {
            Orb orb = collision.gameObject.GetComponent<Orb>();
            StartCoroutine(orb.Pop());
            return;
        }
        else
        {
            Debug.Log("Health Lost");
        }

        if (collision.gameObject.tag == "Water" && gameObject.tag != "Air"
             && gameObject.tag != "Fire" && gameObject.tag != "Earth")
        {
            Orb orb = collision.gameObject.GetComponent<Orb>();
            StartCoroutine(orb.Pop());
            return;
        }
        else
        {
            Debug.Log("Health Lost");
        }

        if (collision.gameObject.tag == "Earth" && gameObject.tag != "Air"
             && gameObject.tag != "Fire" && gameObject.tag != "Water")
        {
            Orb orb = collision.gameObject.GetComponent<Orb>();
            StartCoroutine(orb.Pop());
            return;
        }
        else
        {
            Debug.Log("Health Lost");
        }

        if (collision.gameObject.tag == "Air" && gameObject.tag != "Water"
             && gameObject.tag != "Fire" && gameObject.tag != "Earth")
        {
            Orb orb = collision.gameObject.GetComponent<Orb>();
            StartCoroutine(orb.Pop());
            return;
        }
        else
        {
            Debug.Log("Health Lost");
        }
    }
}
