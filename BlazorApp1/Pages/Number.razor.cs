namespace BlazorApp1.Pages;

public partial class Number
{
    public double? BoundDouble { get; set; }

    public int? BoundInteger { get ; set ; }

    public int BoundIntegerMicrosoft { get ; set ; }

    public TestEditFormNumber Model = new TestEditFormNumber();
}

public class TestEditFormNumber
{
    public double? Value { get; set; }
}