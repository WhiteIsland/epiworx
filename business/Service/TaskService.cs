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

        public static TaskLabelByCountInfoList TaskLabelByCountFetchInfoList()
        {
            return TaskLabelByCountInfoList.FetchTaskLabelByCountInfoList();
        }

        public static TaskInfoList TaskFetchInfoList()
        {
            return TaskService.TaskFetchInfoList(
                new TaskCriteria());
        }

        public static TaskInfoList TaskFetchInfoList(IProject project)
        {
            return TaskService.TaskFetchInfoList(
                new TaskCriteria
                    {
                        ProjectId = new[] { project.ProjectId }
                    });
        }

        public static TaskInfoList TaskFetchInfoList(TaskCriteria criteria)
        {
            return TaskInfoList.FetchTaskInfoList(criteria);
        }

        public static Task TaskArchive(int taskId)
        {
            var task = TaskService.TaskFetch(taskId);

            if (task.IsArchived)
            {
                return task;
            }

            task.IsArchived = true;

            task = TaskService.TaskSave(task);

            return task;
        }

        public static Task[] TaskArchive(int[] taskIds)
        {
            return taskIds
                .Select(TaskService.TaskArchive)
                .ToArray();
        }

        public static Task TaskUnarchive(int taskId)
        {
            var task = TaskService.TaskFetch(taskId);

            if (!task.IsArchived)
            {
                return task;
            }

            task.IsArchived = false;

            task = TaskService.TaskSave(task);

            return task;
        }

        public static Task[] TaskUnarchive(int[] taskIds)
        {
            return taskIds
               .Select(TaskService.TaskUnarchive)
               .ToArray();
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

        public static Task TaskUpdateAssignedTo(int taskId, int assignedTo)
        {
            var task = TaskService.TaskFetch(taskId);

            if (task.AssignedTo == assignedTo)
            {
                return task;
            }

            task.AssignedTo = assignedTo;

            task = TaskService.TaskSave(task);

            return task;
        }

        public static Task[] TaskUpdateAssignedTo(int[] taskIds, int assignedTo)
        {
            return taskIds
                .Select(taskId => TaskService.TaskUpdateAssignedTo(taskId, assignedTo))
                .ToArray();
        }

        public static Task TaskUpdateStatus(int taskId, int statusId)
        {
            var task = TaskService.TaskFetch(taskId);

            if (task.StatusId == statusId)
            {
                return task;
            }

            task.StatusId = statusId;

            task = TaskService.TaskSave(task);

            return task;
        }

        public static Task[] TaskUpdateStatus(int[] taskIds, int statusId)
        {
            return taskIds
                .Select(taskId => TaskService.TaskUpdateStatus(taskId, statusId))
                .ToArray();
        }

        public static Task TaskNew()
        {
            return Task.NewTask();
        }

        public static Task TaskNew(Hour hour)
        {
            var result = Task.NewTask();

            result.ProjectId = hour.ProjectId;
            result.EstimatedDuration = hour.Duration;
            result.Description = hour.Notes;
            result.AssignedTo = hour.UserId;

            return result;
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