namespace Rubrum.Abp.Translator;

public class TranslateProcessResult
{
    public TranslateProcessResult(string result, TranslateProcessState state)
    {
        Result = result;
        State = state;
    }

    public string Result { get; }

    public TranslateProcessState State { get; }
}
