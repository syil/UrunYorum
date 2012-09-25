using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UrunYorum.Data.Engine.Infrastructure;
using UrunYorum.Base.Utilities;

namespace UrunYorum.Test.DatabaseObjectTests
{
    public abstract class DboTestBase
    {
        private const int MaxRandomValue = 99999;
        private const int MinRandomValue = 10000;

        private Random random = new Random();

        protected DbContextFactory DbContextFactory { get; private set; }
        protected UnitOfWork UnitOfWork { get; private set; }

        protected DboTestBase()
        {
            DbContextFactory = new DbContextFactory();
            UnitOfWork = new UnitOfWork(DbContextFactory);
        }

        protected string GetRandomString(int wordCount)
        {
            LoremIpsum lipsum = new LoremIpsum();
            return lipsum.GetWords(wordCount, true);
        }

        protected int GetRandom(int maxValue)
        {
            return random.Next(maxValue);
        }

        protected int GetRandom(int minValue = MinRandomValue, int maxValue = MaxRandomValue)
        {
            return random.Next(minValue, maxValue);
        }
    }
}
