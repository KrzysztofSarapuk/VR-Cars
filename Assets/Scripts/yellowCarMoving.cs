using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yellowCarMoving : MonoBehaviour {
    // Start is called before the first frame update

    public float speed;
    public Transform yellowCar;
    public float startPosition;
    public float endPosition;
    private NPC controller;

    void Start () {
        yellowCar = GetComponent<Transform> ();
        controller = GetComponent<NPC> ();
    }

    // Update is called once per frame
    void Update () {
        // movement from start to end
        if (!controller.blocked) {
            //Temporary solution untli full AI movement is implemented
            if (transform.localPosition.x > startPosition) {
                transform.Translate (0, 0, speed * Time.deltaTime);
                if (transform.localPosition.x > endPosition) {
                    transform.Translate (0, 0, -(endPosition - startPosition));
                }
            }
        }

    }
}