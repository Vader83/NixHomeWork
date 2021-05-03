using System;
using dotNET_HW_1.Model;


namespace dotNET_HW_1
{
    class Program
    {
        static void Main(string[] args)
        {

            CustomPicture Desk = new CustomPicture();

            Desk.Print();
            Desk.Add(new CustomRectangle());
            Desk.Print();
           
            Desk.Add(new CustomCircle());
            Desk.Add(new CustomTriangle());
            Desk.Add(new CustomRectangle(4d, 9d, 10d, 5.5d));
            Desk.Add(new CustomCircle(-5.6d, 2d, 7.8d));
            Desk.Add(new CustomTriangle(4d, 5d, 7d, 7d, 10d, -8d));
            Desk.Print();
            
            Desk.Move(5d,5d);
            Desk.Print();

            Desk.Scale(0.5d);
            Desk.Print();

            Desk.Remove(Desk.FigureStorage[0]);
            Desk.RemoveByIndex(2);
            Desk.Print();
        }
    }
}
