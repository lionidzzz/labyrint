using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace labirint
{
    class Program
    {
       
        class Point
        {
            bool north = false;
            bool west = false;
            bool south = false;
            bool east = false;
            public int x, y;

            public Point(int a, int b)
            {
                x = a;
                y = b;
            }

            public bool North
            {
                get { return north; }
                set { north = value; }
            }

            public bool South
            {
                get { return south; }
                set { south = value; }
            }

            public bool West
            {
                get { return west; }
                set { west = value; }
            }

            public bool East
            {
                get { return east; }
                set { east = value; }
            }

        }


        static string reverse_step(string step)
        {
            if (step == "w") step = "e";

            else if (step == "e") step = "w";

            else if (step == "s") step = "n";

            else if (step == "n") step = "s";

            return step;
        }


        static string Turn(string w, char p)
        {
            if (w == "w")
            {
                if (p == 'L') w = "s";

                if (p == 'R') w = "n";
            }

            else if (w == "n")
            {
                if (p == 'L') w = "w";

                if (p == 'R') w = "e";
            }

            else if (w == "s")
            {
                if (p == 'L') w = "e";

                if (p == 'R') w = "w";
            }

            else
            {
                if (p == 'L') w = "n";

                if (p == 'R') w = "s";
            }

            return w;
        }


        static string transfer(Point a)
        {
            char[] rov = { '0', '0', '0', '0' };
            if (a.North == true)
                rov[3] = '1';
            if (a.East == true)
                rov[0] = '1';
            if (a.West == true)
                rov[1] = '1';
            if (a.South == true)
                rov[2] = '1';

            string c = "s";
            int num = 0;
            int step1 = 0;

            for (int i = 3; i >= 0; i--)
            {
                if (rov[i] == '1')
                {
                    num = num + (int)Math.Pow(2, step1);
                }
                step1++;
            }

            if (num <= 9) c = num.ToString();
            else if (num == 10) c = "a";
            else if (num == 11) c = "b";
            else if (num == 12) c = "c";
            else if (num == 13) c = "d";
            else if (num == 14) c = "e";
            else if (num == 15) c = "f";

            return c;
        }


        static void Main(string[] args)
        {

            //string path = "WRWWLWWLWWLWLWRRWRWWWRWWRWLW";
            //string repath = "WWRRWLWLWWLWWLWWRWWRWWLW";
            string zz = "";
            int ma = 1;
            string path = "";
            string repath = "";

            string[] line = File.ReadAllLines(@"large-test.in.txt", Encoding.Default);
           


            int kol_vo_str = Convert.ToInt32(line[0]);

            while (kol_vo_str != 0) 
            {
                for (int m = 1; m <= kol_vo_str ; m++)
                {
                                               
                String[] world =line[m].Split(new char []{' '}, StringSplitOptions.RemoveEmptyEntries);
                path = world[0];
                       repath=world[1];
        
            int x = 10;
            int y = 10;

            List<Point> poin = new List<Point>();
            Point first = new Point(x, y);
            first.North = true;
            poin.Add(first);
            int xmax = x;
            int ymax = y;
            int xmin = x;
            int ymin = y;
            string w = "s";

            for (int i = 1; i < path.Length; i++)
            {
                Point point = new Point(x, y);
                foreach (Point l in poin)
                {
                    if (l.x == x && l.y == y)
                    {
                        if (xmin > x) xmin = x;
                        if (ymin > y) ymin = y;
                        if (xmax < x) xmax = x;
                        if (ymax < y) ymax = y;
                        point = l;
                        poin.Remove(l);
                        break;
                    }
                   

                }
                char p = path[i];
                w = Turn(w, p);


                if (p == 'W')
                {
                    if (w == "w")
                    {
                        point.West = true;
                        if (i != path.Length - 1)
                            x = x - 1;
                    }
                    else if (w == "n")
                    {
                        point.North = true;
                        if (i != path.Length - 1)
                            y = y + 1;
                    }
                    else if (w == "e")
                    {
                        point.East = true;
                        if (i != path.Length - 1)
                            x = x + 1;
                    }
                    else if (w == "s")
                    {
                        point.South = true;
                        if (i != path.Length - 1)
                            y = y - 1;
                    }
                    if (xmin > x) xmin = x;
                    if (ymin > y) ymin = y;
                    if (xmax < x) xmax = x;
                    if (ymax < y) ymax = y;
                }
                poin.Add(point);

            }

            w = reverse_step(w);

            for (int i = 1; i < repath.Length; i++)
            {
                Point point = new Point(x, y);
                foreach (Point l in poin)
                {
                    if (l.x == x && l.y == y)
                    {
                        if (xmin > x) xmin = x;
                        if (ymin > y) ymin = y;
                        if (xmax < x) xmax = x;
                        if (ymax < y) ymax = y;
                        point = l;
                        poin.Remove(l);
                        break;
                    }
                    
                }
                    char p = repath[i];
                    w = Turn(w, p);


                    if (p == 'W')
                    {
                        if (w == "w")
                        {
                            point.West = true;
                            x = x - 1;
                        }
                        else if (w == "n")
                        {
                            point.North = true;
                            y = y + 1;
                        }
                        else if (w == "e")
                        {
                            point.East = true;
                            x = x + 1;
                        }
                        else if (w == "s")
                        {
                            point.South = true;
                            y = y - 1;
                        }
                        if (xmin > x) xmin = x;
                        if (ymin > y) ymin = y;
                        if (xmax < x) xmax = x;
                        if (ymax < y) ymax = y;
                    }
                    poin.Add(point);

                }
                int curx = xmin;

                int cury = ymax - 1;
                string[] maze = new string[Math.Abs(ymax - ymin)];
                for (int j = 0; j < Math.Abs(ymax - ymin); j++)
                {
                    for (int k = 0; k <= Math.Abs(xmax - xmin); k++)
                    {
                        foreach (Point l in poin)
                        {
                            if (l.x == curx && l.y == cury)
                            {
                                maze[j] = maze[j] + transfer(l);
                                break;
                            }


                        }
                        curx = curx + 1;
                    }
                    cury = cury - 1;
                    curx = xmin;
                }

                zz += "Case#" + ma + "\r\n";
                for (int j = 0; j < Math.Abs(ymax - ymin); j++)
                {
                    
                        zz += maze[j] + "\r\n";
                        Console.WriteLine("Запись в файл");
            
                }
                ma++;
            }

                kol_vo_str--;
            }
            File.WriteAllText(@"large-test.out.txt", zz);
            Console.ReadKey();
            }
        }
    }