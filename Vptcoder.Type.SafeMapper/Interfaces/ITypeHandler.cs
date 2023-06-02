namespace Vptcoder.Type.Interface
{
    public interface ITypeHandler
    {
        object ChangeType(object value, System.Type conversionType);
    }
}