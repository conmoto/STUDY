using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastingTest : MonoBehaviour
{

    /// <summary> 좌표계
    /// Local - World - Viewport - Screen
    /// Screen : 픽셀 좌표 Viewport : Screen 좌표를 0 ~ 1로 정규화
    /// </summary>
    
    // Collider가 부착된 Object만 Raycast 할 수 있다.
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
        // 1. 마우스 포인터 좌표(2D)를 카메라 근평면(nearClipPlane)상의 3D 좌표로 변환
        Vector3 mousePosNearPlane = Camera.main.ScreenToWorldPoint(new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.nearClipPlane)); // 카메라의 근평면
        // 2. from 카메라 to 마우스 근평면 좌표의 방향 벡터를 구함
        Vector3 dir = mousePosNearPlane - Camera.main.transform.position;
        dir = dir.normalized;

        // 3. from 카메라 to 마우스 근평면 좌표로 Raycast
        Debug.DrawRay(Camera.main.transform.position, dir * 100.0f, Color.red, 1.0f);
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, dir, out hit, 100.0f))
        {
            Debug.Log($"Raycast Camera @ {hit.collider.gameObject.name}");
        }
    }
}
