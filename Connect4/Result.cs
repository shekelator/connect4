namespace Connect4
{
    public class Result
    {
        private readonly string m_value;

        private Result(string stringValue)
        {
            m_value = stringValue;
        }

        public static Result Invalid => new Result("Invalid");

        public override string ToString()
        {
            return m_value;
        }
    }
}