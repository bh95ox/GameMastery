using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOn : MonoBehaviour
{
    [SerializeField] private float Duration;

    void Update()
    {
        if(Duration > 0)
        {
            Duration -= Time.deltaTime;
        }
        
        if(Duration < 0)
        {
           Destroy(gameObject);
        }

    }
}
