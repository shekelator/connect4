using System.Runtime.InteropServices.ComTypes;

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
        public static Result Player1 => new Result("Player1");
        public static Result Player2 => new Result("Player2");

        public override string ToString()
        {
            return m_value;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Result other)) return false;

            return obj.ToString() == other.ToString();
        }

        protected bool Equals(Result other)
        {
            return string.Equals(m_value, other.m_value);
        }

        public override int GetHashCode()
        {
            return (m_value != null ? m_value.GetHashCode() : 0);
        }
    }
}