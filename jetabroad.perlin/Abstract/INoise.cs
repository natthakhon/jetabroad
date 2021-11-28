using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jetabroad.perlin.Abstract
{
    public interface INoise
    {
        double Noise(double x, double y, double z);
    }
}
