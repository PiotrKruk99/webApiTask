namespace webApi.DataClasses.Entities
{
    public class TestEntityOne
    {
        public int Id { get; set; }
        public string Value1 { get; set; } = "";
        public string Value2 { get; set; } = "";
        public virtual TestEntityTwo EntityTwo { get; set; }
    }
}
