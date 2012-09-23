using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UrunYorum.Data.Engine.Infrastructure
{
    public interface IDbContextFactory
    {
        UrunYorumDataContext CreateNew();
    }
}
