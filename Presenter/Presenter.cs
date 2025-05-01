using Model;
using System;
using System.Collections.Generic;
using Shared;
using BusinessLogic;
using ConsoleApp2;

namespace Presenter
{
    public class Presenter
    {
        private IView _1view;
        private ILogic<Student> _logic;
        Logic Logic { get; set; }

        public Presenter(IView view1, ILogic<Student> logic)
        {
            this._1view = view1;
            this._logic = logic;
            logic.DataChanged += toModelDataChanged;
            view1.CreateDataEvent += toAddData;
            view1.RemoveDataEvent += logic.RemoveStudent;
            view1.UpdateDataEvent += toUpdateStudent;
            view1.GetAllStudentsEvent += toGetAllStudents;
            view1.ShowGistogramEvent += toShowGistogram;
        }
        /// <summary>
        /// Основной метод отрисовки после каждого изменения
        /// </summary>
        /// <param name="students">Список данныъ для отображения</param>
        private void toModelDataChanged(IEnumerable<Student> students)
        {
            List<StudentModel> args = new List<StudentModel>();
            foreach (var stud in students)
            {
                args.Add(new StudentModel()
                {
                    Id = stud.Id,
                    Name = stud.Name,
                    Group = stud.Group,
                    Speciality = stud.Speciality
                });

            }
            _1view.RedrawForm(args);
        }

        /// <summary>
        /// Изменение записи студента
        /// </summary>
        /// <param name="data">Данные, которые нужно изменить</param>
        private void toAddData(EventArgs data)
        {
            StudentModel args = data as StudentModel;
            _logic.CreateStudent(args.Name, args.Group, args.Speciality);
        }

        /// <summary>
        /// Изменение студента
        /// </summary>
        private void toUpdateStudent(EventArgs data)
        {
            StudentModel args = data as StudentModel;
            _logic.UpdateStudent(args.Name, args.Speciality, args.Group, args.Id);
        }

        /// <summary>
        /// Перерисовка списка данных на слое View
        /// </summary>
        private void toGetAllStudents()
        {
            List<StudentModel> args = new List<StudentModel>();
            var students = _logic.GetAllStudents();
            foreach (var stud in students)
            {
                    var second_line = stud;
                    args.Add(new StudentModel()
                    {
                        Id = Convert.ToInt32(second_line[0]),
                        Name = second_line[1],
                        Group = second_line[3],
                        Speciality = second_line[2]
                    });
            }
            _1view.RedrawForm(args);
        }

        /// <summary>
        /// Отрисовка гистограммы на слое View
        /// </summary>
        private void toShowGistogram()
        {
            _1view.HistogrammForm(_logic.ShowGistogram());
        }
    }
}
