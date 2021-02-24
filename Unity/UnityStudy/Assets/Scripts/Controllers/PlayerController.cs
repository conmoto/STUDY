using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float _speed = 5.0f;

    bool _mouseMove = false;
    Vector3 _destPos;

    void Start()
    {
        Managers.Input.KeyAction -= OnKeyboard;
        Managers.Input.KeyAction += OnKeyboard;
        Managers.Input.MouseAction -= OnMouseClicked;
        Managers.Input.MouseAction += OnMouseClicked;
    }

    // GameObject(Player)
        // Transform
        // PlayerController

    void Update()
    {
        if (_mouseMove)
        {
            Vector3 delta = _destPos - transform.position;
            if (delta.magnitude < 0.0001f)
            {
                _mouseMove = false;
            }
            else
            {
                float moveDist = Mathf.Clamp(_speed * Time.deltaTime, 0, delta.magnitude);
                transform.position += delta.normalized * moveDist;//위치 = 방향 * 속력 * 거리 = 속도 * 거리
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(delta), _speed * Time.deltaTime);  
            }
        }

    }

    //transform.gameObject 이 스크립트가 부착되어있는 게임 오브젝트

    // Vector3.magnitude : 벡터의 크기(거리)
    // Vector3.normalized : 방향 단위 벡터

    /*** 이동 ***/
    // transform.position : world 좌표계
    // transform.TransformDirection() : local -> world
        // ex) transform.TransformDirection(Vector3.forward) : local의 전방 벡터를 world로 변환
    // transform.InverseTransformDirection() : world -> local
    // transform.Translate() : local 좌표계 기준으로 이동

    // 3가지 같은 이동 연산
        // transform.position += transform.forward * Time.deltaTime * _speed;
        // transform.position += transform.TransformDirection(Vector3.forward * Time.deltaTime * _speed);
        // transform.Translate(Vector3.forward * Time.deltaTime * _speed);


    /*** 회전 ***/
    // transform.rotation : Quaternion
    // transform.eulerAngles : Vector3 => new Vector3로 통째로 값을 넣어줌
        // 값을 넣어주는게 아닌 +- 연산을 하면 오작동 한다고 유니티 공식 문서에 써있다.
        // transform.eulerAngles += new Vector3(0.0f, Time.deltaTime * _rotSpeed, 0.0f);
    // transform.Rotate(Vector3 eulerAngles) : delta 회전
    // Quaternion.Euler(Vector3 eulerAngle) : Vector3 -> Quaternion
    // Quaternion.LookRotation(Vector3) : 바라보는 방향을 Quaternion으로 반환

    // 회전값 대입1 : transform.rotation = Quaternion.Euler(Vector3 eulerAngle)
    // 회전값 대입2 : transform.eulerAngles = new Vector3 eulerAngle
    // 바라보는 방향 : transform.rotation = Quaternion.LookRotation(Vector3)
    // 회전 1 : transform.Rotate(Vector3 deltaAngle)
    // 회전 2 : transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), interpolate)

    void OnKeyboard()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), 0.3f);
            transform.Translate(Vector3.forward * Time.deltaTime * _speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.back), 0.3f);
            transform.Translate(Vector3.forward * Time.deltaTime * _speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.left), 0.3f);
            transform.Translate(Vector3.forward * Time.deltaTime * _speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.right), 0.3f);
            transform.Translate(Vector3.forward * Time.deltaTime * _speed);
        }

        _mouseMove = false;
    }

    void OnMouseClicked(Define.MouseEvent evt)
    {
        if (evt != Define.MouseEvent.Click)
            return;

        //Raycasting
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(Camera.main.transform.position, ray.direction * 100.0f, Color.red, 1.0f);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100.0f, LayerMask.GetMask("Ground")))
        {
            _destPos = hit.point;
            _mouseMove = true;
            Debug.Log($"Raycast Camera @ {hit.collider.gameObject.name}");
        }
    }

    //private void OnDestroy()
    //{
    //    Managers.Input.KeyAction -= OnKeyboard;
    //}
}
