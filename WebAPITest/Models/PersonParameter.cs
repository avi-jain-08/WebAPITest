namespace WebAPITest.Models
{
    public class PersonParameter
    {
        public bool IsVistedOutsideIndia { get; set; }
        public bool IsHavingCough { get; set; }
        public bool IsFever { get; set; }

        public bool MyProperty { get; set; }
        public bool MyProperty1 { get; set; }


        public enum Colors
        {
            Red,
            Orange,
            Green

        }
    }
}
