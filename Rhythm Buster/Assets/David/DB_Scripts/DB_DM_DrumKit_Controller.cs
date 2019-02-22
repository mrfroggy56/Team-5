using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DB_DM_DrumKit_Controller : MonoBehaviour
{
    #region Variables
    // Variables 
    // Array of GameObjects that're the parents children.
    public GameObject[] myChildren;
    // GameObject that is choosen from array that changes renderer material
    public GameObject chosenChild;
    // Emission Material that is applied
    public Material drumkit_material;
    // Default material that changes
    public Material drumkit_defaultMat;
    public GameObject AddPoints;
    public GameObject DecreasePoints;
    // Int that holds all the array children values between 0 and whatever other number
    private int childIndex;
    // Value that decreases over time. Used to change objct rendered material if player doesnt use input.
    private float timer = 3f;
    private int ArrayCheck = 0;

    // Sound Variables 
    public AudioSource currentAudioSource;
    #endregion
    #region Important Notes
    // To declare all children in the drum kit MUST HAVE MESH COLLIDERS OFF.
    // If they are not off then this script wont work efficently. 
    // We need colliders off so EMISSION applied Children cannot change by pressing any collider
    #endregion
    #region Awake Function
    // Start is called before the first frame update
    void Awake()
    {
        // Finds all children and puts them into an array attached to the parent GameObject
        //myChildren = GameObject.FindGameObjectsWithTag("DrumChildren");       // Keep left out. Makes Array filled with tagged objects in order
        drumkit_material.DisableKeyword("_EMISSION");
        chosenChild = myChildren[ArrayCheck];      //choosenChild sets the first highlighted object to be whatever is at ArrayCheck's position in the array
        ArrayCheck++;       //Increment ArrayCheck by one for the next iteration
        #region old code Version 1.1
        //// Make an int that carries the value of how many objects are in the array
        //childIndex = Random.Range(0, myChildren.Length);
        //// Choose a random GameObject from the array
        //choosenChild = myChildren[childIndex];
        #endregion
        // Change that choosen GameObject from the array and make is visually seen by changing the material
        chosenChild.GetComponent<Renderer>().material = drumkit_material;
        // Turn on the choosen colliders MeshCollider
        chosenChild.GetComponent<Collider>().enabled = true;
        // Print what GameObject has been choosen by the computer in the console
        print(chosenChild.name);
        currentAudioSource = chosenChild.GetComponent<AudioSource>();
    }
    #endregion
    #region Update Function
    // Update is called once per frame
    void Update()
    {
        // Functions
        OnMouseClick();
        // When the time is over 1
        if (Time.time >= 1.0f)
        {
            // Enable the EMISSION on the material variable
            drumkit_material.EnableKeyword("_EMISSION");
        }
        // Decrease the timer float with time
        timer -= Time.deltaTime;
        // When the timer is more than or equal to 0
        if(timer<=0)
        {
            timer = 3;
            // Change current child material to the default material
            chosenChild.GetComponent<Renderer>().material = drumkit_defaultMat;
            // Turn off the old choosen objects collider
            chosenChild.GetComponent<Collider>().enabled = false;
            GameObject textMesh = Instantiate(DecreasePoints, chosenChild.transform.position, Quaternion.identity);
            Destroy(textMesh, 2f);
            if (ArrayCheck >= myChildren.Length) {
                ArrayCheck = 0;     //Reset ArrayCheck when the end of the array is reached
            }
            chosenChild = myChildren[ArrayCheck];      //choosenChild selects the gameobject that corresponds with ArrayCheck's position in the array
            #region old code version 1.1
            //// Go through the array of children again
            //childIndex = Random.Range(0, myChildren.Length);        // remove and add manual system
            //// The Choosen child GameObject picks a GameObject in the array of children 
            //choosenChild = myChildren[childIndex];  // remove and add manual system
            #endregion
            // Change the Rendered material to the EMISSION Material
            chosenChild.GetComponent<Renderer>().material = drumkit_material;
            // Turn on the new choosen objects collider
            chosenChild.GetComponent<Collider>().enabled = true;
            currentAudioSource = chosenChild.GetComponent<AudioSource>();
            // Show in the console what GameObject is now the choosen child
            print("FAILED CHANCE");
            ArrayCheck++;   //Increment ArrayCheck by one for the next iteration
        }
    }
    #endregion
    #region MouseClick Function
    void OnMouseClick()
    {
        // If the left mouse button is pressed down
        if(Input.GetMouseButtonDown(0))
        {
            // Raycast hit variable
            RaycastHit hit;
            // Ray value that will be shot from the main camera (ARCamera)
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            // if the raycast spawns
            if(Physics.Raycast(ray, out hit))
            {
                // Collider variable
                Collider col = hit.collider as Collider;
                // if the collider is hit
                if(col != null)
                {
                    timer = 3;
                    // Change current child material to the default material
                    chosenChild.GetComponent<Renderer>().material = drumkit_defaultMat;
                    
                    // Turn off the old choosen objects collider
                    chosenChild.GetComponent<Collider>().enabled = false;
                    currentAudioSource = chosenChild.GetComponent<AudioSource>();
                    currentAudioSource.Play();
                    if (ArrayCheck >= myChildren.Length)
                    {
                        //ArrayCheck = 0;     //Reset ArrayCheck when the end of the array is reached
                        Application.LoadLevel(0);       // Changes Scene when player restarts the array of GOs
                    }
                    chosenChild = myChildren[ArrayCheck];      //chosenChild selects the gameobject that corresponds with ArrayCheck's position in the array
                    // Chnage the Rendered material to the EMISSION Material
                    chosenChild.GetComponent<Renderer>().material = drumkit_material;
                    // Turn on the new choosen objects collider
                    chosenChild.GetComponent<Collider>().enabled = true;
                    currentAudioSource = chosenChild.GetComponent<AudioSource>();
                    // Show in the console what GameObject is now the choosen child
                    print(chosenChild.name);
                    ArrayCheck++;       //Increment ArrayCheck by one for the next iteration
                }
            }
        }
    }
    #endregion
}
