using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public float speed = 3f;

	private Transform target;
	private int wavepointIndex = 0;

	void Start()
	{
		target = WayPoints.points[0];
	}

	 void Update()
	{
		Vector3 dir = target.position - transform.position;
		transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
		transform.LookAt(target);
	
	
		if (Vector3.Distance(transform.position, target.position) <= 0.2f)
		{
			GetNextWayPoint();
		}

		void GetNextWayPoint()
		{
			if(wavepointIndex >= WayPoints.points.Length - 1)
			{
				EndPath();
				return;
			}

			wavepointIndex++;
			target = WayPoints.points[wavepointIndex];
		}
	}

	void EndPath()
	{
		PlayerStats.Lives--;
		Destroy(gameObject);
	}
}
