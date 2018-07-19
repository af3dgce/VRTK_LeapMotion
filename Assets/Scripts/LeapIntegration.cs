using Leap.Unity.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class LeapIntegration : MonoBehaviour {

	// Use this for initialization
	void Start () {
		var ib = GetComponent<InteractionBehaviour>();
		ib.OnPerControllerContactBegin += (InteractionController c) =>
		{
			//c.GetComponent<VRTK_InteractTouch>().ForceTouch(gameObject);
			GetComponent<VRTK_InteractableObject>().StartTouching(c.GetComponent<VRTK_InteractTouch>());
			Debug.Log("Start touching by: " + c.name);
		};
		ib.OnPerControllerContactEnd += (InteractionController c) =>
		{
			GetComponent<VRTK_InteractableObject>().StopTouching(c.GetComponent<VRTK_InteractTouch>());
			//c.GetComponent<VRTK_InteractTouch>().ForceStopTouching();
			Debug.Log("Stop touching");
		};
		ib.OnPerControllerGraspBegin += (InteractionController c) =>
		{
			GetComponent<VRTK_InteractableObject>().Grabbed(c.GetComponent<VRTK_InteractGrab>());
			//c.GetComponent<VRTK_InteractGrab>().AttemptGrab();
			Debug.Log("Start grabbing by: " + c.name);
		};
		ib.OnPerControllerGraspEnd += (InteractionController c) =>
		{
			GetComponent<VRTK_InteractableObject>().Ungrabbed(c.GetComponent<VRTK_InteractGrab>());
			//c.GetComponent<VRTK_InteractGrab>().ForceRelease();
			//c.GetComponent<VRTK_InteractGrab>().ForceRelease();
			Debug.Log("Stop grabbing");
		};
	}
}
