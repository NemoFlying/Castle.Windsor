using IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Animal : IOCBase,IAnimal
    {
        public string SayHello()
        {
            return "A Dog Say Hello";
        }
    }
}
