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
        // Assume there is a PathfindingNode script attached to the GameObject
        PathfindingNode[] allNodes = GameObject.FindObjectsOfType<PathfindingNode>();
        PathfindingNode startNode = FindNearestNode(transform.position, allNodes);
        PathfindingNode targetNode = FindNearestNode(target, allNodes);

        if (startNode != null && targetNode != null)
        {
            List<PathfindingNode> path = startNode.DepthFirstSearch(startNode, targetNode);

            if (path != null)
            {
                foreach (PathfindingNode node in path)
                {
                    targetPosition = new Vector3(node.transform.position.x, node.transform.position.y, 0.0f);

                    while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
                    {
                        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
                        yield return null;
                    }
                }
            }
        }
    }

    private PathfindingNode FindNearestNode(Vector2 position, PathfindingNode[] nodes)
    {
        float minDistance = float.MaxValue;
        PathfindingNode nearestNode = null;

        foreach (PathfindingNode node in nodes)
        {
            float distance = Vector2.Distance(position, new Vector2(node.transform.position.x, node.transform.position.y));

            if (distance < minDistance)
            {
                minDistance = distance;
                nearestNode = node;
            }
        }

        return nearestNode;
    }
}