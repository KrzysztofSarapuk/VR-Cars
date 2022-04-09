using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour {

    public bool blocked, drawDebug;
    public float mainDetectionDistance = 3f;
    public float subDetectionDistance = 2f;
    public Transform[] sensors = new Transform[3];

    // Update is called once per frame
    void Update () {
        bool noneHit = true;
        for (int i = 0; i < sensors.Length; i++) {
            float distance = i == 0 ? mainDetectionDistance : subDetectionDistance;
            Transform sensor = sensors[i].transform;
            bool hit = Physics.Raycast (sensor.position, sensor.TransformDirection (Vector3.forward), out RaycastHit raycastInfo, distance);
            if (hit) {
                noneHit = false;
            }
            if (drawDebug) {
                if (hit) {
                    Debug.DrawRay (sensor.position, sensor.TransformDirection (Vector3.forward) * raycastInfo.distance, Color.red);
                } else {
                    Debug.DrawRay (sensor.position, sensor.TransformDirection (Vector3.forward) * distance, Color.green);
                }
            }
        }
        blocked = !noneHit;

    }
}