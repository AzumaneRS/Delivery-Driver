using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32(0, 0, 0, 0);

    [SerializeField] float packageDestory = 1f;
    bool hasPackage;

    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Ouch!");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Package" && !hasPackage)
        {
            Debug.Log("Package is picked up");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject, packageDestory);
        }
        else if(other.tag == "Customer" && hasPackage)
        {
            Debug.Log("Package has been delivered");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }
    }
}
