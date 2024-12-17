using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;// vi tri tuong doi cua target va camera
    public float speed = 20;

    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<Player>().transform;
    }

    // Update is called once per frame
    // nhan vat di chuyen theo fixedUpdate (theo khung thoi gian co dinh) dung camera thi no nhay lung ung 10.13 
    // fixedupdate sau lateupsate thi no cx giat 

    //th nay thi dung fixed con lai hi dung late
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + offset, Time.deltaTime * speed);
    }
}
