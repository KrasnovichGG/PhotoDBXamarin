using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoDBXamarin.DB
{
    public interface ISqlite
    {
        string GetDatabasePath(string filename);
    }
}
