using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPostion;
    private float repeatWidth;

    // Start is called before the first frame update
    void Start()
    {
        startPostion = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.x * .5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < startPostion.x - repeatWidth)
        {
            transform.position = startPostion;
        }
    }
}
