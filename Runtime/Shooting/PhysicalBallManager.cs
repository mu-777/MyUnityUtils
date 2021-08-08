using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalBallManager : MonoBehaviour {

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (this.transform.position.y < -30.0f) {
            Destroy(this.gameObject);
        }
    }
}
