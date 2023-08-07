namespace BookShop.Exceptions
{
    public class CustomException : Exception
    {
        private int Code { get; set; }

        public CustomException(int code, string message) : base(message)
        {
            Code = code;
        }
    }
}
