using UnityEngine;
using System.Collections;
using System.Diagnostics;

public class QuadTreeTest : MonoBehaviour 
{
	public class TestObject : IQuadTreeObject
	{
		private Vector3 m_vPosition;
		public TestObject(Vector3 position){
			m_vPosition = position;
		}
		public Vector2 GetPosition(){
			//Ignore the Y position, Quad-trees operate on a 2D plane.
			return new Vector2(m_vPosition.x, m_vPosition.z);
		}
	}

	QuadTree<TestObject> quadTree;
	void OnEnable(){
		Stopwatch timer = new Stopwatch();
		quadTree = new QuadTree<TestObject>(1, new Rect(-1000,-1000,2000,2000));
		
		TestObject[] objectArray = new TestObject[3000];

		for (int i = 0; i < objectArray.Length; i++)
		{
			TestObject newObject = new TestObject(new Vector3(Random.Range(-900,900),0,Random.Range(-900,900)));
			objectArray[i] = newObject;
		}


		timer.Start();
			//quadTree.Insert(newObject);
		
		foreach(TestObject to in objectArray)
		{
			quadTree.Insert(to);
		}

		timer.Stop();

		UnityEngine.Debug.Log("Time taken: " + timer.Elapsed);
	}
	void OnDrawGizmos(){
		if(quadTree != null){
			//quadTree.DrawDebug();
		}
	}
}