using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;


public class OctreeMonoTest : MonoBehaviour {

	BoundsOctree<GameObject> testOctree;

	// Use this for initialization
	void Start () {
		
		Vector3 octreeCenter = new Vector3(0,0,0);
		testOctree = new BoundsOctree<GameObject>(200, octreeCenter, 0.25f, 1.0f);


		Vector3 boundsSize = new Vector3(1,1,1);

		Stopwatch myStopwatch = new Stopwatch();
		myStopwatch.Start();
		for (int i = 0; i < 3000; i++)
		{
			Vector3 randomVector = new Vector3((Random.value - 0.5f) * 100, (Random.value - 0.5f) * 100, (Random.value - 0.5f) * 100);
			GameObject myGameObject = new GameObject();
			GameObject newObject = Instantiate(myGameObject);

			newObject.transform.position = randomVector;

			Bounds newbounds = new Bounds(newObject.transform.position, boundsSize);
			testOctree.Add(newObject, newbounds);
			testOctree.Remove(newObject);
		}

		myStopwatch.Stop();
		UnityEngine.Debug.Log(myStopwatch.Elapsed);


	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnDrawGizmos()
	{
		if (testOctree != null)
		{
			testOctree.DrawAllBounds();
			testOctree.DrawAllObjects();
		}
		

	}
}
