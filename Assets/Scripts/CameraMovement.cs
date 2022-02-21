using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public float smoothing;
    public Vector2 maxPosition;
    public Vector2 minPosition;
    public BoolValue sceneChange;

    // Start is called before the first frame update
    void Start()
    {
        if (sceneChange.initialValue == false)
        {
            transform.position = GetClampedCameraPosition();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(transform.position != target.position)
        {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);

            targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);
            targetPosition.y = Mathf.Clamp (targetPosition.y, minPosition.y, maxPosition.y);

            transform.position = Vector3.Lerp(transform.position, GetClampedCameraPosition(), smoothing);


        }
    }

    private Vector3 GetClampedCameraPosition()
    {
        Vector3 targetPosition = new Vector3(
                target.position.x,
                target.position.y,
                transform.position.z
            );

        targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);
        targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);

        return targetPosition;
    }
}
