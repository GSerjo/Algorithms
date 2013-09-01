namespace Algorithms
{
    public static class Fibonacci
    {
        public static int For(int value)
        {
            if (value <= 1)
            {
                return value;
            }
            return For(value - 1) + For(value - 2);
        }

        public static int For1(int value)
        {
            if (value <= 1)
            {
                return value;
            }
            var list = new int[value];
            list[0] = 0;
            list[1] = 1;
            for (int i = 2; i < value; i++)
            {
                list[i] = list[i - 1] + list[i - 2];
            }
            return list[list.Length - 1] + list[list.Length - 2];
        }

        public static int For2(int value)
        {
            if (value <= 1)
            {
                return value;
            }
            int dummy1 = 0;
            int dummy2 = 1;
            for (int i = 2; i < value; i++)
            {
                int fib = dummy1 + dummy2;
                dummy1 = dummy2;
                dummy2 = fib;
            }
            return dummy1 + dummy2;
        }
    }
}
