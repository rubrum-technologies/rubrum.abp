using Rubrum.Abp.Hosting;
using Rubrum.Abp.ImageStoring;

try
{
    var app = await ApplicationBuilderHelper.BuildApplicationAsync<ConsoleTestModule>(args);

    await app.InitializeApplicationAsync();
    await app.RunAsync();

    return 0;
}
catch (Exception ex)
{
    return 1;
}
