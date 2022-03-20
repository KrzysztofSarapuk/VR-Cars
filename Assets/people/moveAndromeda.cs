using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveAndromeda : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 2;
    public Transform Andromeda;
    public float startPosition = 20;
    public float endPosition = 0;

    void Start()
    {
        Andromeda = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        // movement from start to end
        if (transform.localPosition.x > startPosition)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
            if (transform.localPosition.x > endPosition)
            {
                transform.Translate(0, 0, -(startPosition - endPosition));
            }
        }
    }
}
