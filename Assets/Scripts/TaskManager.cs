using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{


    public static TaskManager me;
    public PlayerPathFinder playerPathFinder;


    private Queue<Task> taskQueue = new Queue<Task>();
    private bool isRunningTasks = false;



    void Awake()
    {
        if(me == null) 
        {
            me = FindObjectOfType<TaskManager>();
        }

        if(playerPathFinder == null)
        {
            playerPathFinder = FindObjectOfType<PlayerPathFinder>();
        }
    }



    public static void AddTask(Task task)
    {
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
            Task nextTask = taskQueue.Dequeue();

            StartCoroutine(ExecuteTask(nextTask));
        }
        else
        {
            isRunningTasks = false;
        }
    }

    private IEnumerator ExecuteTask(Task task)
    {

        yield return StartCoroutine(task.RunTask());

        // Start the next task
        StartNextTask();
    }


}


