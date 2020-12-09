using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;

namespace TestingConsoleApp
{
    class MockConfigurationSection : IConfigurationSection
    {
        //redo
        string connectionString = "Server=localhost;Database=debtdb;Uid=debtAccessor;Pwd=123;";
        public string this[string key]
        {
            get
            {
                return connectionString;
            }
            set => throw new NotImplementedException();
        }

        public string Key => throw new NotImplementedException();

        public string Path => throw new NotImplementedException();

        public string Value { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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
    }
}
