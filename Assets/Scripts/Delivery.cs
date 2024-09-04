using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] private Color32 hasPackageColor = new(1, 1, 1, 1);
    [SerializeField] private Color32 noPackageColor = new(1, 1, 1, 1);

    [SerializeField] bool hasPackage;
    [SerializeField] float packageDestroyTime;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
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
            spriteRenderer.color = hasPackageColor; 
            Destroy(collision.gameObject, packageDestroyTime);
        }
        else if (collision.tag == "Customer" && hasPackage)
        {
            Debug.Log($"Package Delivered"); 
            hasPackage = false;
            spriteRenderer.color = noPackageColor; 
        }
    }
}
