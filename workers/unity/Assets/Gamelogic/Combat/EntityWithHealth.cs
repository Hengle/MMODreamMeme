using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityWithHealth : MonoBehaviour {

	public float Health = 10;

	public void DecrimentHealth(float damage)
	{
		Health -= damage;

		if (Health<= 0)
		{
			ObjectKilled();
		}
	}

	void ObjectKilled()
	{
		Destroy(this.gameObject);
	}
}
