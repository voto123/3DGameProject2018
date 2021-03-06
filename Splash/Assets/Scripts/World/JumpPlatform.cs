﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
public class JumpPlatform : MonoBehaviour {


	[Tooltip("Set how many times the normal jump velocity you want the player to jump with.")]
	public float velocityMultiplier = 2f;

	[FMODUnity.EventRef] public string platformJumpSE;
	private PlayerController playerController;
	private Animator anim;

	void Start () {
		anim = GetComponentInChildren<Animator>();
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			anim.SetTrigger("jump");
			playerController = other.GetComponent<PlayerController>();
			FMODUnity.RuntimeManager.PlayOneShot(platformJumpSE, transform.position);
			playerController.PlatformJump(velocityMultiplier);
		}
	}
}
