using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IPlayerRespawnListener
{

	// Use this for initialization
	void Start () {
		
	}

    public void onPlayerRespawnInThisCheckpoint(CheckPoint checkpoint, Player player)
    {
        transform.position = checkpoint.transform.position;
    }
}
