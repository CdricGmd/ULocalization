using UnityEngine;
using System.Collections;

public class LookAt : MonoBehaviour 
{
	public Transform m_target;

	// Update is called once per frame
	void Update () 
	{
		if(m_target)
		{
			float angle = Vector3.Angle(transform.right, m_target.right) % 360;

			if(angle > 90F)
			{
				transform.Rotate(0, 180f, 0);
			}
		}
	}
}
