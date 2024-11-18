using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public abstract void Interact(GameObject pickable);
    public virtual bool CanInteract(GameObject pickable)
    {
        return false;
    }
}
