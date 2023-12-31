﻿using Rubrum.Abp.Graphql.Types;

namespace Rubrum.Abp.LanguageManagement;

public class SystemLanguageMutationType :
    EntityMutationType<SystemLanguageDto, string, ISystemLanguageGraphqlService, CreateSystemLanguageInput, UpdateSystemLanguageInput>
{
    protected override string TypeName => SystemLanguageConstants.TypeName;

    protected override string TypeNameSingular => "SystemLanguage";

    protected override string TypeNameInPlural => "SystemLanguages";
}
