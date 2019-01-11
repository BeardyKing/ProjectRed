using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

	[Header("References")]
	[Space(3)]

	public Transform cam;
	public Transform player;

	[Header("Offsets")]
	[Space(3)]

	public float zDistance;
	public float xOffset;
	public float yOffset;
    private void Awake()
    {
        transform.position = player.position;
    }
    void Update() {
		cam.position = Vector3.Lerp(
			new Vector3(
				cam.position.x,
				cam.position.y,
				zDistance),
			new Vector3(
				player.position.x + xOffset,
				player.position.y + yOffset,
				zDistance),
			5f * Time.deltaTime);
	}
}
