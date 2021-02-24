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
                transform.position += delta.normalized * moveDist;//��ġ = ���� * �ӷ� * �Ÿ� = �ӵ� * �Ÿ�
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(delta), _speed * Time.deltaTime);  
            }
        }

    }

    //transform.gameObject �� ��ũ��Ʈ�� �����Ǿ��ִ� ���� ������Ʈ

    // Vector3.magnitude : ������ ũ��(�Ÿ�)
    // Vector3.normalized : ���� ���� ����

    /*** �̵� ***/
    // transform.position : world ��ǥ��
    // transform.TransformDirection() : local -> world
        // ex) transform.TransformDirection(Vector3.forward) : local�� ���� ���͸� world�� ��ȯ
    // transform.InverseTransformDirection() : world -> local
    // transform.Translate() : local ��ǥ�� �������� �̵�

    // 3���� ���� �̵� ����
        // transform.position += transform.forward * Time.deltaTime * _speed;
        // transform.position += transform.TransformDirection(Vector3.forward * Time.deltaTime * _speed);
        // transform.Translate(Vector3.forward * Time.deltaTime * _speed);


    /*** ȸ�� ***/
    // transform.rotation : Quaternion
    // transform.eulerAngles : Vector3 => new Vector3�� ��°�� ���� �־���
        // ���� �־��ִ°� �ƴ� +- ������ �ϸ� ���۵� �Ѵٰ� ����Ƽ ���� ������ ���ִ�.
        // transform.eulerAngles += new Vector3(0.0f, Time.deltaTime * _rotSpeed, 0.0f);
    // transform.Rotate(Vector3 eulerAngles) : delta ȸ��
    // Quaternion.Euler(Vector3 eulerAngle) : Vector3 -> Quaternion
    // Quaternion.LookRotation(Vector3) : �ٶ󺸴� ������ Quaternion���� ��ȯ

    // ȸ���� ����1 : transform.rotation = Quaternion.Euler(Vector3 eulerAngle)
    // ȸ���� ����2 : transform.eulerAngles = new Vector3 eulerAngle
    // �ٶ󺸴� ���� : transform.rotation = Quaternion.LookRotation(Vector3)
    // ȸ�� 1 : transform.Rotate(Vector3 deltaAngle)
    // ȸ�� 2 : transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), interpolate)

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
