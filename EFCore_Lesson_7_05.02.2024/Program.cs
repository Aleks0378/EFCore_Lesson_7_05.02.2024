//Создать таблицы: Станция и Поезда. Используя метод FromSqlRaw и ExecuteSqlRaw,
//выполнить 8 запросов для получения данных:

//Добавить данные про станции и поезда.
//Поезда у которых длительность маршрута более 5 часов.
//Общую информация о станции и ее поездах.
//Название станций у которой в наличии более 3-ех поездов.
//Все поезда, модель которых начинается на подстроку ‘Pel’
//Все поезда, у которых возраст более 15 лет с текущей даты.
//Получить станции, у которых в наличии хотя бы один поезд с длительность маршрутка менее 5 часов.
//Вывести станции без поездов.

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Diagnostics;

namespace EFCore_Lesson_7_05._02._2024
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                //db.Database.EnsureDeleted();
                //db.Database.EnsureCreated();

                ////Добавить данные про станции и поезда.
                //var insertData = db.Database.ExecuteSqlRaw
                //    ("INSERT INTO [Stations] ([Name],[Description]) VALUES ('Station1','Sation in Forest'), ('Station2','Sation in Field'),('Station3','Sation beside River'),('Station4','Sation in City'),('Station5','Sation in Port');");
                //var insertData2 = db.Database.ExecuteSqlRaw
                //    ("INSERT INTO [Trains] ([Name],[Model],[MadeInYear],[RouteDuration],[StationId]) VALUES ('GreenLine','DT1',2001,11,1),('BlueLine','DM300',2010,2,1),('Fastic','DT15',2020,6,2),('LocalStations','DM100',2001,8,3);");

                ////Поезда у которых длительность маршрута более 5 часов.
                //var trains = db.Trains.FromSqlRaw("SELECT* FROM [Trains] WHERE [RouteDuration]<5");

                ////Общую информация о станции и ее поездах.
                //var StationInfo = db.Stations.FromSqlRaw("SELECT s.[id],s.[Name],s.[Description] FROM [Stations] s WHERE [Name] = 'Station1'").Include(e => e.Trains).ToList();

                //Название станций у которой в наличии более 3-ех поездов.
                //var StationInfo1 = db.Stations.FromSqlRaw("SELECT s.[id],s.[Name],s.[Description] FROM [Stations] AS s").Include(e => e.Trains).Where(e => e.Trains.Count() > 3).ToList();

                //Все поезда, модель которых начинается на подстроку ‘DT’
                //SqlParameter param = new SqlParameter("@model", "DT%");
                //var TrainModel = db.Trains.FromSqlRaw("SELECT* FROM [Trains] WHERE [Model] LIKE @model",param).ToList();

                //Все поезда, у которых возраст более 15 лет с текущей даты.
                //var TrainAge = db.Trains.FromSqlRaw("SELECT* FROM [Trains] WHERE (DATEPART(YEAR,GETDATE())-[MadeInYear])>15").ToList();

                //Получить станции, у которых в наличии хотя бы один поезд с длительность маршрутка менее 5 часов.
                //Не могу вытащить свойство RouteDuration из Trains
                //var StationInfo1 = db.Stations.FromSqlRaw("SELECT s.[id],s.[Name],s.[Description] FROM [Stations] AS s").Include(e => e.Trains).Where(e => e.Trains.Count() >= 1 && e.Trains.).ToList();

                //Вывести станции без поездов.
                //var StationInfo1 = db.Stations.FromSqlRaw("SELECT s.[id],s.[Name],s.[Description] FROM [Stations] AS s").Include(e => e.Trains).Where(e => e.Trains.Count() == 0 ).ToList();

            }

        }
    }

    public class ApplicationContext: DbContext
    {
        public DbSet<Station> Stations { get; set; }
        public DbSet<Train> Trains { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=TrainsTestDB;Trusted_Connection=True;TrustServerCertificate=True;");
            optionsBuilder.LogTo(e => Debug.WriteLine(e), new[] { RelationalEventId.CommandExecuted });
        }
    }
}
