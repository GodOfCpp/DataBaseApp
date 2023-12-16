using System;
using System.Reflection;
using System.Windows.Forms;

namespace DB_project.BLL.Helpers;

public class DataGridViewHelper
{
    public static void FillObjectFromRow(object obj, DataGridView table, DataGridViewRow row)
    {
        var objectType = obj.GetType();
        
        foreach (DataGridViewColumn column in table.Columns)
        {
            var propertyName = column.HeaderText;
            var property = objectType.GetProperty(propertyName);

            if (property != null)
            {
                object cellValue = row.Cells[column.Index].Value;

                if (cellValue != null && property.PropertyType.IsAssignableFrom(cellValue.GetType()))
                {
                    // Установка значения свойства объекта
                    property.SetValue(obj, Convert.ChangeType(cellValue, property.PropertyType));
                }
                // Добавьте дополнительную обработку, если типы не совпадают или значение равно null
            }
            // Добавьте дополнительную обработку, если свойство не найдено
        }
    }
}