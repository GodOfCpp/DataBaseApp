namespace DB_project.BLL.Helpers;

public class ReflectionHelper
{
    public static object GetPropertyValue(object obj, string propertyName)
    {
        var propertyInfo = obj.GetType().GetProperty(propertyName);
        if (propertyInfo != null)
        {
            return propertyInfo.GetValue(obj);
        }
        return null;
    }
}