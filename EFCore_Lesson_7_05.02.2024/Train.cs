using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Добавить данные про станции и поезда.
//Поезда у которых длительность маршрута более 5 часов.
//Общую информация о станции и ее поездах.
//Название станций у которой в наличии более 3-ех поездов.
//Все поезда, модель которых начинается на подстроку ‘Pel’
//Все поезда, у которых возраст более 15 лет с текущей даты.
//Получить станции, у которых в наличии хотя бы один поезд с длительность маршрутка менее 5 часов.
//Вывести станции без поездов.

namespace EFCore_Lesson_7_05._02._2024
{
    public class Train
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public int MadeInYear { get; set; }
        public decimal RouteDuration {  get; set; } 
        public int StationId { get; set; }
        public Station? Station { get; set; }
    }
}
