using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
	public float objectRotation;
	public Text debugText;
	public Transform gameObjectModel;
	public int beats;
	public int stage;
	public bool headNod;
	public bool nodTime;
	public bool headShake;
	public GameObject panel;
	private float nextFire = 0.0f;
	public AudioSource audio;
	public AudioSource intstructionAudio;
	public AudioClip otherClip1;
	public AudioClip otherClip2;

	public AudioClip introClip;
	public AudioClip startClip;
	public AudioClip Start2pacClip;
	public AudioClip changeClip;
	public AudioClip change2Clip;
	public AudioClip dolbyClip;
	public AudioClip spinClip;
	public AudioClip fordClip;
	// Start is called before the first frame update
	void Start()
	{
		stage = 1;
		headNod = false;
		nodTime = false;
		PlayIntro ();
	}

	// Update is called once per frame
	void Update()
	{
		objectRotation = gameObjectModel.rotation.x;
		if (Time.time >= nextFire) {
			headNod = false;
			headShake = false;
			debugText.text = "";

			if (stage == 1) {
				if (objectRotation > .05f || objectRotation < -.05f  ) {
					beats++;
					nextFire = Time.time + 1f;
				}
				debugText.text = objectRotation.ToString() + "\n Head Bops " + beats.ToString();
			}
			if (stage ==1) {
				if (beats == 5) {
					stage = 2;
					nodTime = true;
					play1();
					Play2Pac1();
					panel.SetActive (true);
				}
			}


		}

	}
	public void HeadNod(){
		if (nodTime) {
			headNod = true;
			nextFire = Time.time + 2f;
			debugText.text = "Nod Yes";
		}

	}
	public void HeadShake(){
		if (nodTime) {
			headShake = true;
			nextFire = Time.time + 2f;
			debugText.text = "Shake No";
			play2 ();
			PlayChange2 ();
			
		}
	}
	public void play1(){
		audio.Play();

	}
	public void play2(){
		audio.clip = otherClip2;
		audio.Play();
		stage = 3;
		StartCoroutine(Story1());

	}
	IEnumerator Story1()
	{
		print(Time.time);
		yield return new WaitForSeconds(15);
		print(Time.time);

		PlaySpin ();
		yield return new WaitForSeconds(10);
		PlayFord ();
	}
	public void PlayIntro(){
		intstructionAudio.clip = introClip;
		intstructionAudio.Play();
	}
	public void PlayStart(){
		intstructionAudio.clip = startClip;
		intstructionAudio.Play();
	}
	public void Play2Pac1(){
		intstructionAudio.clip = Start2pacClip;
		intstructionAudio.Play();
	}
	public void PlayChange1(){
		intstructionAudio.clip = changeClip;
		intstructionAudio.Play();
	}
	public void PlayChange2(){
		intstructionAudio.clip = change2Clip;
		intstructionAudio.Play();
	}
	public void PlayDolby(){
		intstructionAudio.clip = dolbyClip;
		intstructionAudio.Play();
	}
	public void PlaySpin(){
		intstructionAudio.clip = spinClip;
		intstructionAudio.Play();
	}
	public void PlayFord(){
		intstructionAudio.clip = fordClip;
		intstructionAudio.Play();
	}



}
