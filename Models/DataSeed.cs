using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using UsersTasks.Models.Enums;

namespace UsersTasks.Models
{
    public static class DataSeed
    {
       public static void Seed(this ModelBuilder modelBuilder)
        {
            var user = new[] { new User { UserId = 1 , Surname = "Cruise", Name = "Tom", CreatedTime = new DateTime(2019, 1, 27, 0, 0, 0), UpdatedTime = new DateTime(2020, 1, 27, 0, 0, 0), Status = Status.Active },
                                    new User {UserId = 2, Surname = "Cooper", Name = "Alice", CreatedTime = new DateTime(2019, 1, 27, 0, 0, 0), UpdatedTime = new DateTime(2020, 1, 27, 0, 0, 0), Status = Status.Active },
                                        new User {UserId = 3, Surname = "Woods", Name = "James", CreatedTime = new DateTime(2019, 1, 27, 0, 0, 0), UpdatedTime = new DateTime(2020, 1, 27, 0, 0, 0), Status = Status.Active },
                                            new User {UserId = 4, Surname = "Clarke", Name = "Isaac", CreatedTime = new DateTime(2019, 1, 27, 0, 0, 0), UpdatedTime = new DateTime(2020, 1, 27, 0, 0, 0), Status = Status.Active },
                                                new User {UserId = 5, Surname = "Deen", Name = "James", CreatedTime = new DateTime(2019, 1, 27, 0, 0, 0), UpdatedTime = new DateTime(2020, 1, 27, 0, 0, 0), Status = Status.Active } };

            var objective = new[]
                {
                    new Objective { ObjectiveId = 1, Name = "Task1",  Description = "This is Task1", CreatedTime = new DateTime(2019, 1, 27, 0, 0, 0), UpdatedTime = new DateTime(2020, 1, 27, 0, 0, 0), ExecutorId = user[1].UserId,   DirectorId = user[2].UserId,   StatusObjective = StatusTask.InProcess },
                    new Objective { ObjectiveId = 2, Name = "Task2",  Description = "This is Task2", CreatedTime = new DateTime(2019, 1, 27, 0, 0, 0), UpdatedTime = new DateTime(2020, 2, 24, 0, 0, 0),  ExecutorId = user[1].UserId,  DirectorId = user[2].UserId,   StatusObjective = StatusTask.NotStarted },
                    new Objective { ObjectiveId = 3, Name = "Task3",  Description = "This is Task3", CreatedTime = new DateTime(2019, 1, 27, 0, 0, 0), UpdatedTime = new DateTime(2020, 3, 27, 0, 0, 0),  ExecutorId = user[1].UserId,  DirectorId = user[2].UserId,   StatusObjective = StatusTask.InProcess },
                    new Objective { ObjectiveId = 4, Name = "Task4",  Description = "This is Task4", CreatedTime = new DateTime(2019, 1, 27, 0, 0, 0), UpdatedTime = new DateTime(2020, 2, 24, 0, 0, 0),  ExecutorId = user[1].UserId,  DirectorId = user[2].UserId,   StatusObjective = StatusTask.NotStarted },
                    new Objective { ObjectiveId = 5, Name = "Task5",  Description = "This is Task5", CreatedTime = new DateTime(2019, 1, 27, 0, 0, 0), UpdatedTime = new DateTime(2020, 3, 27, 0, 0, 0),  ExecutorId = user[1].UserId,  DirectorId = user[2].UserId,   StatusObjective = StatusTask.InProcess },
                    new Objective { ObjectiveId = 6, Name = "Task6",  Description = "This is Task6", CreatedTime = new DateTime(2019, 1, 27, 0, 0, 0), UpdatedTime = new DateTime(2021, 7, 27, 0, 0, 0),  ExecutorId = user[1].UserId,  DirectorId = user[2].UserId,   StatusObjective = StatusTask.InProcess },
                    new Objective { ObjectiveId = 7, Name = "Task7",  Description = "This is Task7", CreatedTime = new DateTime(2019, 1, 27, 0, 0, 0), UpdatedTime = new DateTime(2021, 8, 27, 0, 0, 0),  ExecutorId = user[3].UserId,  DirectorId = user[4].UserId,   StatusObjective = StatusTask.NotStarted },
                    new Objective { ObjectiveId = 8, Name = "Task8",  Description = "This is Task8", CreatedTime = new DateTime(2019, 1, 27, 0, 0, 0), UpdatedTime = new DateTime(2020, 9, 27, 0, 0, 0),  ExecutorId = user[3].UserId,  DirectorId = user[4].UserId,   StatusObjective = StatusTask.NotStarted },
                    new Objective { ObjectiveId = 9, Name = "Task9",  Description = "This is Task9", CreatedTime = new DateTime(2019, 1, 27, 0, 0, 0), UpdatedTime = new DateTime(2021, 12, 27, 0, 0, 0), ExecutorId = user[3].UserId,  DirectorId = user[4].UserId,   StatusObjective = StatusTask.NotStarted },
                    new Objective {ObjectiveId = 10, Name = "Task10", Description = "This is Task10", CreatedTime = new DateTime(2019, 1, 27, 0, 0, 0), UpdatedTime = new DateTime(2021, 5, 27, 0, 0, 0), ExecutorId = user[3].UserId,  DirectorId = user[4].UserId,   StatusObjective = StatusTask.InProcess },
                    new Objective {ObjectiveId = 11, Name = "Task11", Description = "This is Task11", CreatedTime = new DateTime(2019, 1, 27, 0, 0, 0), UpdatedTime = new DateTime(2022, 4, 27, 0, 0, 0), ExecutorId = user[3].UserId,  DirectorId = user[4].UserId,   StatusObjective = StatusTask.InProcess },
                    new Objective {ObjectiveId = 12, Name = "Task12", Description = "This is Task12", CreatedTime = new DateTime(2019, 1, 27, 0, 0, 0), UpdatedTime = new DateTime(2020, 2, 27, 0, 0, 0), ExecutorId = user[3].UserId,  DirectorId = user[4].UserId,   StatusObjective = StatusTask.NotStarted },
                    new Objective {ObjectiveId = 13, Name = "Task13", Description = "This is Task13", CreatedTime = new DateTime(2019, 1, 27, 0, 0, 0), UpdatedTime = new DateTime(2022, 2, 27, 0, 0, 0), ExecutorId = user[0].UserId,  DirectorId = user[1].UserId,   StatusObjective = StatusTask.NotStarted },
                    new Objective {ObjectiveId = 14, Name = "Task14", Description = "This is Task14", CreatedTime = new DateTime(2019, 1, 27, 0, 0, 0), UpdatedTime = new DateTime(2021, 3, 27, 0, 0, 0), ExecutorId = user[0].UserId,  DirectorId = user[1].UserId,   StatusObjective = StatusTask.InProcess },
                    new Objective {ObjectiveId = 15, Name = "Task15", Description = "This is Task15", CreatedTime = new DateTime(2019, 1, 27, 0, 0, 0), UpdatedTime = new DateTime(2021, 7, 27, 0, 0, 0), ExecutorId = user[0].UserId,  DirectorId = user[1].UserId,   StatusObjective = StatusTask.NotStarted },
                    new Objective {ObjectiveId = 16, Name = "Task16", Description = "This is Task16", CreatedTime = new DateTime(2019, 1, 27, 0, 0, 0), UpdatedTime = new DateTime(2020, 7, 27, 0, 0, 0), ExecutorId = user[0].UserId,  DirectorId = user[1].UserId,   StatusObjective = StatusTask.InProcess },
                    new Objective {ObjectiveId = 17, Name = "Task17", Description = "This is Task17", CreatedTime = new DateTime(2019, 1, 27, 0, 0, 0), UpdatedTime = new DateTime(2022, 7, 27, 0, 0, 0), ExecutorId = user[0].UserId,  DirectorId = user[1].UserId,   StatusObjective = StatusTask.NotStarted },
                    new Objective {ObjectiveId = 18, Name = "Task18", Description = "This is Task18", CreatedTime = new DateTime(2019, 1, 27, 0, 0, 0), UpdatedTime = new DateTime(2022, 7, 27, 0, 0, 0), ExecutorId = user[0].UserId,  DirectorId = user[1].UserId,   StatusObjective = StatusTask.InProcess },
                    new Objective {ObjectiveId = 19, Name = "Task19", Description = "This is Task19", CreatedTime = new DateTime(2019, 1, 27, 0, 0, 0), UpdatedTime = new DateTime(2022, 7, 27, 0, 0, 0), ExecutorId = user[0].UserId,  DirectorId = user[1].UserId,   StatusObjective = StatusTask.NotStarted },
                    new Objective {ObjectiveId = 20, Name = "Task20", Description = "This is Task20", CreatedTime = new DateTime(2019, 1, 27, 0, 0, 0), UpdatedTime = new DateTime(2021, 7, 27, 0, 0, 0), ExecutorId = user[2].UserId,  DirectorId = user[0].UserId,   StatusObjective = StatusTask.NotStarted },
                    new Objective {ObjectiveId = 21, Name = "Task21", Description = "This is Task21", CreatedTime = new DateTime(2019, 1, 27, 0, 0, 0), UpdatedTime = new DateTime(2021, 7, 27, 0, 0, 0), ExecutorId = user[2].UserId,  DirectorId = user[0].UserId,   StatusObjective = StatusTask.InProcess },
                    new Objective {ObjectiveId = 22, Name = "Task22", Description = "This is Task22", CreatedTime = new DateTime(2019, 1, 27, 0, 0, 0), UpdatedTime = new DateTime(2021, 7, 27, 0, 0, 0), ExecutorId = user[2].UserId,  DirectorId = user[0].UserId,   StatusObjective = StatusTask.NotStarted },
                    new Objective {ObjectiveId = 23, Name = "Task23", Description = "This is Task23", CreatedTime = new DateTime(2019, 1, 27, 0, 0, 0), UpdatedTime = new DateTime(2021, 7, 27, 0, 0, 0), ExecutorId = user[2].UserId,  DirectorId = user[0].UserId,   StatusObjective = StatusTask.InProcess },
                    new Objective {ObjectiveId = 24, Name = "Task24", Description = "This is Task24", CreatedTime = new DateTime(2019, 1, 27, 0, 0, 0), UpdatedTime = new DateTime(2021, 7, 27, 0, 0, 0), ExecutorId = user[2].UserId,  DirectorId = user[0].UserId,   StatusObjective = StatusTask.InProcess },
                };
            modelBuilder.Entity<User>().HasData(user);
            modelBuilder.Entity<Objective>().HasData(objective);


        }

    }
}
