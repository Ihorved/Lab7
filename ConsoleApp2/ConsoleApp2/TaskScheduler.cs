using System;
using System.Collections.Generic;

class TaskScheduler<TTask, TPriority>
{
    private SortedDictionary<TPriority, Queue<TTask>> tasksByPriority = new SortedDictionary<TPriority, Queue<TTask>>();
    private Func<TTask, TPriority> taskPriorityFunc;

    public delegate void TaskExecution(TTask task);

    public TaskScheduler(Func<TTask, TPriority> priorityFunction)
    {
        taskPriorityFunc = priorityFunction;
    }

    public void Enqueue(TTask task)
    {
        TPriority priority = taskPriorityFunc(task);
        if (!tasksByPriority.ContainsKey(priority))
        {
            tasksByPriority[priority] = new Queue<TTask>();
        }
        tasksByPriority[priority].Enqueue(task);
    }

    public void ExecuteNext(TaskExecution taskExecution)
    {
        if (tasksByPriority.Count > 0)
        {
            var highestPriorityTasks = tasksByPriority[tasksByPriority.Keys.GetEnumerator().Current];
            if (highestPriorityTasks.Count > 0)
            {
                TTask nextTask = highestPriorityTasks.Dequeue();
                taskExecution(nextTask);
            }
            else
            {
                Console.WriteLine("No tasks to execute.");
            }
        }
        else
        {
            Console.WriteLine("No tasks to execute.");
        }
    }
}

class Program
{
    static void Main()
    {
        TaskScheduler<string, int> scheduler = new TaskScheduler<string, int>((task) =>
        {
            return task.Length; 
        });

        scheduler.Enqueue("Task with length 10");
        scheduler.Enqueue("Short task");
        scheduler.Enqueue("Task with length 5");

        TaskScheduler<string, int>.TaskExecution taskExecution = (task) =>
        {
            Console.WriteLine($"Executing task: {task}");
        };

        scheduler.ExecuteNext(taskExecution); 
        scheduler.ExecuteNext(taskExecution);
        scheduler.ExecuteNext(taskExecution);
        scheduler.ExecuteNext(taskExecution); 
    }
}
