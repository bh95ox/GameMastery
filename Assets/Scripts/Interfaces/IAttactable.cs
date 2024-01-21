using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttactable
{
    bool Attack();// Can implement Have different type of attack like projectile or other attacks

    string Name();// return what was attacked;

}
