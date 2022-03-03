using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesHerencia
{
    public class ClaseDerivada:ClaseAbstracta
    {
        public enum ETipo{ Fino, Grueso, Medio };
        public ConsoleColor color;
        public ETipo algo;


    }
}
