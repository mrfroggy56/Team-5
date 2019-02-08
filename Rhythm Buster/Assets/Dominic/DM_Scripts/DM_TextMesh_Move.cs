using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DM_TextMesh_Move : MonoBehaviour
{

    public float speed = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, speed * Time.deltaTime, 0);
    }
}
