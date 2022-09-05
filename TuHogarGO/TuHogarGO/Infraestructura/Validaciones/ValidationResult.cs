namespace TuHogarGO.Infraestructura.Validaciones
{
    public class ValidationResult
    {
        public IList<ValidationResultItem> Errors { get; set; } = new List<ValidationResultItem>();
        public bool IsValid
        {
            get
            {
                return Errors == null | Errors != null && (Errors.Count == 0 || Errors.All(x=> x.IsValid) );
            }
        }
    }
    public class ValidationResultItem
    {
        public ValidationResultItem(string fieldName, string validationMessage, bool isValid = false)
        {
            FieldName = fieldName;
            IsValid = isValid;
            ValidationMessage = validationMessage;
        }

        public string FieldName { get; private set; }
        public bool IsValid { get; private set; }
        public string ValidationMessage { get; private set; }
    }
}
