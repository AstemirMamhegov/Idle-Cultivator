using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleAnimation : MonoBehaviour
{
    public float speed;
    private Vector3 target = new Vector3(0, 0, 0);

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, target, Time.deltaTime * speed);
        if (transform.localPosition == target && target.y != 0.01f)
            target.y = 0.01f;
        else if (transform.localPosition == target && target.y == 0.01f)
            target.y = 1.39f;
    }
}
