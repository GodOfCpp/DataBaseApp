using System;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using DB_project.BLL.Entities;
using DB_project.BLL.Services;

namespace DB_project;

public partial class CreateObject : Form
{
    private object dataObject;
    public CreateObject(object obj)
    {
        InitializeComponent();
        dataObject = obj;

        switch (obj)
        {
            case School:
                GenerateControls<School>(obj);
                break;
            case Employee:
                GenerateControls<Employee>(obj);
                break;
            case Teacher:
                GenerateControls<Teacher>(obj);
                break;
            case Class:
                GenerateControls<Class>(obj);
                break;
            case Student:
                GenerateControls<Student>(obj);
                break;
            case Subject:
                GenerateControls<Subject>(obj);
                break;
        }
    }
    
    
    private void GenerateControls<T>(object? obj = null)
    {
        Type objectType = typeof(T);
        PropertyInfo[] properties = objectType.GetProperties();

        int yPosition = 20;

        foreach (PropertyInfo property in properties)
        {
            Label label = new Label
            {
                Text = property.Name,
                Location = new Point(20, yPosition),
                Width = 100
            };

            Control inputControl;

            // Определите тип свойства и создайте соответствующий элемент управления

            if (property.PropertyType == typeof(string))
            {
                inputControl = new TextBox();
                inputControl.Text = obj != null ? property.GetValue(obj)?.ToString() : string.Empty;
            }

            else if (property.PropertyType == typeof(decimal))
            {
                inputControl = new NumericUpDown();
                (inputControl as NumericUpDown).Maximum = 1000000;
                inputControl.Text = obj != null ? property.GetValue(obj).ToString() : string.Empty;
            }
            
            else if (property.PropertyType == typeof(School))
            {
                inputControl = new ComboBox();
                (inputControl as ComboBox).DropDownWidth = 450;
                (inputControl as ComboBox).DataSource = SchoolService.GetSchools().Select(_ => _.Name).ToList();
            }
            
            else if (property.PropertyType == typeof(Employee))
            {
                inputControl = new ComboBox();
                (inputControl as ComboBox).DropDownWidth = 450;
                (inputControl as ComboBox).DataSource = EmployeeService.GetEmployees().Select(_ => _.Name).ToList();
            }
            
            else if (property.PropertyType == typeof(Teacher))
            {
                inputControl = new ComboBox();
                (inputControl as ComboBox).DropDownWidth = 450;
                (inputControl as ComboBox).DataSource = TeacherService.GetTeachers().Select(_ => _.Employee.Name).ToList();
            }
            
            else if (property.PropertyType == typeof(Class))
            {
                inputControl = new ComboBox();
                (inputControl as ComboBox).DropDownWidth = 450;
                (inputControl as ComboBox).DataSource = ClassService.GetClasses().Select(_ => $"{_.Number}{_.Letter}").ToList();
            }
            
            else if (property.PropertyType == typeof(Student))
            {
                inputControl = new ComboBox();
                (inputControl as ComboBox).DropDownWidth = 450;
                (inputControl as ComboBox).DataSource = StudentService.GetStudents().Select(_ => _.Name).ToList();
            }
            
            else if (property.PropertyType == typeof(Subject))
            {
                inputControl = new ComboBox();
                (inputControl as ComboBox).DropDownWidth = 450;
                (inputControl as ComboBox).DataSource = SubjectService.GetSubjects().Select(_ => _.Name).ToList();
            }
            
            else if (property.PropertyType == typeof(int))
            {
                inputControl = new NumericUpDown();
                inputControl.Text = obj != null ? property.GetValue(obj).ToString() : string.Empty;
            }
            else
            {
                continue;
            }

            inputControl.Name = property.Name;
            inputControl.Location = new Point(130, yPosition);
            yPosition += 30;

            Controls.Add(label);
            Controls.Add(inputControl);
        }

        Button okButton = new Button
        {
            Text = "OK",
            Location = new Point(50, yPosition),
            DialogResult = DialogResult.OK
        };

        Button cancelButton = new Button
        {
            Text = "Cancel",
            Location = new Point(160, yPosition),
            DialogResult = DialogResult.Cancel
        };

        Controls.Add(okButton);
        Controls.Add(cancelButton);
    }

    public object GetResultObject<T>() where T : class
    {
        var objectType = typeof(T);
        var properties = objectType.GetProperties();

        foreach (var property in properties)
        {
            var control = Controls[property.Name];

            switch (control)
            {
                case TextBox textBox:
                    property.SetValue(dataObject, textBox.Text);
                    break;
                case NumericUpDown numericUpDown:
                    property.SetValue(dataObject, numericUpDown.Value);
                    break;
                case ComboBox comboBox:

                    if (property.PropertyType == typeof(School))
                    {
                        property.SetValue(dataObject, SchoolService.GetSchoolByName(comboBox.SelectedItem.ToString()));
                    }
                    
                    else if (property.PropertyType == typeof(Teacher))
                    {
                        property.SetValue(dataObject, TeacherService.GetTeacherByName(comboBox.SelectedItem.ToString()));
                    }
                    
                    else if (property.PropertyType == typeof(Employee))
                    {
                        property.SetValue(dataObject, EmployeeService.GetEmployeeByName(comboBox.SelectedItem.ToString()));
                    }
                    
                    else if (property.PropertyType == typeof(Class))
                    {
                        property.SetValue(dataObject, ClassService.GetClassByName(comboBox.SelectedItem.ToString()));
                    }
                    
                    else if (property.PropertyType == typeof(Student))
                    {
                        property.SetValue(dataObject, StudentService.GetStudentByName(comboBox.SelectedItem.ToString()));
                    }
                    
                    else if (property.PropertyType == typeof(Subject))
                    {
                        property.SetValue(dataObject, SubjectService.GetSubjectByName(comboBox.SelectedItem.ToString()));
                    }
                    break;
                
            }

            // Добавьте обработку других типов элементов управления по необходимости
        }

        return dataObject;
    }
}