using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Town : MonoBehaviour {

	public int  team = 0;
	public int maxUnits = 15;

	public LivingEntity BaseAIUnit;

	public List<LivingEntity> ownedUnits = new List<LivingEntity>();

	public Vector3 TownLocation;


	



	// Use this for initialization
	void Start () {
		// Set the town location - this should never cahnge
		TownLocation = this.gameObject.transform.position;

		team = Random.Range(1,10);

		// Reguarly check for the spawning of new NPCS
		InvokeRepeating("CheckForSpawns", 0, 1.0f);
		//CheckForSpawns();
	}

	void CheckForSpawns()
	{
		// Clear the list of nulls
		ownedUnits.RemoveAll(LivingEntity => LivingEntity == null);
		
		if (ownedUnits.Count<maxUnits)
		{
			SpawnUnit();
		}
	}

	void SpawnUnit()
	{
		// Spawn new unit
		LivingEntity newUnit = Instantiate(BaseAIUnit, TownLocation, Quaternion.identity);

		// Make sure to set NPCs town
		newUnit.team = team;

		// Add to list of owned units
		ownedUnits.Add(newUnit);

		// Print debug stuff
		Debug.Log("Spawning a new Unit");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
