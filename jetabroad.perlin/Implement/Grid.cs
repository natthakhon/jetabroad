using jetabroad.perlin.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jetabroad.perlin.Implement
{
    /*
     * The class need one object input which is the array of double, supposedly got from the IGradients
     * The func delegate again as I seriously dont even know how should I name it if it is delegate.
     * It is there to do the job as the original code does from the line 105-108.
     * Again it is delegate so implemetation can be anyone's desire.
    */
    public class Grid : ILattice
    {
        private double[] gradients;
        private Func<int, int, int, int> indexHandler;

        public Grid(double[] gradients
            , Func<int, int, int, int> indexHandler)
        {
            this.gradients = gradients;
            this.indexHandler = indexHandler;
        }

        public double[] Gradients => this.gradients;

        public double Lattice(int ix, int iy, int iz, double fx, double fy, double fz)
        {
            int g = this.indexHandler(ix, iy, iz);
            return this.gradients[g] * fx + this.gradients[g + 1] * fy + this.gradients[g + 2] * fz;
        }
        
    }
}

