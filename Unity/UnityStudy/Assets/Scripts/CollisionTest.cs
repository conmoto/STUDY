using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTest : MonoBehaviour
{
    /// <summary>
    /// 1. 둘중 하나는 Rigidbody가 있어야 한다 (IsKinematic : off)
    /// 2. 둘 다 Collider가 있어야 한다(IsTrigger : off)
    /// </summary>
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Collision @ {collision.gameObject.name}");
    }

    /// <summary>
    /// 1. 둘 다 Collider가 있어야 한다
    /// 2. 둘 중 하나는 IsTrigger : On
    /// 3. 둘 중 하나는 RigidBody가 있어야 한다.
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Trigger @ {other.gameObject.name}");
    }
}
