using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Define.InputMode _inputMode = Define.InputMode.Mouse;

    [SerializeField]
    float _speed = 5.0f;

    Vector3 _destPos;

    float wait_run_ratio = 0;

    void Start()
    {
        if(_inputMode == Define.InputMode.Keyboard)
        {
            Managers.Input.KeyAction -= OnKeyboard;
            Managers.Input.KeyAction += OnKeyboard;
        }
        else if(_inputMode == Define.InputMode.Mouse)
        {
            Managers.Input.MouseAction -= OnMouseClicked;
            Managers.Input.MouseAction += OnMouseClicked;
        }
    }

    public enum PlayerState
    {
        Idle,
        Moving,
        Die,
    }
    PlayerState _state = PlayerState.Idle;

    void UpdateIdle()
    {
        Animator anim = GetComponent<Animator>();
        anim.SetFloat("speed", 0);

        // ���� �����Ű��
        //wait_run_ratio = Mathf.Lerp(wait_run_ratio, 0, 10 * Time.deltaTime);
        //anim.SetFloat("wait_run_ratio", wait_run_ratio);
        //anim.Play("WAIT_RUN");
    }
    void UpdateMoving()
    {
        Vector3 delta = _destPos - transform.position;
        if (delta.magnitude < 0.0001f)
        {
            _state = PlayerState.Idle;
        }
        else
        {
            float moveDist = Mathf.Clamp(_speed * Time.deltaTime, 0, delta.magnitude);
            transform.position += delta.normalized * moveDist;//��ġ = ���� * �ӷ� * �Ÿ� = �ӵ� * �Ÿ�
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(delta), _speed * Time.deltaTime);
        }

        //�ִϸ��̼�
        Animator anim = GetComponent<Animator>();
        anim.SetFloat("speed", _speed);

        //���� �����Ű��
        //wait_run_ratio = Mathf.Lerp(wait_run_ratio, 1, 10 * Time.deltaTime);
        //anim.SetFloat("wait_run_ratio", wait_run_ratio);
        //anim.Play("WAIT_RUN");
    }
    void Update()
    {
        switch(_state)
        {
            case PlayerState.Die:
                break;
            case PlayerState.Idle:
                UpdateIdle();
                break;
            case PlayerState.Moving:
                UpdateMoving();
                break;
        }        
    }

    void OnMouseClicked(Define.MouseEvent evt)
    {
        if (evt != Define.MouseEvent.Click)
            return;
        if (_state == PlayerState.Die)
            return;

        //Raycasting
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(Camera.main.transform.position, ray.direction * 100.0f, Color.red, 1.0f);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100.0f, LayerMask.GetMask("Ground")))
        {
            _destPos = hit.point;
            _state = PlayerState.Moving;
            Debug.Log($"Raycast Camera @ {hit.collider.gameObject.name}");
        }
    }

    /// <summary>
    /// NOTE
    /// </summary>
    
    // GameObject(Player)
        // Transform
        // PlayerController
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
    }
}
