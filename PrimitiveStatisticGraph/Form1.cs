using System;
using System.Drawing;
using System.Windows.Forms;


namespace PrimitiveStatisticGraph
{    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Datos iniciales
            string[] row0 = { "2016", "245"};
            string[] row1 = { "2017", "213" };
            string[] row2 = { "2018", "220" };
            string[] row3 = { "2019", "204" };
            string[] row4 = { "2020", "189" };

            // Agregar datos al datagrid
            dataGridView1.Rows.Add(row0);
            dataGridView1.Rows.Add(row1);
            dataGridView1.Rows.Add(row2);
            dataGridView1.Rows.Add(row3);
            dataGridView1.Rows.Add(row4);
        }
        
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics lienzo = e.Graphics;
            Pen lapiz = new Pen(Color.White, 2);
            //SolidBrush BrochaPinta = new SolidBrush(Color.red);
            //lienzo.FillRectangle(BrochaPinta, 306, 12, 300, 270);
            lienzo.Clear(Color.White);

        }
        
        private void drawPie(float[] pieProportion,int sum/*, object sender, PaintEventArgs e*/)
        {
            // Variables para dibujar el Pie
            float lastValue = 0;
            float angle = 0;
            System.Random rnd = new System.Random();
            Graphics lienzo = this.CreateGraphics();
            lienzo.Clear(Color.White);
            SolidBrush brush = new SolidBrush(Color.White);
           // lienzo.FillRectangle(brush, 306, 12, 300, 270);
            Pen lapiz = new Pen(Color.White, 2);
            SolidBrush BrochaPinta = new SolidBrush(Color.White);
            Rectangle rectangulo = new Rectangle(307, 12, 295, 265);

            //Variables para leyenda
            int tagXpos = 654;
            int tagYpos = 12;
            RectangleF textRectangle = new RectangleF(688F, 12F, 100F, 16F);
            Font textFont = new Font("Calibri", 12);
            SolidBrush textBrush = new SolidBrush(Color.Black);
            StringFormat textFormat = new StringFormat();
            textFormat.Alignment = StringAlignment.Near;
            
            //Dibuja el Pie y leyenda
            for ( int i=0;i < pieProportion.Length-1; i++)
            {
                //Pie
                angle = (pieProportion[i] * 360);
                brush.Color = Color.FromArgb(255, rnd.Next(75, 230), rnd.Next(75, 230), rnd.Next(75, 230));
                lienzo.FillPie(brush, rectangulo, lastValue, angle);
                lienzo.DrawPie(lapiz, rectangulo, lastValue, angle);
                lastValue = angle + lastValue;

                //Leyenda
                lienzo.DrawString(dataGridView1.Rows[i].Cells["año"].Value.ToString(), textFont,textBrush,textRectangle,textFormat);
                lienzo.FillRectangle(brush, tagXpos, tagYpos, 36, 16);
                tagYpos += 21;
                textRectangle.Location = new PointF(textRectangle.Location.X, textRectangle.Location.Y + 21);
            }

            // Etiquetas del Pie
            using (StringFormat string_format = new StringFormat())
            {
                // Centrar texto.
                string_format.Alignment = StringAlignment.Center;
                string_format.LineAlignment = StringAlignment.Center;

                // Calcular el centro del rectangulo.
                float cx = (rectangulo.Left + rectangulo.Right) / 2f;
                float cy = (rectangulo.Top + rectangulo.Bottom) / 2f;

                // poner la etiqueta 2/3 del borde
                float radius = (rectangulo.Width + rectangulo.Height) / 2f * 0.33f;

                float start_angle = 0;
                for (int i = 0; i < pieProportion.Length-1; i++)
                {
                    float sweep_angle = float.Parse(dataGridView1.Rows[i].Cells["valueSales"].Value.ToString()) * 360F / sum;

                    // Dibujar etiquetas
                    double label_angle =
                        Math.PI * (start_angle + sweep_angle / 2f) / 180f;
                    float x = cx + (float)(radius * Math.Cos(label_angle));
                    float y = cy + (float)(radius * Math.Sin(label_angle));
                    lienzo.DrawString(dataGridView1.Rows[i].Cells["valueSales"].Value.ToString(),
                        textFont, textBrush, x, y, string_format);

                    start_angle += sweep_angle;
                }
            }


        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            //Sumar valores del datagrid
            float[] pieProportion = new float[dataGridView1.RowCount];
            int sum = 0;
            for (int i = 0; i < dataGridView1.Rows.Count-1 ; ++i)
            {
                sum += int.Parse(dataGridView1.Rows[i].Cells["valueSales"].Value.ToString());
            }
            

            //Calcular proporcion del Pie
            for (int i = 0; i < dataGridView1.RowCount-1; i++)
            {
                pieProportion[i] = float.Parse(dataGridView1.Rows[i].Cells["valueSales"].Value.ToString()) / sum;
                //MessageBox.Show(pieProportion[i].ToString());
            }

            //Llamar metodo para dibujar grafico estadistico
            drawPie(pieProportion,sum);
        }
    }
}
