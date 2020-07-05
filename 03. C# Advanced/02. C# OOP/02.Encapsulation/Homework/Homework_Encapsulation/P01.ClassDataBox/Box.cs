using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Transactions;

namespace P01.ClassDataBox
{
    public class Box
    {
        private double length;
        private double width;
        private double height;


        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Height
        {
            get { return this.height; }
            private set
            {
                if (!isValid(value))
                {
                    throw new ArgumentOutOfRangeException($"Height cannot be zero or negative.");
                }
                this.height = value;
            }
        }
        public double Width
        {
            get { return this.width; }
            private set
            {
                if (!isValid(value))
                {
                    throw new ArgumentOutOfRangeException($"Width cannot be zero or negative.");
                }

                this.width = value;
            }
        }

        public double Length
        {
            get { return this.length; }
            private set
            {
                if (!isValid(value))
                {
                    throw new ArgumentOutOfRangeException($"Length cannot be zero or negative.");
                }

                this.length = value;
            }
        }


        private bool isValid(double param)
        {
            if (param <= 0)
            {
                return false;
            }

            return true;
        }

        public double SurfaceArea()
        {
            double result = 0;
            result = 2 * (this.Length * this.Width + this.Length * this.Height + this.Width * this.Height);

            return result;
        }

        public double LateralSurfaceArea()
        {
            double result = 0;
            result = 2 * (this.Length * this.Height + this.Width * this.Height);
            
            return result;
        }

        public double Volume()
        {
            double result = 0;
            result = this.Length * this.Height * this.Width;
            return result;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Surface Area - {this.SurfaceArea():F2}");
            sb.AppendLine($"Lateral Surface Area - {this.LateralSurfaceArea():F2}");
            sb.AppendLine($"Volume - {this.Volume():F2}");
            return sb.ToString().Trim();
        }
    }
}
