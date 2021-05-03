using System;
using System.Collections.Generic;
using System.Text;

namespace dotNET_HW_1.Model
{
    class CustomCircle : CustomPoint
    {
        #region Properties and fields

        private double _radius;

        public double Radius
        {
            get => _radius;
            private set => _radius = value <= 0d
                ? throw new Exception($"Radius couldn't be less or equal to 0. Radius = {value}")
                : value;
        }

        #endregion

        #region Constructors

        public CustomCircle()
        {
            Radius = 1d;
        }

        public CustomCircle(double x, double y, double radius) 
            : base(x, y)
        {
            this.Radius = radius;
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
            Radius *= coefficient;
        }

        #endregion

        #region Helper methods

        public override void Print()
        {
            string figureInfo = $@"====================
Figure: Circle
Radius = {Radius}
A(x = {X},y = {Y})
====================";

            Console.WriteLine(figureInfo);
        }


        #endregion

    }
}
