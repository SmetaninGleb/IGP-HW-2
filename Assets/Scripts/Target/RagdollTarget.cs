using System.Collections;
using UnityEngine;

[RequireComponent(typeof(RagdollSwitcher))]
public class RagdollTarget : Target
{
    private RagdollSwitcher _switcher;

    private void Start()
    {
        _switcher = GetComponent<RagdollSwitcher>();
        OnTargetAmazed += TargetAmazed;
    }

    private void TargetAmazed(Target target)
    {
        _switcher.TurnOnRagdoll();
    }
}