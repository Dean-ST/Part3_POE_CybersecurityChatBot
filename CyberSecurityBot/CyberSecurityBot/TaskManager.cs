using System;
using System.Collections.Generic;
using System.Text;

namespace CyberSecurityBot
{
        public class TaskManager
        {
            private TaskStorageHelper storage =
                new TaskStorageHelper();

            public void AddTask(
                string title,
                string description,
                string reminder)
            {
                storage.AddTask(
                    title,
                    description,
                    reminder);

                ActivityLogger.Log(
                    $"Task added: {title}");
            }

            public List<CyberTask> GetAllTasks()
            {
                return storage.LoadTasks();
            }

            public void CompleteTask(int id)
            {
                storage.MarkAsComplete(id);

                ActivityLogger.Log(
                    $"Task completed: {id}");
            }

            public void DeleteTask(int id)
            {
                storage.DeleteTask(id);

                ActivityLogger.Log(
                    $"Task deleted: {id}");
            }
        }
    }
