using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Camera firstPersonCamera;
    [SerializeField] private ParticleSystem muzzleFlash;
    [SerializeField] private GameObject hitParticlePrefab;

    [Header("Settings")]
    [SerializeField] private float range = 100f;
    [SerializeField] private int damage = 25;
    [SerializeField] private LayerMask hitLayers; // слои, по которым можно стрелять

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        // Вспышка выстрела
        if (muzzleFlash != null)
            muzzleFlash.Play();

        // Raycast
        if (Physics.Raycast(firstPersonCamera.transform.position, firstPersonCamera.transform.forward, out RaycastHit hit, range, hitLayers))
        {
            // Эффект попадания
            if (hitParticlePrefab != null)
            {
                Vector3 hitPoint = hit.point + hit.normal * 0.02f;
                Instantiate(hitParticlePrefab, hitPoint, Quaternion.LookRotation(hit.normal));
            }

            // Проверка на врага
            EnemyHealth enemy = hit.transform.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
    }
}
