using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathfindingNode : MonoBehaviour
{
    public List<PathfindingNode> connectedNodes = new List<PathfindingNode>();

    public List<PathfindingNode> DepthFirstSearch(PathfindingNode startNode, PathfindingNode targetNode)
    {
        HashSet<PathfindingNode> visitedNodes = new HashSet<PathfindingNode>();
        Stack<PathfindingNode> stack = new Stack<PathfindingNode>();
        Dictionary<PathfindingNode, PathfindingNode > parentNodes = new Dictionary<PathfindingNode, PathfindingNode>();

        stack.Push(startNode);
        visitedNodes.Add(startNode);

        while (stack.Count > 0)
        {
            PathfindingNode currentNode = stack.Pop();

            if (currentNode == targetNode)
            {
                return ReconstructPath(parentNodes, targetNode);
            }

            foreach (PathfindingNode neighbor in currentNode.connectedNodes)
            {
                if (!visitedNodes.Contains(neighbor))
                {
                    stack.Push(neighbor);
                    visitedNodes.Add(neighbor);
                    parentNodes[neighbor] = currentNode;
                }
            }
        }

        return null;
    }

    private List<PathfindingNode> ReconstructPath(Dictionary<PathfindingNode, PathfindingNode> parentNodes, PathfindingNode targetNode)
    {
        List<PathfindingNode> path = new List<PathfindingNode>();
        PathfindingNode currentNode = targetNode;

        while (parentNodes.ContainsKey(currentNode))
        {
            path.Insert(0, currentNode);
            currentNode = parentNodes[currentNode];
        }

        path.Insert(0, currentNode);

        return path;
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(transform.position, 0.2f);

        foreach (PathfindingNode neighbor in connectedNodes) {
            if(neighbor != null)
            {
                Gizmos.DrawLine(transform.position, neighbor.transform.position);
            }
        }
    }
#endif

}
