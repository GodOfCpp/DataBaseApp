using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using DB_project.BLL.Entities;
using DB_project.BLL.Helpers;
using DB_project.BLL.Services;
using DB_project.DAL;
using Npgsql.Spatial;

namespace DB_project
{
    public partial class Form1 : Form
    {
        private static string _lastHeaderPressed = "";
        private static Type _currentType = null;

        void ConfigureForm()
        {
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            this.tableDataGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
            this.tableDataGridView.Columns.Add(new DataGridViewButtonColumn
            {
                HeaderText = "",
                Name = "UpdateColumn",
                Text = "Update",
                UseColumnTextForButtonValue = true,
                
            });
            
            this.tableDataGridView.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "DeleteColumn",
                HeaderText = "",
                Text = "Delete",
                UseColumnTextForButtonValue = true
            });
            this.tableDataGridView.CellClick += tableDataGridView_CellContentClick;
            this.tableDataGridView.ColumnHeaderMouseClick += DataGridView_ColumnHeaderMouseClick;
        }

        public Form1()
        {
            InitializeComponent();
            ConfigureForm();

            #region ButtonActions

            this.SelectButton.Click += SelectButton_Click;
            this.CreateButton.Click += CreateButton_Click;
            this.ViewButton.Click += ViewButton_Click;

            #endregion

        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            this.SelectTableComboBox.Visible = true;
            this.SelectTableLabel.Visible = true;
            this.MainTitle.Visible = false;
            this.SelectTableComboBox.DataSource = Constants.Tables;
            this.SelectTableComboBox.SelectedIndex = -1;
            this.SelectTableComboBox.SelectedIndexChanged -= TableContainer_ChangeIndex_Select;
            this.SelectTableComboBox.SelectedIndexChanged += TableContainer_ChangeIndex_Create;

        }

        private void SelectButton_Click(object sender, EventArgs e)
        {
            this.SelectTableComboBox.DataSource = Constants.Tables;
            this.MainTitle.Visible = false;
            this.SelectTableComboBox.Visible = true;
            this.SelectTableLabel.Visible = true;
            this.SelectTableComboBox.SelectedIndex = -1;
            this.SelectTableComboBox.SelectedIndexChanged -= TableContainer_ChangeIndex_Create;
            this.SelectTableComboBox.SelectedIndexChanged += TableContainer_ChangeIndex_Select;
        }

        private void UpdateButton(int rowIndex)
        {
            var obj = Activator.CreateInstance(_currentType);
            DataGridViewHelper.FillObjectFromRow(obj, tableDataGridView, tableDataGridView.Rows[rowIndex]);

            using (var form = new CreateObject(obj))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    switch (obj)
                    {
                        case School school:
                            obj = form.GetResultObject<School>();
                            //SchoolService.UpdateSchool(school);
                            break;
                        case Employee employee:
                            //EmployeeService.UpdateEmployee(employee);
                            break;
                        case Teacher teacher:
                            //TeacherService.UpdateTeacher(teacher);
                            break;
                        case Student student:
                            //StudentService.UpdateStudent(student);
                            break;
                        case Class _class:
                            obj = form.GetResultObject<Class>();
                            ClassService.UpdateClass(_class);
                            break;
                        case Subject subject:
                            //SubjectService.UpdateSubject(subject);
                            break;
                    }
                }
            }
        }
        
        private async Task DeleteButton(int rowIndex)
        {
            var obj = Activator.CreateInstance(_currentType);
            var id = (Guid)tableDataGridView.Rows[rowIndex].Cells[2].Value;
            
            switch (obj)
            {
                case School:
                    await SchoolService.DeleteSchool(id);
                    break;
                case Employee:
                    await EmployeeService.DeleteEmployee(id);
                    break;
                case Teacher:
                    await TeacherService.DeleteTeacher(id);
                    break;
                case Student:
                    await StudentService.DeleteStudent(id);
                    break;
                case Class:
                    await ClassService.DeleteClass(id);
                    break;
                case Subject:
                    await SubjectService.DeleteSubject(id);
                    break;
            }
            
            TableContainer_ChangeIndex_Select(SelectTableComboBox, EventArgs.Empty);
        }

        private void ViewButton_Click(object sender, EventArgs e)
        {
            this.tableDataGridView.DataSource = ViewService.GetTeacherInfo().ToList();
        }

        private void tableDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (tableDataGridView.Columns[e.ColumnIndex] is not DataGridViewButtonColumn) return;
            if (e.ColumnIndex == tableDataGridView.Columns["UpdateColumn"]!.Index)
                UpdateButton(e.RowIndex);
            else if (e.ColumnIndex == tableDataGridView.Columns["DeleteColumn"]!.Index)
                DeleteButton(e.RowIndex);
        }

        private void TableContainer_ChangeIndex_Create(object sender, EventArgs e)
        {
            if ((sender as ComboBox).SelectedIndex == -1)
            {
                return;
            }
            
            object? newObject = new();
            
            switch ((sender as ComboBox).SelectedItem)
            {
                case "Schools":
                    newObject = FillObject<School>();
                    if (newObject != null) SchoolService.CreateSchool((newObject as School));
                    break;
                case "Employees":
                    newObject = FillObject<Employee>();
                    if (newObject != null) EmployeeService.CreateEmployee((newObject as Employee));
                    break;
                case "Teachers":
                    newObject = FillObject<Teacher>();
                    if (newObject != null) TeacherService.CreateTeacher((newObject as Teacher));
                    break;
                case "Classes":
                    newObject = FillObject<Class>();
                    if (newObject != null) ClassService.CreateClass((newObject as Class));
                    break;
                case "Students":
                    newObject = FillObject<Student>();
                    if (newObject != null) StudentService.CreateStudent((newObject as Student));
                    break;
                case "Subjects":
                    newObject = FillObject<Subject>();
                    if (newObject != null) SubjectService.CreateSubject((newObject as Subject));
                    break;
                default:
                    throw new Exception("Unknown table");
            }
        }

        private static T FillObject<T>() where T : class, new()
        {
            T data = new();
            using (var form = new CreateObject(data))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    data = (T)form.GetResultObject<T>();
                }
                else
                {
                    return null;
                }
                return data;
            }
        }
        
        private void TableContainer_ChangeIndex_Select(object sender, EventArgs e)
        {
            if ((sender as ComboBox).SelectedIndex == -1)
            {
                return;
            }
            switch ((sender as ComboBox).SelectedItem)
            {
                case "Schools":
                    this.tableDataGridView.DataSource = SchoolService.GetSchools();
                    _currentType = typeof(School);
                    break;
                case "Employees":
                    this.tableDataGridView.DataSource = EmployeeService.GetEmployees();
                    _currentType = typeof(Employee);
                    break;
                case "Teachers":
                    this.tableDataGridView.DataSource = TeacherService.GetTeachers();
                    _currentType = typeof(Teacher);
                    break;
                case "Classes":
                    this.tableDataGridView.DataSource = ClassService.GetClasses();
                    _currentType = typeof(Class);
                    break;
                case "Students":
                    this.tableDataGridView.DataSource = StudentService.GetStudents();
                    _currentType = typeof(Student);
                    break;
                case "Subjects":
                    this.tableDataGridView.DataSource = SubjectService.GetSubjects();
                    _currentType = typeof(Subject);
                    break;
                default:
                    throw new Exception("Unknown table");
            }
        }
        
        private void DataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var headerName = tableDataGridView.Columns[e.ColumnIndex].Name;
            switch (tableDataGridView.DataSource)
            {
                case List<School> schools:
                    SortGridView(schools, headerName);
                    break;
                case List<Employee> employees:
                    SortGridView(employees, headerName);
                    break;
                case List<Teacher> teachers:
                    SortGridView(teachers, headerName);
                    break;
                case List<Class> classes:
                    SortGridView(classes, headerName);
                    break;
                case List<Student> students:
                    SortGridView(students, headerName);
                    break;
                case List<Subject> subjects:
                    SortGridView(subjects, headerName);
                    break;
            }
        }

        private void SortGridView<T>(List<T> data, string headerName)
        {
            data = headerName != _lastHeaderPressed ? data.OrderBy(obj => BLL.Helpers.ReflectionHelper.GetPropertyValue(obj, headerName)).ToList() :
                data.OrderByDescending(obj => BLL.Helpers.ReflectionHelper.GetPropertyValue(obj, headerName)).ToList();
            tableDataGridView.DataSource = data;

            _lastHeaderPressed = headerName == _lastHeaderPressed ? "" : headerName;
        }


    }
}