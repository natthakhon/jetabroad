using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jetabroad.perlin.Abstract
{
    public interface ILattice
    {
        double Lattice(int ix, int iy, int iz, double fx, double fy, double fz);
    }
}
