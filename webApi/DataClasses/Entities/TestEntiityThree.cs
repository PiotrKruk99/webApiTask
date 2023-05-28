namespace webApi.DataClasses.Entities;

public class TestEntityThree
{
    public int Id { get; set; }
    public string StringVal { get; set; }
    public DateTime DateVal { get; set; }

    public TestEntityThree()
    {
        StringVal = Guid.NewGuid().ToString();

        var date = DateTime.UtcNow;

        if (date.Ticks % 2 == 0)
            date = date.AddYears(10);

        DateVal = date;
    }
}