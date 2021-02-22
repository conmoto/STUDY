using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastingTest : MonoBehaviour
{

    /// <summary> ��ǥ��
    /// Local - World - Viewport - Screen
    /// Screen : �ȼ� ��ǥ Viewport : Screen ��ǥ�� 0 ~ 1�� ����ȭ
    /// </summary>
    
    // Collider�� ������ Object�� Raycast �� �� �ִ�.
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //LayerMask mask = LayerMask.GetMask("Player") | LayerMask.GetMask("Monster");
            LayerMask mask = (1 << 6) | (1 << 7);

            Debug.DrawRay(Camera.main.transform.position, ray.direction * 100.0f, Color.red, 1.0f);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100.0f, mask))
            {
                Debug.Log($"Raycast Camera @ {hit.collider.gameObject.name}");
            }
        }        
    }

    void GetClickedObject()
    {
        // 1. ���콺 ������ ��ǥ(2D)�� ī�޶� �����(nearClipPlane)���� 3D ��ǥ�� ��ȯ
        Vector3 mousePosNearPlane = Camera.main.ScreenToWorldPoint(new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.nearClipPlane)); // ī�޶��� �����
        // 2. from ī�޶� to ���콺 ����� ��ǥ�� ���� ���͸� ����
        Vector3 dir = mousePosNearPlane - Camera.main.transform.position;
        dir = dir.normalized;

        // 3. from ī�޶� to ���콺 ����� ��ǥ�� Raycast
        Debug.DrawRay(Camera.main.transform.position, dir * 100.0f, Color.red, 1.0f);
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, dir, out hit, 100.0f))
        {
            Debug.Log($"Raycast Camera @ {hit.collider.gameObject.name}");
        }
    }
}
