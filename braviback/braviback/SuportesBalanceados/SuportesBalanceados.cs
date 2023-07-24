namespace braviback.SuportesBalanceados
{
    public class SuportesBalanceados
    {
        static void Start()
        {
            string entrada = "()";
            Console.WriteLine(isValid(entrada));
        }

        static bool isValid(string str)
        {
            var stack = new Stack<char>();

            stack.Push('z');

            Dictionary<char, char> dict = new Dictionary<char, char>()
        {
            { '}', '{' },
            { ']', '[' },
            { ')', '(' },
        };

            foreach (var c in str)
            {
                if (dict.ContainsKey(c))
                {
                    if (dict[c] != stack.Pop())
                    {
                        return false;
                    }
                }
                else
                {
                    stack.Push(c);
                }
            }

            return stack.Count() <= 1;
        }
    }
}
