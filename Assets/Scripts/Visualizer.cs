using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class Visualizer : MonoBehaviour {
	public SpectrumController prefab;
	public float maxHeight = 1024;
	public int radius = 32;

	List<Vector2> generationList = new List<Vector2>();

	void Start () {
		//var map = new bool[size,size];
		var radiusSq = radius*radius;
		for (int y=-radius; y<radius; y++){
			for (int x=-radius; x<radius; x++){
				var p = new Vector2 (x, y);
				if (p.sqrMagnitude < radiusSq) {
					//GenerateTile (p);
					generationList.Add(p);
				}
			}
		}

		//print ("Generating " + generationList.Count + " tiles...");
		StartCoroutine("Generate");
	}

	void Generate () {
		Vector2 currentVector;

		while(generationList.Count!=0) {
		//for (var i = 0; i < 10; ++i) {
			currentVector = generationList[Random.Range(0,generationList.Count)];
			GenerateTile(currentVector);
			generationList.Remove(currentVector);
		}
	}

	void GenerateTile (Vector2 vc2) {
		// change the vc2 to vc3 and move it to the center
		//Vector3 pos = new Vector3(vc2.x, -maxHeight, vc2.y);
		Vector3 pos = new Vector3(vc2.x, 0, vc2.y);
		var dist = vc2.magnitude;

		var spawnedTile = (SpectrumController)Instantiate(prefab,pos,prefab.transform.rotation);
		//spawnedTile.maxHeight = (1+dist) * maxHeight;
		spawnedTile.maxHeight = maxHeight;
		//spawnedTile.spectrumIndex = (int)(Mathf.Round(dist/(float)radius * AudioManager.SampleCount));
		spawnedTile.spectrumIndex = (int)(Mathf.Round(dist));
	}



	void OnDrawGizmos() {
		var c = Color.yellow;
		c.a = 0.2f;
		Gizmos.color = c;

		Gizmos.DrawWireSphere(transform.position, radius);
	}
}