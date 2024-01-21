using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageble
{
    void TakeDamage(float DamageAmount);

    string GetObjectName();//get the object name

}
