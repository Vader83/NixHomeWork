using System;

namespace dotNET_HW_1.Model
{
    public abstract class CustomPoint
    {
        #region Properties and fields

        public double X { get; protected set; }
        public double Y { get; protected set; }

        #endregion

        #region Constructors

        protected CustomPoint()
        {
            X = 0d;
            Y = 0d;
        }

        protected CustomPoint(double x, double y)
        {
            X = x;
            Y = y;
        }

        #endregion

        #region Modify methods

        public abstract void Move(double dx, double dy);
        public abstract void Scale(double coefficient);
       
        #endregion
        
        #region Helper methods

        public abstract void Print();

        #endregion

    }
}
