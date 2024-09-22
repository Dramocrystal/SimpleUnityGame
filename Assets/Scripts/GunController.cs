using UnityEngine;

public class GunController : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    private GameObject activeBullet;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && activeBullet == null)
        {
            // Instantiate the bullet and pass the initial velocity
            activeBullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            BulletScript bulletScript = activeBullet.GetComponent<BulletScript>();
            bulletScript.SetVelocity(bulletSpawnPoint.forward * bulletSpeed);

        }
    }

    void LateUpdate()
    {
        if (activeBullet == null) return;

        if (activeBullet == null)
        {
            activeBullet = null;
        }
    }
}
