using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTest : MonoBehaviour
{
    /// <summary>
    /// 1. ���� �ϳ��� Rigidbody�� �־�� �Ѵ� (IsKinematic : off)
    /// 2. �� �� Collider�� �־�� �Ѵ�(IsTrigger : off)
    /// </summary>
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Collision @ {collision.gameObject.name}");
    }

    /// <summary>
    /// 1. �� �� Collider�� �־�� �Ѵ�
    /// 2. �� �� �ϳ��� IsTrigger : On
    /// 3. �� �� �ϳ��� RigidBody�� �־�� �Ѵ�.
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Trigger @ {other.gameObject.name}");
    }
}
