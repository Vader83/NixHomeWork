using System;
using System.Collections.Generic;
using System.Text;

namespace dotNET_HW_1.Model
{
    class CustomTriangle : CustomPoint
    {
        #region Properties and field
        
        public double Dx2 { get; private set; }
        public double Dy2 { get; private set; }

        public double Dx3 { get; private set; }
        public double Dy3 { get; private set; }

        #endregion

        #region Constructors

        public CustomTriangle()
        {
            Dx2 = 1;
            Dy2 = 1;

            Dx3 = 2;
            Dy3 = 0;
        }

        public CustomTriangle(double x, double y, double dx2, double dy2, double dx3, double dy3) : base(x, y)
        {
            Dx2 = dx2;
            Dy2 = dy2;

            Dx3 = dx3;
            Dy3 = dy3;

            if (!CheckTriangle())
                throw new Exception("Triangle couldn't exist with current sides");
        }
        

        #endregion

        #region Modify methods

        public override void Move(double dx, double dy)
        {
            X += dx;
            Y += dy;
        }

        public override void Scale(double coefficient)
        {
            if (coefficient <= 0)
                throw new Exception($"Scale coefficient couldn't be less or equal to 0. Coefficient = {coefficient}");
            Dx2 *= coefficient;
            Dy2 *= coefficient;

            Dx3 *= coefficient;
            Dy3 *= coefficient;
        }

        #endregion

        #region Helper methods

        public double GetSideLength(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
        }

        private bool CheckTriangle()
        {
            double sideLenth1 = GetSideLength(X, Y, X + Dx2, Y + Dy2);
            double sideLenth2 = GetSideLength(X, Y, X + Dx3, Y + Dy3);
            double sideLenth3 = GetSideLength(X + Dx2, Y + Dy2, X + Dx3, Y + Dy3);

            if (sideLenth1 + sideLenth2 - sideLenth3 == 0)
                return false;
            if (Dx2.Equals(Dx3) && Dy2.Equals(Dy3))
                return false;
            return true;
        }

        public override void Print()
        {
            string figureInfo = $@"====================
Figure: Triangle
Delta B: x = {Dx2}, y = {Dy2}; Delta C: x = {Dx3}, y = {Dy3}
            A(x = {X},y = {Y})      
B(x = {X + Dx2},y = {Y + Dy2})     C(x = {X + Dx3}, y = {Y + Dy3})
====================";

            Console.WriteLine(figureInfo);
        }

        #endregion
    }
}
