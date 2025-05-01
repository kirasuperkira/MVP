using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public interface IView
    {
        /// <summary>
        /// Событие - Удаление студента
        /// </summary>
        event Action<int> RemoveDataEvent;

        /// <summary>
        /// Событие - Список всех студентов
        /// </summary>
        event Action GetAllStudentsEvent;

        /// <summary>
        /// Событие - Отображение гистограммы (распределение по специальностям)
        /// </summary>
        event Action ShowGistogramEvent;

        /// <summary>
        /// Событие - Добавление студента
        /// </summary>
        event Action<EventArgs> CreateDataEvent;

        /// <summary>
        /// Событие - Изменение студента
        /// </summary>
        event Action<EventArgs> UpdateDataEvent;

        /// <summary>
        /// Перерисовка формы на слое View 
        /// </summary>
        /// <param name="data">Отображение списка данных</param>
        ///// 
        void RedrawForm(IEnumerable<EventArgs> data);

        /// <summary>
        /// Отрисовка гистограммы
        /// </summary>
        void HistogrammForm(Dictionary<string, int> data);
    }
}
