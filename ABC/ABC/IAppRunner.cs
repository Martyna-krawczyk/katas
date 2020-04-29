namespace ABC
{
    public interface IAppRunner
    {
        void Run();

        void RunDefaultWords();

        void RunCustomWord(string customWord);
    }
}