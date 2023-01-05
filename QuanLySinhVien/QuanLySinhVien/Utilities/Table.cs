using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLySinhVien.Utilities
{
    public class Table
    {
        protected int tableWidth;
        protected int x;
        protected int y;

        #region Khởi tạo
        public Table(int width)
        {
            this.tableWidth = width;
        }
        #endregion

        #region Nối bảng đầu
        public void PrintHeadLine(int x, int y, int col)
        {
            Console.SetCursorPosition(x, y);
            int width = (tableWidth - col) / col;
            string row = "╔";
            for(int i=0;i<col;i++)
            {
                row += new string('═', width);
                row = i < col-1 ? row += "╦" : row += "╗"; 
            }
            Console.WriteLine(row);
        }
       
        #endregion

        #region Nối bảng giữa
        public void PrintBetweenLine(int x, int y,int col)
        {
            Console.SetCursorPosition(x, y);
            int width = (tableWidth - col) / col;
            string row = "╠";
            for (int i = 0; i < col; i++)
            {
                row += new string('═', width);
                row = i < col - 1 ? row += "╬" : row += "╣";
            }
            Console.WriteLine(row);
        }
        #endregion

        #region Nối bảng cuối
        public void PrintLastLine(int x, int y,int col)
        {
            Console.SetCursorPosition(x, y);
            int width = (tableWidth - col) / col;
            string row = "╚";
            for (int i = 0; i < col; i++)
            {
                row += new string('═', width);
                row = i < col - 1 ? row += "╩" : row += "╝";
            }
            Console.WriteLine(row);
        }
        #endregion

        #region Tiêu đề cột
        public void PrintTitle(int x,int y,params string[] columns)
        {
            Console.SetCursorPosition(x, y);
            int width = (tableWidth - columns.Length) / columns.Length;
            string row = "║";

            foreach (string column in columns)
            {
                row += AlignCentre(column, width) + "║";
            }
            Console.WriteLine(row);
        }
        #endregion

        #region In dòng
        public void PrintRow(int x, int y, params string[] columns)
        {
            Console.SetCursorPosition(x, y);
            int width = (tableWidth - columns.Length) / columns.Length;
            string row = "║";

            foreach (string column in columns)
            {
                row += AlignLeft(column, width) + "║";
            }
            Console.WriteLine(row);
        }

        public string StringPrintRow(int x, int y, params string[] columns)
        {
            Console.SetCursorPosition(x, y);
            int width = (tableWidth - columns.Length) / columns.Length;
            string row = "║";

            foreach (string column in columns)
            {
                row += AlignLeft(column, width) + "║";
            }
            return row;
            //Console.WriteLine(row);
        }
        #endregion

        #region In dòng có màu theo từ khóa
        public void PrintRowColorID(int x,int y, string id, params string[] columns)
        {
            Console.SetCursorPosition(x, y);
            int width = (tableWidth - columns.Length) / columns.Length;
            string row = "║";
            Console.Write(row);
            for (int i = 0; i < columns.Length; i++)
            {
                if (Invalid.SoSanh(columns[i], id))
               
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    row = AlignLeft(columns[i], width);
                    Console.Write(row);
                    Console.ResetColor();
                    Console.Write("║");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    row = AlignLeft(columns[i], width);
                    Console.Write(row);
                    Console.ResetColor();
                    Console.Write("║");
                }
            }
            Console.WriteLine();
        }
        #endregion

        #region In dòng có màu
        public void PrintRowColor(int x, int y, params string[] columns)
        {
            Console.SetCursorPosition(x, y);
            int width = (tableWidth - columns.Length) / columns.Length;
            string row = "║";
            Console.Write(row);
            for (int i = 0; i < columns.Length; i++)
            {

                Console.ForegroundColor = ConsoleColor.Red;
                row = AlignLeft(columns[i], width);
                Console.Write(row);
                Console.ResetColor();
                Console.Write("║");
            }
            Console.WriteLine();
        }
        #endregion
        
        #region In dòng bảng điểm
        //x môn => tiêu đề x+4 cột => dòng điểm 4x+4 cột
        //Widthrow = width * (x+4)
        //1 width = 4 width nhỏ => 1 width nhỏ = (widthrow - (width*4))
        //Độ rộng 1 cột là width: width(x+4) = widthtable;  width(4x+4)  = widthtable
        

        public void PrintRowSpecial(int x,int y,ConsoleColor color, params string[] columns)
        {
            Console.SetCursorPosition(x, y);
            int soCotTo = ((columns.Length - 4) / 4) + 4;
            int width1 = (tableWidth -soCotTo) / soCotTo;
            int width2 = (width1) / 4;
            string row = "║";
            Console.Write(row);
            for (int i = 0; i < columns.Length; i++)
            {

                if (i == 0 || i == 1)
                {
                   
                    row = AlignLeft(columns[i], width1);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write(row);
                    Console.ResetColor();
                    Console.Write("║");
                }
                else if (i == columns.Length - 1 || i == columns.Length - 2)
                {
                    row = AlignLeft(columns[i], width1);
                    Console.ForegroundColor = color;
                    Console.Write(row);
                    Console.ResetColor();
                    Console.Write("║");
                }
                else
                {
                    row = AlignLeft(columns[i], width2);
                    if (row.Trim() == "TL")
                    {
                        row = AlignLeft(columns[i], (width1 - width2 * 3) - 3);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(row);
                        Console.ResetColor();
                    }
                    else if (row.Trim() == "QM")
                    {
                        row = AlignLeft(columns[i],(width1-width2*3)-3);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(row);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(row);
                    }
                    Console.Write("║");
                }
            }
            Console.WriteLine();
        }
        #endregion

        #region Căn giữa 
        public string AlignCentre(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }
        #endregion

        #region Căn trái
        public string AlignLeft(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text + new string(' ', width - text.Length);
            }
        }
        #endregion
    }
}
