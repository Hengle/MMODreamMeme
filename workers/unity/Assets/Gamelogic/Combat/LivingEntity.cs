using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingEntity : MonoBehaviour {

	public float Health = 10;
	public bool Debug;
	public int team;

	void OnEnable()
	{
	}

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
		// Drop a corpse
		
		Destroy(this.gameObject);
	}
}
