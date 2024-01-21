using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interfaces
{
    public interface IPickable
    {
        void PickUp();

        string GetDescription();
    }
}

