using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Target : MonoBehaviour
{
    public static List<Target> AllTargetList = new List<Target>();
    public Action<Target> OnTargetAmazed;

    private bool _isAmazed = false;

    public bool IsAmazed => _isAmazed;

    private void Awake()
    {
        GetComponent<Collider>().isTrigger = false;
        AllTargetList.Add(this);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.TryGetComponent(out Projectile projectile))
        {
            _isAmazed = true;
            OnTargetAmazed?.Invoke(this);
        }
    }
}