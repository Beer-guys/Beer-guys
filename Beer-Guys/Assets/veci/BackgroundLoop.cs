using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{

    public Transform target;
    public float smoothSpeed = 5f;
    public float LoopSpeed;
    public Renderer BackgroundRenderer;

    void Update()
    {
        BackgroundRenderer.material.mainTextureOffset += new Vector2(LoopSpeed * Time.deltaTime, 0f);

    }
    private void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
            transform.position = smoothedPosition;
        }
    }

}
