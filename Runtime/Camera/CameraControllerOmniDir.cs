using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerOmniDir : MonoBehaviour
{
    [SerializeField]
    private Camera _targetCamera;

    public float DirCtrlSpeed = 1f;
    public float FovCtrlSpeed = 1f;
    private KeyCode ResetKey = KeyCode.Space;

    private float _rotX = 0f;
    private float _rotY = 0f;
    private Quaternion _origRot;
    private float _origFov;

    private bool _resettingCam = false;

    void Start()
    {
        if(_targetCamera == null)
        {
            _targetCamera = Camera.main;
        }
        _origRot = _targetCamera.transform.localRotation;
        _origFov = _targetCamera.fieldOfView;
    }

    void Update()
    {
        if (_resettingCam)
        {
            return;
        }

        UpdateFoV();
        if(Input.GetMouseButton(0))
        {
            UpdateDirection();
        }
        if(Input.GetKeyDown(ResetKey))
        {
            ResetCamera(0.5f);
        }
    }

    void UpdateDirection()
    {
        _rotX = ClampAngle(_rotX - Input.GetAxis("Mouse X") * DirCtrlSpeed, -360, 360);
        _rotY = ClampAngle(_rotY - Input.GetAxis("Mouse Y") * DirCtrlSpeed, -90, 90);
        var xQuat = Quaternion.AngleAxis(_rotX, Vector3.up);
        var yQuat = Quaternion.AngleAxis(_rotY, Vector3.left);
        _targetCamera.transform.localRotation = _origRot * xQuat * yQuat;
    }

    void UpdateFoV()
    {
        var scroll = Input.GetAxis("Mouse ScrollWheel") * FovCtrlSpeed;
        _targetCamera.fieldOfView = Mathf.Clamp(_targetCamera.fieldOfView - scroll, 20, 100);
    }

    public void ResetCamera(float durationSec = 1.0f)
    {
        StartCoroutine(ResetCameraCoroutine(durationSec));
    }

    private IEnumerator ResetCameraCoroutine(float durationSec)
    {
        _resettingCam = true;
        var startRot = _targetCamera.transform.localRotation;
        var startFoV = _targetCamera.fieldOfView;
        var transitionCurve = AnimationCurve.EaseInOut(0f, 0f, durationSec, 1f);
        var currSec = 0.0f;
        while(Mathf.Abs(Quaternion.Angle(_targetCamera.transform.localRotation, _origRot)) > 0.01f
                || Mathf.Abs(_targetCamera.fieldOfView - _origFov) > 0.01f)
        {
            currSec += Time.deltaTime;
            var interp = transitionCurve.Evaluate(currSec);
            _targetCamera.transform.localRotation = Quaternion.Slerp(startRot, _origRot, interp);
            _targetCamera.fieldOfView = Mathf.Lerp(startFoV, _origFov, interp);
            yield return null;
        }
        _targetCamera.transform.localRotation = _origRot;
        _rotX = _rotY = 0.0f;
        _targetCamera.fieldOfView = _origFov;
        _resettingCam = false;
    }

    public static float ClampAngle(float targetDeg, float minDeg, float maxDeg)
    {
        return Mathf.Clamp(Mathf.Repeat(targetDeg + 360f, 720f) - 360f, minDeg, maxDeg);
    }
}
