namespace Rubrum.Abp.Translator;

public class TranslateProcessResult
{
    public string Result { get; }
    public TranslateProcessState State { get; }

    public TranslateProcessResult(string result, TranslateProcessState state)
    {
        Result = result;
        State = state;
    }
}
