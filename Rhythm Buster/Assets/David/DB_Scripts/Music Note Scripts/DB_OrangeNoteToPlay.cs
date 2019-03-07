using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DB_OrangeNoteToPlay : MonoBehaviour
{
    public float speed = 3;
    private void Update()
    {
        transform.Translate(-Vector3.right * speed);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayNoteNowTrigger")
        {
            DB_GM.canPlayOrangeDrum = true;
        }
        else
            DB_GM.canPlayOrangeDrum = false;

        if (other.gameObject.tag == "PlayNoteNowDying")
        {
            Destroy(gameObject);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "PlayNoteNowTrigger")
        {
            DB_GM.canPlayOrangeDrum = false;
        }
    }
}
