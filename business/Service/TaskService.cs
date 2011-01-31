using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Business;

namespace Epiworx.Service
{
    [Serializable]
    public class TaskService
    {
        public static Task TaskFetch(int taskId)
        {
            return Task.FetchTask(
                new TaskCriteria
                    {
                        TaskId = taskId
                    });
        }

        public static TaskInfoList TaskFetchInfoList()
        {
            return TaskService.TaskFetchInfoList(
                new TaskCriteria());
        }

        public static TaskInfoList TaskFetchInfoList(TaskCriteria criteria)
        {
            return TaskInfoList.FetchTaskInfoList(criteria);
        }

        public static Task TaskSave(Task task)
        {
            if (!task.IsValid)
            {
                return task;
            }

            Task result;

            if (task.IsNew)
            {
                result = TaskService.TaskInsert(task);
            }
            else
            {
                result = TaskService.TaskUpdate(task);
            }

            return result;
        }

        public static Task TaskInsert(Task task)
        {
            task = task.Save();

            FeedService.FeedAdd("Created", task);

            return task;
        }

        public static Task TaskUpdate(Task task)
        {
            task = task.Save();

            FeedService.FeedAdd("Updated", task);

            return task;
        }

        public static Task TaskNew()
        {
            return Task.NewTask();
        }

        public static bool TaskDelete(Task task)
        {
            Task.DeleteTask(
                new TaskCriteria
                    {
                        TaskId = task.TaskId
                    });

            FeedService.FeedAdd("Deleted", task);

            return true;
        }

        public static bool TaskDelete(int taskId)
        {
            return TaskService.TaskDelete(
                TaskService.TaskFetch(taskId));
        }
    }
}