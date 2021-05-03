using System;
using System.Collections.Generic;

namespace dotNET_HW_1.Model
{
    class CustomPicture : CustomPoint
    {
        #region Properties and fields

        public readonly List<CustomPoint> FigureStorage;

        #endregion

        #region Constructors

        public CustomPicture()
        {
            FigureStorage = new List<CustomPoint>();
        }

        #endregion

        #region Figure methods

        public override void Move(double dx, double dy)
        {
            foreach (var item in FigureStorage)
            {
                item.Move(dx, dy);
            }
        }

        public override void Scale(double coefficient)
        {
            foreach (var item in FigureStorage)
            {
                item.Scale(coefficient);
            }
        }

        #endregion
        
        #region Storage methods

        public void Add(CustomPoint newFigure) => FigureStorage.Add(newFigure);

        public void RemoveByIndex(int index) => FigureStorage.RemoveAt(index);

        public void Remove(CustomPoint figure) => FigureStorage.Remove(figure);

        public override void Print()
        {
            foreach (var item in FigureStorage)
            {
                Console.WriteLine("\n" +
                                  $"====_Figure {FigureStorage.IndexOf(item)}_====");
                item.Print();
            }
        }
        #endregion


    }
}
