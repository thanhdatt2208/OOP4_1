using System;
using System.ComponentModel.Design;
using System.Drawing;
using System.Reflection.Metadata.Ecma335;

namespace OOP4_1
{
    public interface IPoint
    {
        double Cal_dist(IPoint point);
        void Show();
    }
    public interface ICircle
    {
        double Cal_area();
        void Show();
    }
    public class Point2D : IPoint
    {
        double x, y;

        public double X { get => x; set => x = value; }
        public double Y { get => y; set => y = value; }
        public Point2D()
        {
            x = 0;
            y = 0;
        }
        public Point2D (double x_, double y_)
        {
            x = x_;
            y = y_;
        }
        public double Cal_dist(IPoint point)
        {
            Point2D p = point as Point2D;
            if (p != null)
            return Math.Round(Math.Sqrt(Math.Pow(x - p.x, 2) + Math.Pow(y - p.y, 2)),2);
            return 0;
        }
        public void Show()
        {
            Console.WriteLine($"Diem 2D: ({x},{y})");
        }
    }
    public class Point3D : IPoint
    {
        double x, y, z;

        public double X { get => x; set => x = value; }
        public double Y { get => y; set => y = value; }
        public double Z { get => z; set => z = value; }
        public Point3D()
        {
            x = 0;
            y = 0;
            z = 0;
        }
        public Point3D(double x_, double y_, double z_)
        {
            x = x_;
            y = y_;
            z = z_;
        }
        public double Cal_dist(IPoint point)
        {
            Point3D p = point as Point3D;
            if (p != null)
            {
                return Math.Round(Math.Sqrt(Math.Pow(x - p.x, 2) + Math.Pow(y - p.y, 2) + Math.Pow(z - p.z, 2)), 2); }
            return 0;
        }
        public void Show()
        {
            Console.WriteLine($"Diem 3D: ({x},{y},{z})");
        }
    }
    public class Circle2D : ICircle
    {
        public Point2D center;
        public float radius;
        public Point2D Center { get => center; set => center = value; }
        public float Radius { get => radius; set => radius = value; }
        public Circle2D()
        {
            center = new Point2D(0, 0);
            radius = 0;
        }
        public Circle2D(Point2D center_, float radius_)
        {
            center = center_;
            radius = radius_;
        }
        public double Cal_area()
        {
            return Math.Round(Math.PI * (float)Math.Pow(radius, 2),2);
        }
        public void Show()
        {
            Console.WriteLine($"Ban kinh 2D: {radius}");
        }
    }
    public class Circle3D : ICircle
    {
        public Point3D center;
        public float radius;
        public Point3D Center { get => center; set => center = value; }
        public float Radius { get => radius; set => radius = value; }
        public Circle3D()
        {
            center = new Point3D(0, 0, 0);
            radius = 0;
        }
        public Circle3D(Point3D center_, float radius_)
        {
            center = center_;
            radius = radius_;
        }
        public double Cal_area()
        {
            return Math.Round(4 * Math.PI * (float)Math.Pow(radius, 2),2);
        }
        public void Show()
        {
            Console.WriteLine($"Ban kinh 3D: {radius}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Point2D p1 = new Point2D(2, 5);
            Point2D p2 = new Point2D(4, 1);
            double dist = p1.Cal_dist(p2);
            Circle2D c1 = new Circle2D(p1,5);
            p1.Show();
            p2.Show();
            Console.WriteLine("Khoang cach 2 diem do: " + dist);
            double area = c1.Cal_area();
            c1.Show();
            Console.WriteLine("Dien tich: " + area);
            Point3D pa = new Point3D(3, 4, 5);
            Point3D pb = new Point3D(6, 2, 4);
            double dist2 = pa.Cal_dist(pb);
            Circle3D ca = new Circle3D(pa, 7);
            Console.WriteLine();
            pa.Show() ;
            pb.Show() ;
            Console.WriteLine($"Khoang cach 2 diem do: "+ dist2);
            double area2 = ca.Cal_area();
            ca.Show() ;
            Console.WriteLine("Dien tich: "+ area2);
            Console.WriteLine();
            Console.WriteLine("Cac diem ngau nhien da tao:");
            Random rand = new Random();
            IPoint[] points = new IPoint[5];
            for (int i = 0; i < points.Length; i++)
            {
                if (rand.Next(2) == 0)
                {
                    points[i] = new Point2D(rand.Next(-10,10),rand.Next(-10,10));

                }
                else
                {
                    points[i] = new Point3D(rand.Next(-10, 10), rand.Next(-10, 10), rand.Next(-10, 10));
                }
            }
            foreach (var point in points)
            {
                point.Show();
            }
            Console.WriteLine();
            Console.WriteLine("Cac ban kinh ngau nhien da tao: ");
            ICircle[] circles = new ICircle[5];
            for (int i = 0; i < circles.Length; i++)
            {

                int index = rand.Next(points.Length);
                IPoint selectedPoint = points[index];
                if (selectedPoint is Point2D center2D)
                {
                    double radius = rand.Next(1, 20);
                    circles[i] = new Circle2D(center2D, (float)radius);
                }
                else if (selectedPoint is Point3D center3D)
                {
                    double radius = rand.Next(1, 20);
                    circles[i] = new Circle3D(center3D, (float)radius);
                }
            }
            foreach (var circle in circles)
            {
                circle.Show();
            }
            for (int i = 0; i < points.Length; i++)
            {
                for (int j = i + 1; j < points.Length; j++)
                {
                    if (points[i].GetType() == points[j].GetType())
                    {
                        Console.WriteLine("\nSo sanh 2 diem cung loai: ");
                        points[i].Show();
                        points[j].Show();
                        double distance = points[i].Cal_dist(points[j]);
                        Console.WriteLine($"Khoang cach 2 diem do: " + distance);
                    }
                }
            }
            Console.WriteLine();
            for (int i = 0; i < circles.Length; i++)
            {
                if (circles[i] is Circle2D center2D)
                {
                    double area2D = circles[i].Cal_area();
                    Console.WriteLine("Circle 2D: " + area2D); 
                }
                else if (circles[i] is Circle3D center3D)
                {
                    double area3D = circles[i].Cal_area();
                    Console.WriteLine("Circle 3D: " + area3D);
                }
            }
        }
    }
}