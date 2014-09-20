using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSRecursion
{
    class Program
    {
        public static IList<Node> nodes = null;
        static void Main(string[] args)
        {
            //A(,)
            //A(b,c)
            //A(b,c(d,e))
            string input = "A(b(c,d),e(f,g(h,i)))";

            //int len = input.Length;
            //foreach(var item in input.Split(',')){
            //    Console.Write(item);
            //}

            nodes = new List<Node>();
             RecursionNode(input);
            foreach (var item in nodes)
            {

                Console.WriteLine("Parent:{0},Left:{1},Right:{2}", item.Name, item.Left.Name, item.Right.Name);
            }
            //Console.Write(input.Substring(3,len-3));

            //Console.Write(input.Split(","));

            Console.Read();
        }
        static void RecursionNode2(string input) {
            Node node = new Node();
            int len = input.Length;
            int step = 0;
            char[] inputs = input.ToCharArray();
            char current = inputs[step];
            node.Name = current.ToString();
            char right1 = inputs[step+1];
            char right2 = inputs[step+2];
            char right3 = inputs[step + 3];
            if(right1 == '('){
                if(right2 == ','){
                    node.Left = new Node();
                    node.Left.Name = string.Empty;
                }
                if (right2 == ' ') { }
            }
        }
        static void RecursionNode(string input)
        {
            int step = 0;
            int len = input.Length;
            if (len < 4)
            {
                return;
            }

            char[] chars = input.ToCharArray();
            char curentChar = chars[step];
            char left = ' ';
            if (step != 0)
            {
                left = chars[step - 1];
            }
            char right = chars[step + 1];
            char right2 = chars[step + 2];
            Node node = null;
            if (right == '(')
            {
                node = new Node();
                node.Name = curentChar.ToString();
                if (right2 == ',')
                {
                    node.Left = new Node();
                    node.Left.Name = string.Empty;
                    if (chars[step + 3] == ')')
                    {
                        node.Right = new Node();
                        node.Right.Name = string.Empty;
                    }
                    else {
                        node.Right = new Node();
                        node.Right.Name = chars[step + 3].ToString();
                    }
                }
                else
                {
                    node.Left = new Node();
                    node.Left.Name = right2.ToString();
                    if (chars[step + 4] != ')')
                    {
                        node.Right = new Node();
                        node.Right.Name = chars[step + 4].ToString();
                    }
                    else
                    {
                        node.Right = new Node();
                        node.Right.Name = string.Empty;
                    }
                }
                nodes.Add(node);

                if(input.Length >=4){
                    input = input.Substring(step + 4, (len - (step + 4) - 1)); 
                    RecursionNode(input);
                }
                

               



            }
        }
    }
    class Node
    {
        public string Name { get; set; }

        public Node Left;
        public Node Right;
    }
}
