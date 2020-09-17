using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torreta : MonoBehaviour
{
	public Transform target;

	[Header("Atributos")]
	public float fireRate = 1f;
	private float fireCountdown = 3f;
	public float range = 15f;

	[Header("Unity SetUp")]
	public string enemyTag = "Enemy";
	public Transform partToRotate;

	public GameObject bulletPrefab;
	public Transform firePoint;

    void Start()
    {
		InvokeRepeating("UpdateTarget", 0f, 0.05f);
    }

	void UpdateTarget()
	{
		GameObject[]enemies = GameObject.FindGameObjectsWithTag(enemyTag);
		float shortestDistance = Mathf.Infinity;
		GameObject nearest = null;

		foreach(GameObject Enemy in enemies)
		{
			float distanceToEnemy = Vector3.Distance(transform.position, Enemy.transform.position);
			if(distanceToEnemy < shortestDistance)
			{
				shortestDistance = distanceToEnemy;
				nearest = Enemy;
			}

		}

		if (nearest !=null && shortestDistance <= range)
		{
			target = nearest.transform;
		}
	}

    void Update()
    {
		if (target == null)
			return;

		Vector3 dir = target.position - transform.position;
		Quaternion lookRotation = Quaternion.LookRotation(dir);
		Vector3 rotation = lookRotation.eulerAngles;
		partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

		if(fireCountdown <= 0f)
		{
			Shoot();
			fireCountdown = 1f / fireRate;
		}

		fireCountdown -= Time.deltaTime;
    }

	void Shoot()
	{
		GameObject bulletGO = (GameObject) Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
		Bullet bullet = bulletGO.GetComponent<Bullet>();

		if(bullet != null)
		{
			bullet.Chase(target);
		}
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.cyan;
		Gizmos.DrawWireSphere(transform.position, range);
	}
}
