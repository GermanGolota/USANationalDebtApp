using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestingConsoleApp
{
    class MockConfiguration : IConfiguration
    {
        string c = "Server=localhost;Database=debtdb;IntegratedSecurity=yes; Uid=auth_windows;";
        public string this[string key]
        {
            get { return c; }
            set => throw new NotImplementedException();
        }

        public IEnumerable<IConfigurationSection> GetChildren()
        {
            throw new NotImplementedException();
        }

        public IChangeToken GetReloadToken()
        {
            throw new NotImplementedException();
        }

        public IConfigurationSection GetSection(string key)
        {
            throw new NotImplementedException();
        }

        public string GetConnectionString(string name)
        {
            return c;
        }
    }
}
