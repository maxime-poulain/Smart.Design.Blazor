namespace Smart.Design.Blazor;

public partial class SmartInputNumber<TValue> : InputBase<TValue>
{
    public SmartInputNumber()
    {
        ValidateTargetType();
    }

    private bool ValidateTargetType()
    {
        var targetType = Nullable.GetUnderlyingType(typeof(TValue)) ?? typeof(TValue);

        if (targetType == typeof(int) ||
            targetType == typeof(long) ||
            targetType == typeof(short) ||
            targetType == typeof(float) ||
            targetType == typeof(double) ||
            targetType == typeof(decimal))
            return true;

        throw new InvalidOperationException($"The type '{targetType}' is not a supported numeric type.");
    }
}