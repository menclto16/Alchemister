using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlchemisterLib
{
    abstract class AEffect
    {
        int Value;

        public abstract void TriggerEffect();
    }
}
