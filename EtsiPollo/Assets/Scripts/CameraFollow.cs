using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public Transform player;

	private Vector3 moveVec;
	// Start is called before the first frame update
	void Start()
	{
		moveVec = player.position;
	}

	// Update is called once per frame
	void Update()
	{
		moveVec = player.position;
		moveVec.z = transform.position.z;
		transform.position = moveVec;
	}
}
