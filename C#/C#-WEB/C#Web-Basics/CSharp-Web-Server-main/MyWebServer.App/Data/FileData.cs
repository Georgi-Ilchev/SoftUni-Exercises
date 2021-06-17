using MyWebServer.App.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer.App.Data
{
    public class FileData : IData
    {
        public IEnumerable<Cat> Cats => throw new NotImplementedException();

        //remove
    }
}
