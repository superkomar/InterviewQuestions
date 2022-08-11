using System;

namespace Core
{
    public interface IChangePoint
    {
        void Change(int x, int y);
    }

    public struct Point : IChangePoint
    {
        private int _x;
        private int _y;

        public Point(int x, int y) { _x = x; _y = y; }

        public void Change(int x, int y) { _x = x; _y = y; }

        public override string ToString() => $"({_x}, {_y})";
    }

    public class CurrentInfo
    {
        public CurrentInfo(Point point) { CurrentPoint = point; }

        public Point CurrentPoint { get; }
    }

    public sealed class Program
    {
        public static void Main()
        {
            var info = new CurrentInfo(new Point(1, 1));

            ChangeCurrentPoint(info);

            Console.WriteLine($"Final result: {info.CurrentPoint}");
        }

        public static void ChangeCurrentPoint(CurrentInfo info)
        {
            Point p = info.CurrentPoint;
            Console.WriteLine($"1) {p}");

            p.Change(2, 2);
            Console.WriteLine($"2) {p}");

            object o = p;
            Console.WriteLine($"3) {o}");

            ((Point)o).Change(3, 3);
            Console.WriteLine($"4) {o}");

            ((IChangePoint)p).Change(4, 4);
            Console.WriteLine($"5) {p}");

            ((IChangePoint)o).Change(5, 5);
            Console.WriteLine($"6) {o}");

            info.CurrentPoint.Change(-10, -10);
            Console.WriteLine($"7) {info.CurrentPoint}");
        }
    }
}
