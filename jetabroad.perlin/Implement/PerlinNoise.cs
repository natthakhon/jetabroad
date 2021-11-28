using jetabroad.perlin.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jetabroad.perlin.Implement
{
    /*
     * My own version of Perlin, please note that I truly have no idea how the Perlin's algorithm work 
     * so the way this version breaks down the original version into components based solely on the code itself and my 'guts' feeling.
     * 
     * The class has only one major object implements ILattice and 2 func delegates.
     * The reason it is delegate instead of Interface is ,in order to have Interface, I feel you need to understand
     * the semantic of the object and apparently I have none of that as previously stated.
     * However delegate give you the room to implement your own algorithm you probably need as Interface does as well.
     * 
     * The class itself implements INoise where if someone want to implement his very own implementation then the code open freely for that too. 
     * 
    */
    public class PerlinNoise : INoise
    {
        private ILattice lattice;
        private Func<double, double> smoothHandler;
        private Func<double, double, double, double> lerpHandler;

        public PerlinNoise(ILattice lattice
            , Func<double,double> smoothHandler
            , Func<double, double,double,double> lerpHandler)
        {
            this.lattice = lattice;
            this.smoothHandler = smoothHandler;
            this.lerpHandler = lerpHandler;
        }

        public double Noise(double x, double y, double z)
        {
            double wx = this.smooth(x);
            double wy = this.smooth(y);
            double wz = this.smooth(z);

            int ix = (int)Math.Floor(x);
            int iy = (int)Math.Floor(y);
            int iz = (int)Math.Floor(z);

            double vx0 = this.lattice.Lattice(ix,iy,iz, x-ix, y-iy, z-iz);
            double vx1 = this.lattice.Lattice(ix + 1, iy, iz, x - ix - 1 , y - iy, z - iz);
            double vy0 = this.lerpHandler(wx, vx0, vx1);

            vx0 = this.lattice.Lattice(ix, iy + 1, iz, x - ix, y - iy - 1, z - iz);
            vx1 = this.lattice.Lattice(ix + 1, iy + 1, iz, x - ix - 1, y - iy - 1, z - iz);
            double vy1 = this.lerpHandler(wx, vx0, vx1);

            double vz0 = this.lerpHandler(wy, vy0, vy1);

            vx0 = this.lattice.Lattice(ix, iy, iz + 1, x - ix, y - iy, z - iz - 1);
            vx1 = this.lattice.Lattice(ix + 1, iy, iz + 1, x - ix - 1, y - iy, z - iz - 1);
            vy0 = this.lerpHandler(wx, vx0, vx1);

            vx0 = this.lattice.Lattice(ix, iy + 1, iz + 1, x - ix, y - iy - 1, z - iz - 1);
            vx1 = this.lattice.Lattice(ix + 1, iy + 1, iz + 1, x - ix - 1, y - iy - 1, z - iz - 1);
            vy1 = this.lerpHandler(wx, vx0, vx1);

            double vz1 = this.lerpHandler(wy, vy0, vy1);
            return this.lerpHandler(wz, vz0, vz1);
        }

        private double smooth(double d)
        {
            int ix = (int)Math.Floor(d);
            double f0 = d - ix;
            return this.smoothHandler(f0);
        }
    }
}
