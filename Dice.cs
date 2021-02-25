using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExam
{
    public class Dice: Random
    {
        private static Dice instance = null;
        private Dice():base() { }
        
        public static Dice Get_Instance()
        {
            return instance is null ? new Dice() : instance;
        }

    }
}
