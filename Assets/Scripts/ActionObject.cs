using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Completed
{
    public abstract class ActionObject : MonoBehaviour
    {
        // To be overwritten
        public abstract void Activate();
        // To be overwritten
        public abstract void Deactivate();
    }
}