using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour,IPlayerRespawnListener
{

    private Vector3 initPos;

    private void Start()
    {
        initPos = transform.position;
    }

    public void onPlayerRespawnInThisCheckpoint(CheckPoint checkpoint, Player player)
    {
        transform.position = initPos;
    }
}
