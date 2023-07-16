using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHiyBoxToWeapon : MonoBehaviour
{
    private AggressiveWeapon weapon;

    private void Awake()
    {
        weapon.GetComponentInParent<AggressiveWeapon>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Enter detected");
        weapon.AddToDetected(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Exit detected");
        weapon.RemoveFromDetected(collision);
    }
}
