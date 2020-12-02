using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public interface IAPISQLBridge
    {
        Task AddDataFromAPIToDb();
    }
}
