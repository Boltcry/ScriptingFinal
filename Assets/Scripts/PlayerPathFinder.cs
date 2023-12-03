using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPathFinder : MonoBehaviour
{

    public float speed = 10f;
    private Vector3 targetPosition;

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

        targetPosition = new Vector3(target.x, target.y, 0.0f);

        while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            yield return null;
        }

        transform.position = targetPosition;
    }
}
