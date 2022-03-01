using System.Collections;
using UnityEngine;

public class Canon : MonoBehaviour
{
    [SerializeField] private Projectile _projectilePrefab;
    [SerializeField] private Transform _projectileSpawnPoint;

    public void Shoot()
    {
        Projectile projectile = Instantiate(
            _projectilePrefab, 
            _projectileSpawnPoint.position, 
            _projectileSpawnPoint.rotation);
        Vector3 velocityVector = projectile.transform.forward * projectile.StartSpeed;
        projectile.Rigidbody.AddForce(velocityVector, ForceMode.VelocityChange);
    }
}