# .NET labs Skillbox
Exercise 1.1 - 1.3
```
// Создание базы данных из 20 сотрудников (ЗАДАНИЕ 1 - изменено с 30 на 20)
            Repository repository = new Repository(20);

// Задание 2 отдел на 40 человек
            Repository repository2 = new Repository(40);
            repository2.Print("Отдел сотрудников 2");
            repository2.DeleteFirstWorkers(10); // Функция для задания 2 реализована в Repository.cs
            repository2.Print("Отдел сотрудников 2 после увольнения 10 человек");
            
/// <summary>
        /// Метод, увольняющий N первых работников в списке
        /// </summary>
        /// <param name="Number">Сколько сотрудников уволить</param>
        public void DeleteFirstWorkers(int Number)
        {
            if (this.Workers.Count() > Number)
            {
                this.Workers.RemoveRange(0, Number);
            }
            else
            {
                throw new Exception("В отделе нет столько сотрудников");
            }
        }
            
// Задание 3 отдел на 50 человек
            Repository repository3 = new Repository(50);
            repository3.Print("Отдел сотрудников 3");
            repository3.DeleteWorkerBySalary(30000);
            repository3.Print("Отдел сотрудников 3 после раскулачивания");
```
