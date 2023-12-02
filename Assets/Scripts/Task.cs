using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task
{
    protected Vector2 mousePosition;

    public Task(Vector2 aMousePosition)
    {
        mousePosition = aMousePosition;
    }

    public virtual IEnumerator RunTask()
    {
        yield return null;
    }

}

public class MoveTask : Task
{

    public MoveTask(Vector2 aMousePosition): base(aMousePosition)
    {
        //
    }

    public override IEnumerator RunTask()
    {
        // start move coroutine, next line will wait until it finishes
        if(TaskManager.me.playerPathFinder != null)
        {
            yield return TaskManager.me.StartCoroutine(TaskManager.me.playerPathFinder.MoveToTarget(mousePosition));
            //Debug.Log("Finished moving to  "+mousePosition);
        }
        else yield return null;
    }
    
}

public class ClickablePressedTask : Task
{

    ClickableObject clickableObject;

    public ClickablePressedTask(Vector2 aMousePosition, ClickableObject aClickableObject): base(aMousePosition)
    {
        clickableObject = aClickableObject;
    }

    public override IEnumerator RunTask()
    {
        // start clickable object pressed coroutine, action determined in ClickableObject class
        clickableObject.OnClicked();
        //Debug.Log("Started clickable object pressed task");
        yield break;
    }
    
}