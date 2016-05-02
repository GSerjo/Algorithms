using System;

namespace Algorithms.DynamicProgramming
{
    public static class CoinChanger
    {
        public static int Change(int amount)
        {
            return Change(amount, 2);
        }

        private static int Change(int amount, int kindOfCoins)
        {
            if (amount == 0)
            {
                return 1;
            }
            else if (amount < 0 || kindOfCoins == 0)
            {
                return 0;
            }
            else
            {
                return Change(amount, kindOfCoins - 1) + Change(amount - FirstDenomination(kindOfCoins), kindOfCoins);
            }
        }

        private static int FirstDenomination(int kindOfCoin)
        {
            switch (kindOfCoin)
            {
                case 1:
                    return 1;
                case 2:
                    return 5;
                case 3:
                    return 10;
                case 4:
                    return 25;
                case 5:
                    return 50;
                default:
                    throw new ArgumentException();
            }
        }
    }
}