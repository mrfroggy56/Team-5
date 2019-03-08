using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DB_DrumKit_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayDrum();
    }

    void PlayDrum()
    {
        // If the left mouse button is pressed down
        if (Input.GetMouseButtonDown(0))
        {
            // Raycast hit variable
            RaycastHit hit;
            // Ray value that will be shot from the main camera (ARCamera)
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            // if the raycast spawns
            if (Physics.Raycast(ray, out hit))
            {
                // if the collider is hit with certain tag amd a boolean in GM is true
                if (hit.collider.gameObject.tag == "Tamberine" && DB_GM.canPlayBlueTamberine == true)
                {
  
                    GameObject tamberine = GameObject.Find("BlueNote(Clone)");
                    Destroy(tamberine);
                    DB_GM.canPlayBlueTamberine = false;
                    DB_GM.Score += 50;
                    tamberine = null;
                    
                }
                //else if(DB_GM.canPlayBlueTamberine == false)
                //{
                //    DB_GM.canPlayBlueTamberine = false;
                //}

                // if the collider is hit with certain tag
                if (hit.collider.gameObject.tag == "HighHat" && DB_GM.canPlayPurpleHighkick == true)
                {
   
                    GameObject highKick = GameObject.Find("PurpleNote(Clone)");
                    Destroy(highKick);
                    DB_GM.canPlayPurpleHighkick = false;
                    DB_GM.Score += 50;
                    highKick = null;
                }
                //else if(DB_GM.canPlayPurpleHighkick == false)
                //{
                //    DB_GM.canPlayPurpleHighkick = false;
                //}

                // if the collider is hit with certain tag
                if (hit.collider.gameObject.tag == "MeduimDrum" && DB_GM.canPlayGreenDrums == true)
                {
                    GameObject medDrum = GameObject.Find("GreenNote(Clone)");
                    Destroy(medDrum);
                    DB_GM.canPlayGreenDrums = false;
                    DB_GM.Score += 50;
                    medDrum = null;
                }
                //else if(DB_GM.canPlayGreenDrums == false)
                //{
                //    DB_GM.canPlayGreenDrums = false;
                //}

                // if the collider is hit with certain tag
                if (hit.collider.gameObject.tag == "SmallDrum" && DB_GM.canPlayOrangeDrum == true)
                {
                    GameObject smallDrum = GameObject.Find("OrangeNote(Clone)");
                    Destroy(smallDrum);
                    DB_GM.canPlayOrangeDrum = false;
                    DB_GM.Score += 50;
                    smallDrum = null;
                }
                //else if (DB_GM.canPlayOrangeDrum == false)
                //{
                //    DB_GM.canPlayOrangeDrum = false;
                //}

                // if the collider is hit with certain tag
                if (hit.collider.gameObject.tag == "KickDrum" && DB_GM.canPlayYellowDrum == true)
                {
                    GameObject KickDrum = GameObject.Find("YellowNote(Clone)");
                    Destroy(KickDrum);
                    DB_GM.canPlayYellowDrum = false;
                    DB_GM.Score += 50;
                    KickDrum = null;
                }
                //else if(DB_GM.canPlayYellowDrum == false)
                //{
                //    DB_GM.canPlayYellowDrum = false;
                //}
            }
        }
    }
}