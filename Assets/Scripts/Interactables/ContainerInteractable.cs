using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerInteractable : Interactable
{
    public override void Interact(GameObject pickable)
    {
        //transform
        //pickable.transform

        var transferController = StateManager._inst.GetState<TransferController>();

        transferController.pickable = pickable;
        transferController.interactable = transform.gameObject;

        StateManager._inst.ChangeState<TransferController>();
    }
}
