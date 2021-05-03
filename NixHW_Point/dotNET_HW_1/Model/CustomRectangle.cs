using System;

namespace dotNET_HW_1.Model
{
    class CustomRectangle : CustomPoint
    {
        #region Properties and fields

        private double _width;
        private double _height;

        public double Width
        {
            get => _width;
            protected set => _width = value <= 0 
                ? throw new Exception($"Width couldn't be less or equal 0. Width = {value}") 
                : value;
        }

        public double Height
        {
            get => _height;
            protected set => _height = value <= 0 
                ? throw new Exception($"Height couldn't be less or equal 0. Height = {value}") 
                : value;
        }

        #endregion

        #region Constructors

        public CustomRectangle()
        {
            Width = 1d;
            Height = 1d;
        }

        public CustomRectangle(double x, double y, double width, double height) : base(x, y)
        {
            this.Width = width;
            this.Height = height;
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
            Width  *= coefficient;
            Height *= coefficient;
        }

        #endregion

        #region Helper methods

        public override void Print()
        {
            string figureInfo = $@"====================
Figure: Rectangle
Width = {Width}, Height = {Height}
A(x = {X},y = {Y})      B(x = {X + Width}, y = {Y})
C(x = {X},y = {Y - Height})     D(x = {X + Width}, y = {Y - Height})
====================";

            Console.WriteLine(figureInfo);
        }
        
        #endregion

    }
}
