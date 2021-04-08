using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavEnemy : MonoBehaviour
{
	[SerializeField] 
	private int activeDistance = 10;

	[SerializeField] 
	private Transform[] wayPoints;

	[SerializeField]
	private Transform DefLook;

	[SerializeField] 
	private float stoppingDistance = 5;

	[SerializeField] 
	private float timeWait = 3;

	[SerializeField] 
	private float rotationSpeed = 5;

	[SerializeField]
	private Vector3 target;

	private NavMeshAgent agent;
	
	private float curTimeout;
	private int wayCount;
	private bool isTarget;

	void Start()
	{
		agent = GetComponent<NavMeshAgent>();
	}

	void SetRotation(Vector3 lookAt)
	{
		Vector3 lookPos = lookAt - transform.position;
		lookPos.y = 0;
		Quaternion rotation = Quaternion.LookRotation(lookPos);
		transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
	}

	void Update()
	{
		target = PlayerInfo.player.position;
		float dis = Vector3.Distance(transform.position, PlayerInfo.player.position);
		if (dis < activeDistance)
		{
			isTarget = true;
		}

		if (wayPoints.Length >= 2 && !isTarget)
		{
			agent.stoppingDistance = 0;
			agent.SetDestination(wayPoints[wayCount].position);
			if (!agent.hasPath)
			{
				SetRotation(DefLook.position);
				curTimeout += Time.deltaTime;
				if (curTimeout > timeWait) { curTimeout = 0; if (wayCount < wayPoints.Length - 1) wayCount++; else wayCount = 0; }
			}
		}
		else if (wayPoints.Length == 0 || isTarget)
		{
			agent.stoppingDistance = stoppingDistance;
			agent.SetDestination(target);
			if (agent.velocity == Vector3.zero) SetRotation(target);
		}

	}
}
