using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinBase_final : MonoBehaviour
{

	// Use this for initialization
	void OnTriggerEnter(Collider _col)
    {
        Debug.Log("Glückwunsch du hast gewonnen");
    }
}
