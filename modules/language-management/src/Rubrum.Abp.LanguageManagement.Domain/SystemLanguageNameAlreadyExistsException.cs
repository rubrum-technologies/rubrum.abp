using Volo.Abp;

namespace Rubrum.Abp.LanguageManagement;

public class SystemLanguageNameAlreadyExistsException : BusinessException
{
    public SystemLanguageNameAlreadyExistsException(string name) : base("SystemLanguage:Error:NameAlreadyExists")
    {
        Name = name;
    }

    public string Name { get; }
}
