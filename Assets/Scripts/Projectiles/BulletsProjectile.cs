using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider) , typeof(Rigidbody))]
public class BulletsProjectile : MonoBehaviour
{
    public float DamageAmount;

    [SerializeField] private GameObject MuzzlePrefab;
    [SerializeField] private float MaxRange;

    private readonly float MinRange = 0;

    //private float CalculateVelocity()
    //{
    //    float MidRange = (MaxRange - MinRange) / 2;
    //    Rigidbody rb =  gameObject.AddComponent<Rigidbody>();

    //    //if(rb.velocity.magnitude <= MinRange)
    //    //{
    //    //    return DamageAmount;
    //    //}
    //    //else if(rb.velocity.magnitude >= MidRange)
    //    //{
    //    //    float calcDamage = (60 / DamageAmount) * 100;
    //    //    return calcDamage;
    //    //}
    //    //else if(rb.velocity.magnitude >= MaxRange)
    //    //{
    //    //    float calcDamage = (30 / DamageAmount) * 100;
    //    //    return calcDamage;
    //    //}
    //    return 10;
    //}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision != null)
        {
            IDamageble damageble;

            if(collision.collider.TryGetComponent<IDamageble>(out damageble))
            {
                Instantiate(MuzzlePrefab, transform.position, transform.rotation);
                damageble.TakeDamage(DamageAmount);
                Debug.Log("Object Hit");
                Destroy(gameObject);
                
            }
            else
            {
                Debug.Log(collision.collider.gameObject);
                Debug.Log("NoObject Found");
                Destroy(gameObject);

            }
        }
    }
}
