using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{


    public static TaskManager me;
    public PlayerPathFinder playerPathFinder;

    public enum TaskType {
    Move,
    StartFood,
    CollectFood,
    DeliverFood,
    CollectMoney
}

    private Queue<TaskType> taskQueue = new Queue<TaskType>();
    private bool isRunningTasks = false;
    private Vector2 mousePosition;


    // Start is called before the first frame update
    void Awake()
    {
        if(me == null) 
        {
            me = FindObjectOfType<TaskManager>();
        }
    }

    public static TaskManager Instance
    {
        get
        {
            if (me == null)
            {
                me = FindObjectOfType<TaskManager>();
            }
            return me;
        }
    }


    public static void AddTask(TaskType task, Vector2 aMousePosition)
    {
        me.mousePosition = aMousePosition;
        //currently only one mouse position is cached at once (meaning only one position is stored after the current task's position)
        //planning on maybe using a list or queue parallel to Task queue or maybe making Task a serializable class?
        me.taskQueue.Enqueue(task);

        if (!me.isRunningTasks)
        {
            me.StartNextTask();
        }
    }

    private void StartNextTask()
    {
        if (taskQueue.Count > 0)
        {
            isRunningTasks = true;
            TaskType nextTask = taskQueue.Dequeue();

            StartCoroutine(ExecuteTask(nextTask, mousePosition));
        }
        else
        {
            isRunningTasks = false;
        }
    }

    private IEnumerator ExecuteTask(TaskType task, Vector2 aMousePosition)
    {
        Debug.Log("Starting task: " + task);

        switch (task)
        {
            case TaskType.Move:
                // start move coroutine, next line will wait until it finishes
                if(playerPathFinder != null)
                {
                    yield return StartCoroutine(playerPathFinder.MoveToTarget(aMousePosition));
                }
                else yield return null;
                break;

            case TaskType.StartFood:
                // start food making coroutine, next line will wait until it finishes
                yield return null;
                break;

            case TaskType.CollectFood:
                // pick up food item
                yield return null;
                break;

            case TaskType.DeliverFood:
                // deliver food to customer
                yield return null;
                break;

            case TaskType.CollectMoney:
                // collect money
                yield return null;
                break;
        }

        Debug.Log("Finished task: " + task);

        // Start the next task
        StartNextTask();
    }


}
