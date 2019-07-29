using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCharaController : MonoBehaviour {

    public GameObject Ball;
    public float BallForce = 1;
    public float MotionScale = 0.3f;
    public bool IsKeyMoveActive = true;

    private bool isShooting = false;
    private float shootingInterval = 0.3f;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (IsKeyMoveActive) {
            this.transform.localPosition += GetMotionDirection() * MotionScale;
        }

        if (Input.GetKey(KeyCode.Mouse0) || Input.GetKey(KeyCode.Return)) {
            ShootBall();
        }

    }


    private void ShootBall() {
        if (isShooting) {
            return;
        }
        Debug.Log("Ball Spawn");
        var spawnedBall = Instantiate(Ball, this.transform.position + this.transform.forward,
                                      this.transform.rotation);
        spawnedBall.GetComponent<Rigidbody>().AddForce(BallForce * (this.transform.forward + this.transform.up * 0.3f));
        isShooting = true;
        StartCoroutine("ControllShoodingFlag");
    }

    private IEnumerator ControllShoodingFlag() {
        yield return new WaitForSeconds(shootingInterval);
        isShooting = false;
        Debug.Log("shooting reseted");
    }

    private Vector3 GetMotionDirection() {
        var ret = Vector3.zero;
        if (Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.PageUp)) {
            ret += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            ret += Vector3.left;
        }
        if (Input.GetKey(KeyCode.C) || Input.GetKey(KeyCode.PageDown)) {
            ret += Vector3.back;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
            ret += Vector3.right;
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
            ret += Vector3.up;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
            ret += Vector3.down;
        }
        return ret;
    }
}
