using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View;
using System.Windows.Forms;
using EntityLib;
using Model;
namespace Presenter
{
   public  class StudentePresenter : Presenter<IStudenteView>
    {
        private Form form;
        protected StudentRepository repo = new StudentRepository();
        public enum State
        {
            Add,
            Edit,
            Reset,
            Delete
        }
        public State TT { get; set; }

        public StudentePresenter(IStudenteView view)
            : base(view)
        {
            form = (Form)view;
            View.AddButtonClick += View_AddButtonClick;
            View.ResetButtonClick += View_ResetButtonClick;
            View.EditButtonClick += View_EditButtonClick;
            View.DeleteButtonClick += View_DeleteButtonClick;
            View.BackButtonClick += View_BackButtonClick;
            View.SaveButtonClick += View_SaveButtonClick;
            View.ListStudent = repo.LoadListStudents();
        }

        private StudentModel ViewToModel()
        {
            StudentModel model = new StudentModel();
            model.ID = View.Id;
            model.Name = View.Name;
            model.ClassName = View.Class;
            model.Age = View.Age;
            model.Address = View.Address;
            return model;
        }

        void View_SaveButtonClick(object sender, EventArgs e)
        {
            try
            {
                StudentModel std = ViewToModel();
                if (TT == State.Add)
                {
                    repo.Insert(std);
                }
                else
                {
                    repo.Update(std);
                }
                View.ListStudent = repo.LoadListStudents();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void View_BackButtonClick(object sender, EventArgs e)
        {
            form.Close();
        }

        void View_DeleteButtonClick(object sender, EventArgs e)
        {
            try
            {
                TT = State.Delete;
                repo.Delete(View.Id);
                View.ListStudent = repo.LoadListStudents();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }      
        }

        void View_EditButtonClick(object sender, EventArgs e)
        {
            TT = State.Edit;
        }

        void View_ResetButtonClick(object sender, EventArgs e)
        {
            TT = State.Reset;
        }

        void View_AddButtonClick(object sender, EventArgs e)
        {
            TT = State.Add;
        }
    }
}
