using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
public class BulletsProjectile : MonoBehaviour
{
    [SerializeField] private float DamageAmount;
    [SerializeField] private GameObject MuzzlePrefab;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision != null)
        {
            if(collision.collider.TryGetComponent<IDamageble>(out var damageble))
            {
                damageble.TakeDamage(DamageAmount);
                Destroy(gameObject);
            }
            else
            {
                Instantiate(MuzzlePrefab, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
    }
}
