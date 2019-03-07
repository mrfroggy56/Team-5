using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DB_NoteSpawner : MonoBehaviour
{
    public GameObject spawnNotePrefab;
    GameObject clone;
    private Transform thisGameObject;
    public float timeBetweenNotes = 2;
    public float resetTime;

    // Start is called before the first frame update
    void Start()
    {
        // Set the reset timer value to be whatever the timebetween notes value is
        resetTime = timeBetweenNotes;
        // Find the Transform of this gameObject
        thisGameObject = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        // decrease the float value
        timeBetweenNotes -= Time.deltaTime;

        if(timeBetweenNotes <= 0)
        {
            // reset the time 
            timeBetweenNotes = resetTime;
            clone = spawnNotePrefab;
            // Local variable controls the spawn it spawns our prefab
            clone = Instantiate(spawnNotePrefab, thisGameObject.position, Quaternion.identity); 
            // We set the parent to be this gameObject for the spawned object will child to this
            clone.transform.SetParent(thisGameObject);
        }
        
    }
}
