using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class EditorSpawner : MonoBehaviour
{
	[SerializeField] private GameObject[] objectsToSpawn;
	[SerializeField] private int amountToSpawn;
	public GameObject SpawnParent;
	public float size = 10.0f;
	public bool buttonTrigger;
	public int heightOffset = 3;
	public bool timedSpawn = false;
	public bool waves = false;

	public bool lookAtPlacement; // will it rotate based on where it hits?


	void Update()
	{
		transform.localScale = new Vector3(size / 5, 1, size / 5);
		if (buttonTrigger)
		{
			TriggerSpawn();
		}

	}
	void Start()
	{
		if (timedSpawn)
		{
			StartCoroutine(TimedSpawn());
		}
	}

	IEnumerator TimedSpawn()
	{
		while (true)
		{
			yield return new WaitForSeconds(15f);
			TriggerSpawn();
			if (waves) {
				++amountToSpawn;
			}
		}
	}

	// On disabled, stop all co-routines in order to prevent more spawning
	private void OnDisable()
	{
		StopAllCoroutines();
	}


	void TriggerSpawn()
	{

		// Bit shift the index of the layer (8) to get a bit mask
		int layerMask = 1 << 8;

		for (int n = 0; n < amountToSpawn; n++)
		{
			Vector3 pos = new Vector3(transform.position.x + Random.Range(-size, size), transform.position.y, transform.position.z + Random.Range(-size, size));
			int randItem = Random.Range(0, objectsToSpawn.Length - 1);


			RaycastHit theThingIHit;
			if (Physics.Raycast(pos, transform.TransformDirection(Vector3.down), out theThingIHit, Mathf.Infinity, layerMask))
			{
				Debug.DrawRay(pos, transform.TransformDirection(Vector3.down) * 50, Color.green, 5.0f);
				// bonus points: get them to parent to the spawnParent when created
				GameObject newObject;

				// int randomScale = Random.Range(1, 5); // Random Size integer
				// Vector3 scaleChange = new Vector3(randomScale, randomScale, randomScale); // Random Scale Vector

				if (lookAtPlacement)
				{
					Quaternion newRotation = Quaternion.FromToRotation(Vector3.up, theThingIHit.normal);
					newObject = Instantiate(objectsToSpawn[randItem], theThingIHit.point - Vector3.up * heightOffset, newRotation); // use hit normal to set rotation

				}
				else
				{
					newObject = Instantiate(objectsToSpawn[randItem], theThingIHit.point - Vector3.up * heightOffset, transform.rotation);

				}
				if (SpawnParent)
					newObject.transform.SetParent(SpawnParent.transform);
				// Scale object after instantiation
				// newObject.transform.localScale = scaleChange;

			}
			else
			{
				//Debug.DrawRay(pos, transform.TransformDirection( Vector3.down ), Color.red, 3.0f);
				Debug.Log("Did not hit terrain");
				//Debug.Log( theThingIHit );
			}
		}
		buttonTrigger = false;
	}
}