using UnityEngine;
using System.Collections;

public class KeepRotating : MonoBehaviour {
	public Vector3 axis = Vector3.up;
	public float rotationsPerSecond = 0.5f;

	void Update() {
		var angle = 360 * rotationsPerSecond * Time.deltaTime;
		transform.Rotate (axis, angle);
	}
}
