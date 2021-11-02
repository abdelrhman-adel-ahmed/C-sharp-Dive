namespace Dependency_injection_tools
{
    public interface ITranslate<Source, Destination>
    {
        Destination From(Source invoice);

    }
}