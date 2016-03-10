using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
using View;
using System.ComponentModel.DataAnnotations;
using Common;
using Presenter;
namespace UI
{
    public partial class FrmUIForm : Form, IStudenteView
    {
        protected StudentePresenter pre;
        BindingSource binding = new BindingSource();

        public FrmUIForm()
        {
            InitializeComponent();
            Station = State.Reset;
          
            dgvData.AutoGenerateColumns = true;
            pre = new StudentePresenter(this);
        }

        public string Id
        {
            get
            {
                return txtId.Text;
            }
            set
            {
                txtId.Text = value;
            }
        }

        public int Age
        {
            get
            {
                return int.Parse(txtAge.Text);
            }
            set
            {
                txtAge.Text = value.ToString();
            }
        }

        public string Address
        {
            get
            {
                return txtAddress.Text;
            }
            set
            {
                txtAddress.Text = value;
            }
        }

        public string Class
        {
            get
            {
                return txtClass.Text;
            }
            set
            {
                txtClass.Text = value;
            }
        }

        public string Name
        {
            get
            {
                return txtName.Text;
            }
            set
            {
                txtName.Text = value;
            }
        }

        public List<StudentModel> ListStudent
        {
            set
            {
                binding.DataSource = value;
                dgvData.DataSource = binding;
            }
        }

        public event EventHandler<EventArgs> AddButtonClick;

        public event EventHandler<EventArgs> EditButtonClick;

        public event EventHandler<EventArgs> DeleteButtonClick;

        public event EventHandler<EventArgs> ResetButtonClick;

        public event EventHandler<EventArgs> SaveButtonClick;

        public event EventHandler<EventArgs> BackButtonClick;

        #region validate and enum state
        private ErrorProvider error = new ErrorProvider();

        List<ValidationResult> results = new List<ValidationResult>();

        private bool ShowError()
        {
            if (results.Count > 0)
            {
                error.Clear();
                error.BlinkStyle = ErrorBlinkStyle.NeverBlink;
                foreach (ValidationResult item in results)
                {
                    switch (item.MemberNames.First())
                    {
                        case "Id":
                            error.SetError(txtId, item.ErrorMessage);
                            break;
                        case "Name":
                            error.SetError(txtName, item.ErrorMessage);
                            break;
                        case "Age":
                            error.SetError(txtAge, item.ErrorMessage);
                            break;
                        case "Address":
                            error.SetError(txtAddress, item.ErrorMessage);
                            break;
                        case "Class":
                            error.SetError(txtClass, item.ErrorMessage);
                            break;
                    }
                }
                return false;
            }
            else
            {
                error.Clear();
                results.Clear();
                return true;
            }
        }

        private void ValidateControl()
        {
            results.Clear();

            var attributes = Attribute<IStudenteView>.GetAttribute("Id");
            var context = Attribute<IStudenteView>.GetContext(txtId.Text, "Id");
            Validator.TryValidateValue(txtId.Text, context, results, attributes);

            attributes = Attribute<IStudenteView>.GetAttribute("Name");
            context = Attribute<IStudenteView>.GetContext(txtName.Text, "Name");
            Validator.TryValidateValue(txtName.Text, context, results, attributes);

            attributes = Attribute<IStudenteView>.GetAttribute("Age");
            context = Attribute<IStudenteView>.GetContext(txtAge.Text, "Age");
            Validator.TryValidateValue(txtAge.Text, context, results, attributes);

            attributes = Attribute<IStudenteView>.GetAttribute("Address");
            context = Attribute<IStudenteView>.GetContext(txtAddress, "Address");
            Validator.TryValidateValue(txtAddress.Text, context, results, attributes);

            attributes = Attribute<IStudenteView>.GetAttribute("Class");
            context = Attribute<IStudenteView>.GetContext(txtClass.Text, "Class");
            Validator.TryValidateValue(txtClass.Text, context, results, attributes);
        }

        private void Binding()
        {

            txtClass.DataBindings.Clear();
            txtAge.DataBindings.Clear();
            txtId.DataBindings.Clear();
            txtName.DataBindings.Clear();
            txtAddress.DataBindings.Clear();

            txtId.DataBindings.Add(new Binding("Text", binding, "ID", true));
            txtAge.DataBindings.Add(new Binding("Text", binding, "Age", true));
            txtAddress.DataBindings.Add(new Binding("Text", binding, "Address", true));
            txtName.DataBindings.Add(new Binding("Text", binding, "Name", true));
            txtClass.DataBindings.Add(new Binding("Text", binding, "ClassName", true));
        }

        public enum State
        {
            Add,
            Del,
            Edit,
            Reset
        }

        public State Station
        {
            set
            {
                GetState(value);
            }
        }

        private void GetState(State station)
        {
            switch (station)
            {
                case State.Add:
                    txtAddress.ResetText();
                    txtId.ResetText();
                    txtName.ResetText();
                    txtAge.ResetText();
                    txtClass.ResetText();
                    btnEdit.Enabled = false;
                    btnDel.Enabled = false;
                    txtAddress.ReadOnly = false;
                    txtId.ReadOnly = false;
                    txtAge.ReadOnly = false;
                    txtClass.ReadOnly = false;
                    txtName.ReadOnly = false;
                    break;
                case State.Del:
                    Binding();
                    btnAdd.Enabled = false;
                    btnEdit.Enabled = false;
                    break;
                case State.Edit:
                    Binding();
                    btnAdd.Enabled = false;
                    btnDel.Enabled = false;
                    txtAddress.ReadOnly = false;
                    txtId.ReadOnly = true;
                    txtAge.ReadOnly = false;
                    txtClass.ReadOnly = false;
                    txtName.ReadOnly = false;
                    break;
                case State.Reset:
                    txtAddress.ResetText();
                    txtId.ResetText();
                    txtName.ResetText();
                    txtAge.ResetText();
                    txtClass.ResetText();
                    btnDel.Enabled = true;
                    btnEdit.Enabled = true;
                    btnAdd.Enabled = true;
                    txtAddress.ReadOnly = true;
                    txtId.ReadOnly = true;
                    txtAge.ReadOnly = true;
                    txtClass.ReadOnly = true;
                    txtName.ReadOnly = true;
                    break;
            }
        }
        #endregion

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Station = State.Add;
            AddButtonClick(sender, e);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Station = State.Edit;
            EditButtonClick(sender, e);
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            Station = State.Del;
            ValidateControl();
            if (ShowError())
            {
                DeleteButtonClick(sender, e);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Station = State.Reset;
            ResetButtonClick(sender, e);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ValidateControl();
            if (ShowError())
            {
                SaveButtonClick(sender, e);
                Station = State.Reset;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            BackButtonClick(sender, e);
        }
    }
}
