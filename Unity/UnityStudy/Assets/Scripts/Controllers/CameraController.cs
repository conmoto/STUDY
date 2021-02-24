using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    Define.CameraMode _mode = Define.CameraMode.QuaterView;

    [SerializeField]
    Vector3 _delta = new Vector3(0.0f, 5.0f, -4.0f);

    [SerializeField]
    GameObject _player = null;

    void LateUpdate()
    {
        if(_mode == Define.CameraMode.QuaterView)
        {
            //플레이어와 카메라 사이에 벽이 가로막고 있는 경우.
            RaycastHit hit;
            if(Physics.Raycast(_player.transform.position, _delta, out hit, _delta.magnitude, LayerMask.GetMask("Wall")))
            {
                Vector3 dir = hit.point - _player.transform.position;
                transform.position = _player.transform.position + dir * 0.8f;
            }
            else
            {
                transform.position = _player.transform.position + _delta;
            }
                transform.LookAt(_player.transform);
        }
    }

    public void SetCameraView(Define.CameraMode cameraMode)
    {
        _mode = cameraMode;
    }
}
