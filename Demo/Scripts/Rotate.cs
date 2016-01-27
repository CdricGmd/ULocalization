using UnityEngine;

public class Rotate : MonoBehaviour
{
	public Vector3 m_AnglePerSec;

	void Update ()
	{
		transform.Rotate(Time.deltaTime * m_AnglePerSec);
	}
}
