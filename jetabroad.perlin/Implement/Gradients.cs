using jetabroad.perlin.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jetabroad.perlin.Implement
{
    /*
     * The original Perlin started with creating gradients so I removed the chunk of code and having this class doing the job instead.
     * The only output this class produced is array of double. The IGradients is there for this job.
    */
    public class Gradients : IGradients
    {
        private int size;
        private double[] gradients;
        private readonly Random random;

        public Gradients(int size,int seed)
        {
            this.size = size;
            this.gradients = new double[size*3];
            this.random = new Random(seed);
        }

        public int Size => this.size;

        public double[] Create()
        {
            for (int i = 0; i < this.size; i++)
            {
                double z = 1f - 2f * this.random.NextDouble();
                double r = Math.Sqrt(1f - z * z);
                double theta = 2 * Math.PI * this.random.NextDouble();
                this.gradients[i * 3] = r * Math.Cos(theta);
                this.gradients[i * 3 + 1] = r * Math.Sin(theta);
                this.gradients[i * 3 + 2] = z;
            }

            return this.gradients;
        }
    }
}
