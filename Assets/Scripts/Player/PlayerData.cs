using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Data")]
public class PlayerData : ScriptableObject
{
	[Header("Movement Speed")]
	public float maxSpeed = 10f;
	public float jumpHeight = 5.5f;
	public float jumpForce = 10f;

	public bool isPlayerGround=true;

	[Space(4)]
	public bool isOk;
}
