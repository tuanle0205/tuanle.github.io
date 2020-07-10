using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserSettingsDemo.Properties;
using System.Xml;
using System.IO;

namespace WindowsFormsApp1
{

    public partial class Form1 : Form
    {
        
        Boolean rela = false;
        int p = 0;
        
        int txtX, txtY;
        int cLeft = 4;
        int dLeft = 1;
        int bLeft = 4;
        int Cen = 1;
        int x = 3;
        int y = 0;
        int z = 0;
        int[] A = new int[10000];
        Pen blackpen = new Pen(Color.Black, 2);
        int x1, x2, y1, y2;
        string a;
        private Point _origin = Point.Empty;
        private Point _terminus = Point.Empty;
     
        private PictureBox pictureBox1 = new PictureBox();
        private List<Point> _bmp = new List<Point>();
        private Bitmap bmp;
        private Point currentBitmap;
        private Point point1;
        private Point point2;
        private Point previousBitmap;
        private DrawNote drawNote;
        private DrawNote drawNote1;
        DataTable tble = new DataTable("tbl");
        DataTable tble1 = new DataTable();
        DataColumn dtColumn;
        DataRow myDataRow;
        
        string filename = "";
        string theText;
        
        public Form1()
        {
            InitializeComponent();
            textBox1.Tag = "3";
            textBox2.Tag = "3";
            textBox3.Tag = "3";
            textBox4.Tag = "3";
            txtX = 0;
            txtY = 0;
            for (int i = 0; i < A.Length; i++)
                A[i] = 1;
            bmp = new Bitmap(panel2.ClientSize.Width, panel2.ClientSize.Width, panel2.CreateGraphics());
            CreateTable();



        }
        public void CreateTable()
        {
           

            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(string);
            dtColumn.ColumnName = "Name";
            dtColumn.Caption = "txt Name";
            dtColumn.ReadOnly = false;
            dtColumn.Unique = false;
            tble.Columns.Add(dtColumn);
            
            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(string);
            dtColumn.ColumnName = "Text";
            dtColumn.Caption = "txt Text";
            dtColumn.ReadOnly = false;
            dtColumn.Unique = false;
            tble.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(int);
            dtColumn.ColumnName = "Location X";
            dtColumn.Caption = "txt Location X";
            dtColumn.ReadOnly = false;
            dtColumn.Unique = false;
            tble.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(int);
            dtColumn.ColumnName = "Location Y";
            dtColumn.Caption = "txt Location Y";
            dtColumn.ReadOnly = false;
            dtColumn.Unique = false;
            tble.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(int);
            dtColumn.ColumnName = "Height";
            dtColumn.Caption = "txt Height";
            dtColumn.ReadOnly = false;
            dtColumn.Unique = false;
            tble.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(int);
            dtColumn.ColumnName = "Width";
            dtColumn.Caption = "txt Width";
            dtColumn.ReadOnly = false;
            dtColumn.Unique = false;
            tble.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(int);
            dtColumn.ColumnName = "x1";
            dtColumn.Caption = "x1";
            dtColumn.ReadOnly = false;
            dtColumn.Unique = false;
            tble.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(int);
            dtColumn.ColumnName = "y1";
            dtColumn.Caption = "y1";
            dtColumn.ReadOnly = false;
            dtColumn.Unique = false;
            tble.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(int);
            dtColumn.ColumnName = "x2";
            dtColumn.Caption = "x2";
            dtColumn.ReadOnly = false;
            dtColumn.Unique = false;
            tble.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(int);
            dtColumn.ColumnName = "y2";
            dtColumn.Caption = "y2";
            dtColumn.ReadOnly = false;
            dtColumn.Unique = false;
            tble.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(Font);
            dtColumn.ColumnName = "Font";
            dtColumn.Caption = "Font";
            dtColumn.ReadOnly = false;
            dtColumn.Unique = false;
            tble.Columns.Add(dtColumn);

        }
      

        public System.Windows.Forms.TextBox AddNewTextBox()
        {
            x = x + 1;
            x1 = 350;
            y1 = 170;
            System.Windows.Forms.TextBox txt = new System.Windows.Forms.TextBox(); //Khởi tạo đối tượng Textbox có tên là txt
            panel2.Controls.Add(txt);  //Thêm đối tượng txt vào Form
            txt.Top = cLeft * 25; //Thiết lập thuộc tính Top
            txt.Left = 200; //Thiết lập thuộc tính Left
            txt.Text = "Main Topic " + this.cLeft.ToString(); //Thiết lập thuộc tính Text cho Textbox
            txt.TextAlign = HorizontalAlignment.Center;
            txt.Name = this.x.ToString();
            txt.Multiline = true;
            txt.WordWrap = true;
            txt.TextChanged += multiline;
            txt.Tag = "0";
            x2 = 300;
            y2 = cLeft * 25 + 10;
            cLeft = cLeft + 1;
            txt.Click += mybutton_click;
            Graphics g = panel2.CreateGraphics();
            txt.TextChanged += textBox_TextChanged;
            g.DrawLine(blackpen, x1, y1, x2, y2);
            g.DrawLine(blackpen, 463, 170, 499, 90);
            g.DrawLine(blackpen, 463, 170, 499, 170);
            g.DrawLine(blackpen, 463, 170, 499, 251);
            point1.X = x1;
            point1.Y = y1;
            point2.X = x2;
            point2.Y = y2;
            
            txt.MultilineChanged += multiline;
            previousBitmap.X = x2;
            previousBitmap.Y = y2;
            _bmp.Add(point1);
            _bmp.Add(point2);
           
           
            
          
            
            
            return txt;
            


        }
        private void mybutton_click(object sender, EventArgs e)
        {
            Cen = 0;
            TextBox txt1 = sender as TextBox;
            a = txt1.Name;
            txtX = txt1.Left;
            txtY = txt1.Top;
        }
        private void mybutton1_click(object sender, EventArgs e)
        {
            Cen = 4;
            TextBox txt1 = sender as TextBox;
            a = txt1.Name;
            txtX = txt1.Left;
            txtY = txt1.Top;
        }
        private void multiline(object sender, EventArgs e)
        {   
            TextBox a = sender as TextBox;
            var lines = a.Lines.Where(line => !String.IsNullOrWhiteSpace(line)).Count();
            if (TextRenderer.MeasureText(a.Text, a.Font).Width > a.Width)
                lines += 2;
                a.Height = (a.Font.Height + 2) * lines +5;
            
        }
        public System.Windows.Forms.TextBox AddNewTextBox1()
        {   
            
            y = y + 1;
            System.Windows.Forms.TextBox txt = new System.Windows.Forms.TextBox(); //Khởi tạo đối tượng Textbox có tên là txt
            panel2.Controls.Add(txt);  //Thêm đối tượng txt vào Form
            txt.Top = int.Parse(a) * 25; //Thiết lập thuộc tính Top
            txt.TextAlign = HorizontalAlignment.Center;
            
            if (A[int.Parse(a)] == 1)
            {
                txt.Left = 85 ; //Thiết lập thuộc tính Left
            }
            else
            {
                txt.Left = 85 - (A[int.Parse(a)] - 1) * 110;
            }
            txt.Text = "Sub Topic " + this.A[int.Parse(a)].ToString(); //Thiết lập thuộc tính Text cho Textbox
            txt.Name = this.y.ToString();
            txt.Tag = "1";
            A[int.Parse(a)] = A[int.Parse(a)] + 1;
            dLeft += 1;
            txt.Multiline = true;
            txt.WordWrap = true;
            txt.TextChanged += multiline;
            txt.Click += mybutton1_click;
            txt.Multiline = true;
            Point p = new Point(txt.Left, txt.Top);
            Graphics g = panel2.CreateGraphics();
            g.DrawLine(blackpen, 463, 170, 499, 90);
            g.DrawLine(blackpen, 463, 170, 499, 170);
            g.DrawLine(blackpen, 463, 170, 499, 251);
            point1.X = txt.Right;
            point1.Y = txt.Top + 10;
            point2.X = txt.Left + 130;
            point2.Y = txt.Top + 10;
            g.DrawLine(blackpen, txt.Right, txt.Top + 10, txt.Left + 130,txt.Top+10);

          


            _bmp.Add(point1);
            _bmp.Add(point2);
            
            panel2.DrawToBitmap(bmp, panel2.ClientRectangle);
            return txt; //Trả lại đối tượng txt với các thuộc tính kèm theo
            
        }

        public System.Windows.Forms.TextBox AddNewTextBox2()
        {
            y = y + 1;
            System.Windows.Forms.TextBox txt = new System.Windows.Forms.TextBox(); //Khởi tạo đối tượng Textbox có tên là txt
            panel2.Controls.Add(txt);  //Thêm đối tượng txt vào Form
            txt.Top = int.Parse(a) * 80; //Thiết lập thuộc tính Top
            txt.Multiline = true;
            txt.TextAlign = HorizontalAlignment.Center;
            txt.Tag = "2";
            txt.Name = this.y.ToString();
            txt.Click += mybutton1_click;
            if (A[int.Parse(a)] == 1)
            {
                txt.Left = 620; //Thiết lập thuộc tính Left
            }
            else
            {
                txt.Left = 620 + (A[int.Parse(a)]-1) * 110;
            }
            txt.Text = "Sub Topic " + this.A[int.Parse(a)].ToString(); //Thiết lập thuộc tính Text cho Textbox
            A[int.Parse(a)] = A[int.Parse(a)] + 1;
            dLeft = dLeft + 1;
            bLeft = bLeft + 1;
            Graphics g = panel2.CreateGraphics();
            txt.Multiline = true;
            txt.WordWrap = true;
            txt.TextChanged += multiline;
            
            g.DrawLine(blackpen, 463, 170, 499, 90);
            g.DrawLine(blackpen, 463, 170, 499, 170);
            g.DrawLine(blackpen, 463, 170, 499, 251);
            g.DrawLine(blackpen, txt.Left, txt.Top + 10, txt.Left - 120, txt.Top + 10);
           
            point1.X = txt.Left;
            point1.Y = txt.Top + 10;
            point2.X = txt.Left - 120;
            point2.Y = txt.Top + 10;
          
            
            

            _bmp.Add(point1);
            _bmp.Add(point2);
            
            panel2.DrawToBitmap(bmp, panel2.ClientRectangle);
            return txt; //Trả lại đối tượng txt với các thuộc tính kèm theo

        }
        public System.Windows.Forms.TextBox AddNewTextBox3()
        {
            y = y + 1;
            System.Windows.Forms.TextBox txt = new System.Windows.Forms.TextBox(); //Khởi tạo đối tượng Textbox có tên là txt
            panel2.Controls.Add(txt);  //Thêm đối tượng txt vào Form
            txt.Top = txtY; //Thiết lập thuộc tính Top
            txt.Multiline = true;
            txt.WordWrap = true;
            txt.TextChanged += multiline;
            txt.Click += mybutton1_click;
            txt.TextAlign = HorizontalAlignment.Center;
            txt.Name = this.y.ToString();
            Graphics g = panel2.CreateGraphics();
            txt.Text = "Sub Topic " + this.A[int.Parse(a)].ToString(); //Thiết lập thuộc tính Text cho Textbox
            A[int.Parse(a)] = A[int.Parse(a)] + 1;
            if (txtX > textBox1.Left)
            {
                txt.Left = txtX + 120;
                txt.Tag = "2";
            }
            else
            {
                txt.Tag = "1";
                txt.Left = txtX - 120;
            }

         


          
            g.DrawLine(blackpen, txt.Left, txt.Top + 10, txtX, txt.Top + 10);

            point1.X = txt.Left;
            point1.Y = txt.Top + 10;
            point2.X = txtY;
            point2.Y = txt.Top + 10;




            _bmp.Add(point1);
            _bmp.Add(point2);

            panel2.DrawToBitmap(bmp, panel2.ClientRectangle);
            return txt; //Trả lại đối tượng txt với các thuộc tính kèm theo

        }


        private void button2_Click(object sender, EventArgs e)
            {
            if (Cen == 1)
            {
                AddNewTextBox();

            }
            else if (Cen == 2)
            {
                AddNewTextBox2();

            }
            else if (Cen == 0)
            { AddNewTextBox1(); }

            else
            {
                AddNewTextBox3();
            }
            }

            private void textBox1_Click(object sender, EventArgs e)
            {
                Cen = 1;
            txtX = textBox1.Left;
            txtY = textBox1.Top;
            }

        private void button1_Click(object sender, EventArgs e)
        {
            AddNewTextBox();
           
        }

        private void panel2_AutoSizeChanged(object sender, EventArgs e)
        {
            if (bmp is null) return;
            bmp.Dispose();
            bmp = new Bitmap(panel2.ClientSize.Width, panel2.ClientSize.Width, panel2.CreateGraphics());

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(blackpen, textBox1.Right, textBox1.Top +10, textBox2.Left, textBox2.Top +10);
            e.Graphics.DrawLine(blackpen, textBox1.Right, textBox1.Top + 10, textBox3.Left, textBox3.Top + 10);
            e.Graphics.DrawLine(blackpen, textBox1.Right, textBox1.Top + 10, textBox4.Left, textBox4.Top + 10);
            if (_bmp.Count < 2)
            {
                return;
            }

           

            for (int i = 0; i < _bmp.Count; i+=2)
            {
                currentBitmap = _bmp[i+1];
                previousBitmap = _bmp[i];
                e.Graphics.DrawLine(blackpen, previousBitmap, currentBitmap);
                previousBitmap = currentBitmap;
                
                
            }

        }

     
       

        private void panel2_ClientSizeChanged(object sender, EventArgs e)
        {
            if (bmp is null) return;
            bmp.Dispose();
            bmp = new Bitmap(panel2.ClientSize.Width, panel2.ClientSize.Width, panel2.CreateGraphics());
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                theText = textBox.Text;
            }
            z = 1;
        }

        private void textBox1_MultilineChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            multiline(textBox1, e);
        }

        public static void ConvertCSVtoDataTable(DataTable dt, string strFilePath)
        {
            
            using (StreamReader sr = new StreamReader(strFilePath))
            {
                string[] headers = sr.ReadLine().Split(',');
                foreach (string header in headers)
                {
                    dt.Columns.Add(header);
                }
                while (!sr.EndOfStream)
                {
                    string[] rows = sr.ReadLine().Split(',');
                    DataRow dr = dt.NewRow();
                    for (int i = 0; i < headers.Length; i++)
                    {
                        dr[i] = rows[i];
                        
                       
                    }
                    dt.Rows.Add(dr);
                    
                    
                }

            }
            
            
        }

       

        private void panel2_Resize(object sender, EventArgs e)
        {
            if (bmp is null) return;
            bmp.Dispose();
            bmp = new Bitmap(panel2.ClientSize.Width, panel2.ClientSize.Width, panel2.CreateGraphics());


        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            multiline(textBox2, e);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            multiline(textBox3, e);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            multiline(textBox4, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            rela = true;
            
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            drawNote = new DrawNote();
            
            drawNote.X = e.X;
            drawNote.Y = e.Y;
            
            if (rela == true)
            {
                System.Windows.Forms.TextBox txt = new System.Windows.Forms.TextBox(); //Khởi tạo đối tượng Textbox có tên là txt
                panel2.Controls.Add(txt);  //Thêm đối tượng txt vào Form
                p += 1;
                txt.Top = drawNote.Y - 10;
                txt.Left = drawNote.X - 50;
                rela = false;
                txt.Multiline = true;
                txt.WordWrap = true;
                txt.TextChanged += multiline;
                txt.Text = "Float Topic " + this.p.ToString();
                txt.Tag = "4";
                txt.TextAlign = HorizontalAlignment.Center;
                txt.TextChanged += multiline;
                drawNote.isDraw = true; 
                Graphics g = panel2.CreateGraphics();
                if (txtX != 0 && txtY != 0)
                {
                   
                    if (txt.Top < txtY)
                       {
                        myDataRow = tble.NewRow();
                        point1.X = txt.Left +40;
                        point1.Y = txt.Bottom;
                        point2.X = txtX + 40;
                        point2.Y = txtY + 10;
                        
                        myDataRow["Name"] = txt.Name;
                        myDataRow["Text"] = txt.Text;
                        myDataRow["Location X"] = txt.Left;
                        myDataRow["Location Y"] = txt.Top;
                        myDataRow["Width"] = txt.Width;
                        myDataRow["Height"] = txt.Height;
                        myDataRow["Font"] = txt.Font;
                        myDataRow["x1"] = txt.Left + 40;
                        myDataRow["y1"] = txt.Bottom;
                        myDataRow["x2"] = txtX + 40;
                        myDataRow["y2"] = txtY + 10;
                        tble.Rows.Add(myDataRow);
                        _bmp.Add(point1);
                        _bmp.Add(point2);

                        g.DrawLine(blackpen, txt.Left + 40, txt.Bottom, txtX + 40, txtY + 10);
                        }
                        else
                    {
                        myDataRow = tble.NewRow();
                        point1.X = txt.Left + 40;
                        point1.Y = txt.Top;
                        point2.X = txtX + 40;
                        point2.Y = txtY + 10;
                        myDataRow = tble.NewRow();
                        myDataRow["Name"] = txt.Name;
                        myDataRow["Text"] = txt.Text;
                        myDataRow["Location X"] = txt.Left;
                        myDataRow["Location Y"] = txt.Top;
                        myDataRow["Width"] = txt.Width;
                        myDataRow["Height"] = txt.Height;
                        myDataRow["Font"] = txt.Font;
                        myDataRow["x1"] = txt.Left + 40;
                        myDataRow["y1"] = txt.Top;
                        myDataRow["x2"] = txtX + 40;
                        myDataRow["y2"] = txtY + 10;
                        tble.Rows.Add(myDataRow);

                        _bmp.Add(point1);
                        _bmp.Add(point2);

                          g.DrawLine(blackpen, txt.Left + 40, txt.Top, txtX + 40, txtY + 10);
                    }

                    


                }
               
                txtX = 0;
                txtY = 0;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 NewForm = new Form1();
            NewForm.Show();
            this.Dispose(false);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SaveFileDialog SaveFileDialog1 = new SaveFileDialog();
            foreach (TextBox txt in panel2.Controls.OfType<TextBox>())
            {
                if (txt.Tag != "4")
                {
                    myDataRow = tble.NewRow();
                    myDataRow["Name"] = txt.Name;
                    myDataRow["Text"] = txt.Text;
                    myDataRow["Location X"] = txt.Left;
                    myDataRow["Location Y"] = txt.Top;
                    myDataRow["Width"] = txt.Width;
                    myDataRow["Height"] = txt.Height;
                    myDataRow["Font"] = txt.Font;
                    if (txt.Tag == "0")
                    {
                        myDataRow["x1"] = x1;
                        myDataRow["y1"] = y1;
                        myDataRow["x2"] = x2;
                        myDataRow["y2"] = txt.Top + 10;

                    }
                    else if (txt.Tag == "2")
                    {
                        myDataRow["x1"] = txt.Left;
                        myDataRow["y1"] = txt.Top + 10;
                        myDataRow["x2"] = txt.Left - 120;
                        myDataRow["y2"] = txt.Top + 10;

                    }
                    else if (txt.Tag == "1")
                    {
                        myDataRow["x1"] = txt.Right;
                        myDataRow["y1"] = txt.Top + 10;
                        myDataRow["x2"] = txt.Left + 130;
                        myDataRow["y2"] = txt.Top + 10;
                    }
                    else if (txt.Tag == "3")
                    {
                        myDataRow["x1"] = 0;
                        myDataRow["y1"] = 0;
                        myDataRow["x2"] = 0;
                        myDataRow["y2"] = 0;
                    }
                    tble.Rows.Add(myDataRow);
                }

            }


            if (File.Exists(SaveFileDialog1.FileName))
            {
                File.Delete(SaveFileDialog1.FileName);
            };
            if (filename == "")
            {
                SaveFileDialog1.Filter = "csv files (*.csv)|*.csv";
                SaveFileDialog1.FilterIndex = 2;

                if (SaveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    filename = SaveFileDialog1.FileName;
                    using (StreamWriter sw = new StreamWriter(SaveFileDialog1.FileName))
                    {
                        for (int i = 0; i < tble.Columns.Count; i++)
                        {
                            sw.Write(tble.Columns[i]);
                            if (i < tble.Columns.Count - 1)
                            {
                                sw.Write(",");
                            }
                        }
                        sw.Write(sw.NewLine);
                        foreach (DataRow dr in tble.Rows)
                        {
                            for (int i = 0; i < tble.Columns.Count; i++)
                            {
                                if (!Convert.IsDBNull(dr[i]))
                                {
                                    string value = dr[i].ToString();
                                    if (value.Contains(','))
                                    {
                                        value = String.Format("\"{0}\"", value);
                                        sw.Write(value);
                                    }
                                    else
                                    {
                                        sw.Write(dr[i].ToString());
                                    }
                                }
                                if (i < tble.Columns.Count - 1)
                                {
                                    sw.Write(",");
                                }
                            }
                            sw.Write(sw.NewLine);

                        }
                    }
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SaveFileDialog SaveFileDialog1 = new SaveFileDialog();
            foreach (TextBox txt in panel2.Controls.OfType<TextBox>())
            {   
                if (txt.Tag != "4")
                {
                    myDataRow = tble.NewRow();
                    myDataRow["Name"] = txt.Name;
                    myDataRow["Text"] = txt.Text;
                    myDataRow["Location X"] = txt.Left;
                    myDataRow["Location Y"] = txt.Top;
                    myDataRow["Width"] = txt.Width;
                    myDataRow["Height"] = txt.Height;
                    myDataRow["Font"] = txt.Font;
                    if (txt.Tag == "0")
                    {
                        myDataRow["x1"] = x1;
                        myDataRow["y1"] = y1;
                        myDataRow["x2"] = x2;
                        myDataRow["y2"] = txt.Top + 10;

                    }
                    else if (txt.Tag == "2")
                    {
                        myDataRow["x1"] = txt.Left;
                        myDataRow["y1"] = txt.Top + 10;
                        myDataRow["x2"] = txt.Left - 120;
                        myDataRow["y2"] = txt.Top + 10;

                    }
                    else if (txt.Tag == "1")
                    {
                        myDataRow["x1"] = txt.Right;
                        myDataRow["y1"] = txt.Top + 10;
                        myDataRow["x2"] = txt.Left + 130;
                        myDataRow["y2"] = txt.Top + 10;
                    }
                    else if (txt.Tag == "3")
                    {
                        myDataRow["x1"] = 0;
                        myDataRow["y1"] = 0;
                        myDataRow["x2"] = 0;
                        myDataRow["y2"] = 0;
                    }
                    tble.Rows.Add(myDataRow);
                }
            }
            SaveFileDialog1.Filter = "csv files (*.csv)|*.csv";


            if (SaveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filename = SaveFileDialog1.FileName;
                using (StreamWriter sw = new StreamWriter(SaveFileDialog1.FileName))
                {
                    for (int i = 0; i < tble.Columns.Count; i++)
                    {
                        sw.Write(tble.Columns[i]);
                        if (i < tble.Columns.Count - 1)
                        {
                            sw.Write(",");
                        }
                    }
                    sw.Write(sw.NewLine);
                    foreach (DataRow dr in tble.Rows)
                    {
                        for (int i = 0; i < tble.Columns.Count; i++)
                        {
                            if (!Convert.IsDBNull(dr[i]))
                            {
                                string value = dr[i].ToString();
                                if (value.Contains(','))
                                {
                                    value = String.Format("\"{0}\"", value);
                                    sw.Write(value);
                                }
                                else
                                {
                                    sw.Write(dr[i].ToString());
                                }
                            }
                            if (i < tble.Columns.Count - 1)
                            {
                                sw.Write(",");
                            }
                        }
                        sw.Write(sw.NewLine);

                    }
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Dispose();
            textBox2.Dispose();
            textBox3.Dispose();
            textBox4.Dispose();

            tble.Clear();
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "csv files (*.csv)|*.csv";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader sr = new StreamReader(openFileDialog1.FileName))
                {
                    string[] headers = sr.ReadLine().Split(',');
                    foreach (string header in headers)
                    {
                        tble1.Columns.Add(header);
                    }
                    while (!sr.EndOfStream)
                    {
                        string[] rows = sr.ReadLine().Split(',');
                        DataRow dr = tble1.NewRow();
                        for (int i = 0; i < headers.Length; i++)
                        {
                            dr[i] = rows[i];


                        }
                        tble1.Rows.Add(dr);


                    }
                    sr.Close();

                }
            }
            foreach (DataRow row in tble1.Rows)
            {

                System.Windows.Forms.TextBox txt = new System.Windows.Forms.TextBox();


                txt.Name = row[0].ToString();
                txt.Text = row[1].ToString();
                txt.Left = Int32.Parse(row[2].ToString());
                txt.Top = Int32.Parse(row[3].ToString());
                txt.Width = Int32.Parse(row[5].ToString());
                txt.Height = Int32.Parse(row[4].ToString());
                txt.TextAlign = HorizontalAlignment.Center;
                
                panel2.Controls.Add(txt);
                Graphics g = panel2.CreateGraphics();
                g.DrawLine(blackpen, Int32.Parse(row[6].ToString()), Int32.Parse(row[7].ToString()), Int32.Parse(row[8].ToString()), Int32.Parse(row[9].ToString()));
                if (txt.Name == "textBox1")
                {
                    txt.BackColor = Color.Crimson;
                    txt.ForeColor = Color.White;

                }


            }
            tble1.Clear();
            tble1.Dispose();
        }

        public class DrawNote
        {
            public int X { set; get; }
            public int Y { set; get; }
           
            public bool isDraw { set; get; }
            public DrawNote()
            {
                isDraw = false;
               
            }
        }


        private void textBox2_Click(object sender, EventArgs e)
            {
                Cen = 2;
                a = "1";
            txtX = textBox2.Left;
            txtY = textBox2.Top;
        }

            private void textBox3_Click(object sender, EventArgs e)
            {
                 Cen = 2;
                 a = "2";
            txtX = textBox3.Left;
            txtY = textBox3.Top;
        }

        private void textBox4_Click(object sender, EventArgs e)
        {
            Cen = 2;
            a = "3";
            txtX = textBox4.Left;
            txtY = textBox4.Top;
        }
    }
}

