using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player; // attach to player

    private Vector3 offset; // distance between camera and player (subtract transforms)

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // LateUpdate is useful for cameras, procedural animation and
    // getting last known states. It works like Update, but is called
    // last after Update. Thus guarantees player has moved for that frame.
    void LateUpdate()
    {
        transform.position = player.transform.position + offset; 
    }
}
