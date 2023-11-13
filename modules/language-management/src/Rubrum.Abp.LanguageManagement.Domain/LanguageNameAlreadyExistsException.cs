using Volo.Abp;

namespace Rubrum.Abp.LanguageManagement;

public class LanguageNameAlreadyExistsException : BusinessException
{
    public LanguageNameAlreadyExistsException(string name) : base("Language:Error:NameAlreadyExists")
    {
        Name = name;
    }

    public string Name { get; }
}
