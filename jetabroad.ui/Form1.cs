using jetabroad.perlin.Abstract;
using jetabroad.perlin.Implement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jetabroad.ui
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IGradients gradients = new Gradients(RandomTable.GradientSizeTable,99);
            ILattice grid = new Grid(gradients.Create(), RandomTable.Index);
            PerlinNoise perlinNoise = new PerlinNoise(grid, this.Smooth, this.Lerp);

            Bitmap bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            double widthDivisor = 1 / (double)pictureBox1.Width;
            double heightDivisor = 1 / (double)pictureBox1.Height;
            bitmap.SetEachPixelColour(
                (point, color) =>
                {
                    // Note that the result from the noise function is in the range -1 to 1, but I want it in the range of 0 to 1
                    // that's the reason of the strange code
                    double v =
                                // First octave
                                (perlinNoise.Noise(2 * point.X * widthDivisor, 2 * point.Y * heightDivisor, -0.5) + 1) / 2 * 0.7 +
                                // Second octave
                                (perlinNoise.Noise(4 * point.X * widthDivisor, 4 * point.Y * heightDivisor, 0) + 1) / 2 * 0.2 +
                                // Third octave
                                (perlinNoise.Noise(8 * point.X * widthDivisor, 8 * point.Y * heightDivisor, +0.5) + 1) / 2 * 0.1;

                    v = Math.Min(1, Math.Max(0, v));
                    byte b = (byte)(v * 255);
                    return Color.FromArgb(b, b, b);
                });
            pictureBox1.Image = bitmap;

        }

        private double Smooth(double x)
        {
            return x * x * (3 - 2 * x);
        }

        private double Lerp(double t, double value0, double value1)
        {
            return value0 + t * (value1 - value0);
        }
    }
}
