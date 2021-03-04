namespace JieBaseHelper.ValidateHelper
{
    public class ValidateResult
    {
        public bool Validate { get; private set; }
        public string SuccessMessage { get; private set; }
        public string ErrorMessage { get; private set; }
        public ValidateResult()
        {
            Validate = true;
        }
        public static ValidateResult Error(string errorMessage = null)
        {
            return new ValidateResult
            {
                Validate = false,
                ErrorMessage = errorMessage
            };
        }
        public static ValidateResult Success(string message = null)
        {
            return new ValidateResult
            {
                Validate = true,
                SuccessMessage = message
            };
        }
    }
}
