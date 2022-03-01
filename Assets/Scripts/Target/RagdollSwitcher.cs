using System.Collections.Generic;
using UnityEngine;

public class RagdollSwitcher : MonoBehaviour
{
    [SerializeField] private List<Rigidbody> _ragdollRigidbodyList;

    private void Awake()
    {
        _ragdollRigidbodyList = new List<Rigidbody>(GetComponentsInChildren<Rigidbody>());
        TurnOffRagdoll();
    }

    public void TurnOnRagdoll()
    {
        foreach (Rigidbody rb in _ragdollRigidbodyList)
        {
            rb.isKinematic = false;
        }
    }
    public void TurnOffRagdoll()
    {
        foreach (Rigidbody rb in _ragdollRigidbodyList)
        {
            rb.isKinematic = true;
        }
    }
}