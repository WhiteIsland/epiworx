using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Business;
using Epiworx.Security;
using Epiworx.Service;

namespace Epiworx.Tests.Helpers
{
    public class BusinessHelper
    {
        public static Category CreateCategory()
        {
            var category = CategoryService.CategoryNew();

            category.Name = DataHelper.RandomString(20);

            category = CategoryService.CategorySave(category);

            return category;
        }

        public static Category CreateCategoryAndLogon(string userName, string userPassword)
        {
            var name = DataHelper.RandomString(20);
            var password = DataHelper.RandomString(20);

            BusinessHelper.CreateUserWithFullControl(name, password);

            BusinessPrincipal.Login(name, password);

            var category = CategoryService.CategoryNew();

            category.Name = DataHelper.RandomString(20);

            category = CategoryService.CategorySave(category);

            BusinessPrincipal.Logout();

            BusinessPrincipal.Login(userName, userPassword);

            return category;
        }

        public static Hour CreateHour()
        {
            var hour = HourService.HourNew();

            var task = BusinessHelper.CreateTask();

            hour.TaskId = task.TaskId;
            hour.Date = DateTime.Now.Date;
            hour.Duration = 8;
            hour.Notes = DataHelper.RandomString(100);

            hour = HourService.HourSave(hour);

            return hour;
        }

        public static Hour CreateHourAndLogon(string userName, string userPassword)
        {
            var name = DataHelper.RandomString(20);
            var password = DataHelper.RandomString(20);

            BusinessHelper.CreateUserWithFullControl(name, password);

            BusinessPrincipal.Login(name, password);

            var hour = HourService.HourNew();

            var task = BusinessHelper.CreateTask();

            hour.TaskId = task.TaskId;
            hour.Date = DateTime.Now.Date;
            hour.Duration = 8;
            hour.Notes = DataHelper.RandomString(100);

            hour = HourService.HourSave(hour);

            BusinessPrincipal.Logout();

            BusinessPrincipal.Login(userName, userPassword);

            return hour;
        }

        public static Hour CreateHourForUserAndLogon(string userName, string userPassword, int userId)
        {
            var name = DataHelper.RandomString(20);
            var password = DataHelper.RandomString(20);

            BusinessHelper.CreateUserWithFullControl(name, password);

            BusinessPrincipal.Login(name, password);

            var hour = HourService.HourNew();

            var task = BusinessHelper.CreateTask();

            hour.UserId = userId;
            hour.TaskId = task.TaskId;
            hour.Date = DateTime.Now.Date;
            hour.Duration = 8;
            hour.Notes = DataHelper.RandomString(100);

            hour = HourService.HourSave(hour);

            BusinessPrincipal.Logout();

            BusinessPrincipal.Login(userName, userPassword);

            return hour;
        }

        public static Hour CreateHourThatIsArchivedAndLogon(string userName, string userPassword)
        {
            var name = DataHelper.RandomString(20);
            var password = DataHelper.RandomString(20);

            BusinessHelper.CreateUserWithFullControl(name, password);

            BusinessPrincipal.Login(name, password);

            var hour = HourService.HourNew();

            var task = BusinessHelper.CreateTask();

            hour.TaskId = task.TaskId;
            hour.Date = DateTime.Now.Date;
            hour.Duration = 8;
            hour.Notes = DataHelper.RandomString(100);
            hour.IsArchived = true;

            hour = HourService.HourSave(hour);

            BusinessPrincipal.Logout();

            BusinessPrincipal.Login(userName, userPassword);

            return hour;
        }

        public static Project CreateProject()
        {
            var project = ProjectService.ProjectNew();

            project.Name = DataHelper.RandomString(20);

            project = ProjectService.ProjectSave(project);

            return project;
        }

        public static Project CreateProjectAndLogon(string userName, string userPassword)
        {
            var name = DataHelper.RandomString(20);
            var password = DataHelper.RandomString(20);

            BusinessHelper.CreateUserWithFullControl(name, password);

            BusinessPrincipal.Login(name, password);

            var project = ProjectService.ProjectNew();

            project.Name = DataHelper.RandomString(20);

            project = ProjectService.ProjectSave(project);

            BusinessPrincipal.Logout();

            BusinessPrincipal.Login(userName, userPassword);

            return project;
        }

        public static Status CreateStatus()
        {
            var status = StatusService.StatusNew();

            status.Name = DataHelper.RandomString(20);

            status = StatusService.StatusSave(status);

            return status;
        }

        public static Status CreateStatusAndLogon(string userName, string userPassword)
        {
            var name = DataHelper.RandomString(20);
            var password = DataHelper.RandomString(20);

            BusinessHelper.CreateUserWithFullControl(name, password);

            BusinessPrincipal.Login(name, password);

            var status = StatusService.StatusNew();

            status.Name = DataHelper.RandomString(20);

            status = StatusService.StatusSave(status);

            BusinessPrincipal.Logout();

            BusinessPrincipal.Login(userName, userPassword);

            return status;
        }

        public static Task CreateTask()
        {
            var task = TaskService.TaskNew();

            var status = BusinessHelper.CreateStatus();
            var category = BusinessHelper.CreateCategory();
            var project = BusinessHelper.CreateProject();

            task.Description = DataHelper.RandomString(1000);
            task.StatusId = status.StatusId;
            task.CategoryId = category.CategoryId;
            task.ProjectId = project.ProjectId;

            task = TaskService.TaskSave(task);

            return task;
        }

        public static Task CreateTaskAndLogon(string userName, string userPassword)
        {
            var name = DataHelper.RandomString(20);
            var password = DataHelper.RandomString(20);

            BusinessHelper.CreateUserWithFullControl(name, password);

            BusinessPrincipal.Login(name, password);

            var task = TaskService.TaskNew();

            var status = BusinessHelper.CreateStatus();
            var category = BusinessHelper.CreateCategory();
            var project = BusinessHelper.CreateProject();

            task.Description = DataHelper.RandomString(1000);
            task.StatusId = status.StatusId;
            task.CategoryId = category.CategoryId;
            task.ProjectId = project.ProjectId;

            task = TaskService.TaskSave(task);

            BusinessPrincipal.Logout();

            BusinessPrincipal.Login(userName, userPassword);

            return task;
        }

        public static Task CreateTaskThatIsArchivedAndLogon(string userName, string userPassword)
        {
            var name = DataHelper.RandomString(20);
            var password = DataHelper.RandomString(20);

            BusinessHelper.CreateUserWithFullControl(name, password);

            BusinessPrincipal.Login(name, password);

            var task = TaskService.TaskNew();

            var status = BusinessHelper.CreateStatus();
            var category = BusinessHelper.CreateCategory();
            var project = BusinessHelper.CreateProject();

            task.Description = DataHelper.RandomString(1000);
            task.StatusId = status.StatusId;
            task.CategoryId = category.CategoryId;
            task.ProjectId = project.ProjectId;
            task.IsArchived = true;

            task = TaskService.TaskSave(task);

            BusinessPrincipal.Logout();

            BusinessPrincipal.Login(userName, userPassword);

            return task;
        }

        public static User CreateUserWithReview(string userName, string password)
        {
            BusinessPrincipal.Login();

            var user = UserService.UserNew();

            user.Name = userName;
            user.FirstName = DataHelper.RandomString(20);
            user.LastName = DataHelper.RandomString(20);
            user.Email = DataHelper.RandomEmail();
            user.Role = Role.Review;

            user.SetPassword(password);

            user = UserService.UserSave(user, null);

            BusinessPrincipal.Logout();

            return user;
        }

        public static User CreateUserWithContribute(string userName, string password)
        {
            BusinessPrincipal.Login();

            var user = UserService.UserNew();

            user.Name = userName;
            user.FirstName = DataHelper.RandomString(20);
            user.LastName = DataHelper.RandomString(20);
            user.Email = DataHelper.RandomEmail();
            user.Role = Role.Contribute;

            user.SetPassword(password);

            user = UserService.UserSave(user, null);

            BusinessPrincipal.Logout();

            return user;
        }

        public static User CreateUserWithFullControl(string userName, string password)
        {
            BusinessPrincipal.Login();

            var user = UserService.UserNew();

            user.Name = userName;
            user.FirstName = DataHelper.RandomString(20);
            user.LastName = DataHelper.RandomString(20);
            user.Email = DataHelper.RandomEmail();
            user.Role = Role.FullControl;

            user.SetPassword(password);

            user = UserService.UserSave(user, null);

            BusinessPrincipal.Logout();

            return user;
        }
    }
}
