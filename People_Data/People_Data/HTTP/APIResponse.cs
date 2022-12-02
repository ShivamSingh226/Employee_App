namespace People_Data.HTTP
{
    public class APIResponse
    {
        public string Code
        {
            get;
            set;
        }
        public string Message
        {
            get;
            set;
        }
        public object? ResponseData
        {
            get;
            set;
        }
        public PeopleModel Model { get; set; }
        public List<PeopleModel> lst { get; set; }
    }
    public enum ResponseType
    {
        Success,
        NotFound,
        Failure
    }

}
