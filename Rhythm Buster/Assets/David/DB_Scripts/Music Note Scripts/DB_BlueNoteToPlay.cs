﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DB_BlueNoteToPlay : MonoBehaviour
{
    public float speed= 6;
    private void Update()
    {
        transform.Translate(-Vector3.right * speed);
    }
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "PlayNoteNowTrigger")
        {
            DB_GM.canPlayBlueTamberine = true;
        }
        else
            DB_GM.canPlayBlueTamberine = false;

        if (other.gameObject.tag == "PlayNoteNowDying")
        {
            Destroy(gameObject);
        }

        if(other.gameObject.tag == "ResetBoolTrigger")
        {
            DB_GM.canPlayBlueTamberine = false;
        }
    }

    public void OnTriggerExit(Collider other)
    {

        //if (other.gameObject.tag == "PlayNoteNowTrigger")
        //{
        //    DB_GM.canPlayBlueTamberine = false;
        //}
    }
}
