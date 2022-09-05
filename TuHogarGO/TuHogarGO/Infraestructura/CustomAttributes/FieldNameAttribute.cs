namespace TuHogarGO.Infraestructura.CustomAttributes
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
    public class FieldNameAttribute : Attribute, IFieldNameAttribute
    {
        private readonly string _fieldName;
        public FieldNameAttribute(string fieldName = "")
        {
            _fieldName = fieldName;
        }

        public string GetFieldName()
        {
            return _fieldName;
        }
        public static IFieldNameAttribute GetFieldNameAttribute(Type obj)
        {
            var fieldAttribute = obj.GetCustomAttributes(typeof(FieldNameAttribute), true).OfType<FieldNameAttribute>().FirstOrDefault();
            return fieldAttribute as IFieldNameAttribute;
        }
    }
}
