using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blueCarMoving : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed;
    public Transform yellowCar;
    public float startPosition;
    public float endPosition;

    void Start()
    {
        yellowCar = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        // movement from start to end
        if (transform.localPosition.z < startPosition)
        {
            transform.Translate(0, 0 , speed * Time.deltaTime);
            if (transform.localPosition.z < endPosition)
            {
                transform.Translate(0, 0, -(startPosition - endPosition)); // startPosition
                print("finisz");
            }
        }
    }
}
