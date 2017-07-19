using System.Reflection;

namespace TestLibrary.Helpers
{
    public static class ReflectivePropertyHelper
    {
		public static void SetProperty<T, TVal>(T objectInstance, string propertyName, TVal valueToInsert)
		{
			var property = GetPropertyInfo<T>(propertyName);

			property?.SetValue(objectInstance, valueToInsert);
		}

	    private static PropertyInfo GetPropertyInfo<T>(string propertyName)
	    {
		    var type = typeof(T);

		    return type.GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Public);
	    }
    }
}
