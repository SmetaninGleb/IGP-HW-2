using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Canon))]
public class CanonShooting : MonoBehaviour
{
    private const float _targetUpOffset = 1f;
    [SerializeField] private float _FOVAngle = 60f;
    [SerializeField] private float _reload = 1f;
    private Vector3 _startForwardVector;
    private float _previousShootTime = 0f;
    private Canon _canon;

    private void Start()
    {
        _canon = GetComponent<Canon>();
        _startForwardVector = transform.forward;
    }

    private void FixedUpdate()
    {
        Target targetToShoot = GetClosestTargetInFOV();
        if (!targetToShoot) return;
        RotateToTarget(targetToShoot);
        StartShooting();
    }

    private void StartShooting()
    {
        if (Time.timeSinceLevelLoad - _previousShootTime > _reload)
        {
            _previousShootTime = Time.timeSinceLevelLoad;
            _canon.Shoot();
        }
    }

    private void RotateToTarget(Target target)
    {
        transform.rotation = Quaternion.LookRotation((target.transform.position + Vector3.up * _targetUpOffset) - transform.position);
    }

    private Target GetClosestTargetInFOV()
    {
        Target closestInFOV = null;
        float closestDistance = 0f;
        foreach (Target target in Target.AllTargetList)
        {
            if (target.IsAmazed || !IsTargetInFOV(target)) continue;
            if (!closestInFOV 
                || closestDistance > Vector3.Distance(transform.position, target.transform.position)) 
            {
                closestInFOV = target;
                closestDistance = Vector3.Distance(transform.position, target.transform.position);
            }
        }
        return closestInFOV;
    }

    private bool IsTargetInFOV(Target target)
    {
        Vector3 toTarget = target.transform.position - transform.position;
        return Mathf.Abs(Vector3.SignedAngle(_startForwardVector, toTarget, Vector3.up)) < _FOVAngle;
    }
}