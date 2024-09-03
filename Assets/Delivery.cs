using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] bool hasPackage;
    [SerializeField] float packageDestroyTime;
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log($"Ouch!");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Package" && !hasPackage)
        {
            Debug.Log($"Package Recieved");
            hasPackage = true;
            Destroy(collision.gameObject, packageDestroyTime);
        }
        else if (collision.tag == "Customer" && hasPackage)
        {
            Debug.Log($"Package Delivered"); 
            hasPackage = false;
        }
    }
}
