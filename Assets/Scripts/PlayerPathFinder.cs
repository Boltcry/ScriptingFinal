using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPathFinder : MonoBehaviour
{

    private Vector3 targetPosition;
    private Vector3 currentVelocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator MoveToTarget(Vector2 target)
    {
        //temporary, for testing TaskManager

        float smoothTime = 0.2f; 
        targetPosition = new Vector3(target.x, target.y, 0.0f);

        while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
        {
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, smoothTime);
            yield return null; 
        }

        transform.position = targetPosition;
    }
}
