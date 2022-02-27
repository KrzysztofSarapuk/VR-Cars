using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIDisplay : MonoBehaviour {

    private Rigidbody rigidbody;
    public Text speedText;

    private void Start () {
        rigidbody = GetComponent<Rigidbody> ();
    }

    void Update () {
        if (speedText && rigidbody) {
            Vector3 velocity = rigidbody.velocity;
            velocity.y = 0;
            float mps = velocity.magnitude;
            //Not ideal, but will do fine for this project
            mps *= 1 / rigidbody.gameObject.transform.localScale.magnitude;
            if (mps < 0.5) {
                mps = 0;
            }
            float kph = (mps * 60 * 60) / 1000;
            speedText.text = kph.ToString ("F2") + " k/h";
        }
    }
}