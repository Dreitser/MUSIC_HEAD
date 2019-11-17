using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
	public float objectRotation;
	public Text debugText;
	public Transform gameObjectModel;
	public bool headNod;
	public bool headShake;
	private float nextFire = 0.0f;

	// Start is called before the first frame update
	void Start()
	{
		headNod = false;
	}

	// Update is called once per frame
	void Update()
	{
		objectRotation = gameObjectModel.rotation.x;
		if (Time.time >= nextFire) {
			headNod = false;
			headShake = false;
			debugText.text = objectRotation.ToString();
		}

	}
	public void HeadNod(){
		headNod = true;
		nextFire = Time.time + 2f;
		debugText.text = "Nod Yes";
	}
	public void HeadShake(){
		headShake = true;
		nextFire = Time.time + 2f;
		debugText.text = "Shake No";
	}
}
