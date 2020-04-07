using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMockUp : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "PR_Orb")
        {
            Destroy(collision.gameObject);
        }
    }
}
