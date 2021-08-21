using System.Drawing;
using System.Windows.Forms;

namespace PrimitiveStatisticGraph
{    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
        }
        //Trabajando con primitivas gráficas
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics lienzo = e.Graphics;
            Pen lapiz = new Pen(Color.White, 2);
            SolidBrush BrochaPinta = new SolidBrush(Color.White);
            //===================================
            //Rectángulo: Xpos, Ypos, Ancho, Alto
            //===================================
            lienzo.FillRectangle(BrochaPinta, 306, 12, 300, 270);

            /*// Crea borcha.
            SolidBrush redBrush = new SolidBrush(Color.Red);

            //==============
            //Letras
            //==============
            string Cadena = "Esta es una prueba";

            //Fuente y la brocha con que se pinta.
            Font FuenteLetra = new Font("Tahoma", 16);
            SolidBrush BrochaPinta = new SolidBrush(Color.Black);

            //Punto arriba a la izquierda para pintar la cadena
            PointF PuntoCadena = new PointF(600.0F, 100.0F);

            //Formato para dibujar
            StringFormat FormatoDibuja = new StringFormat();
            FormatoDibuja.FormatFlags = StringFormatFlags.DirectionVertical;

            //Dibuja la cadena
            lienzo.DrawString(Cadena, FuenteLetra, BrochaPinta, PuntoCadena, FormatoDibuja);


            //================
            //Dibuja un pastel
            //================
            //Crea un rectángulo para la elipse
            Rectangle rectangulo = new Rectangle(300, 300, 100, 100);

            //Pastel: rectángulo que contiene, ángulo inicial, ángulo abre
            lienzo.FillPie(redBrush, rectangulo, 0F, 90F);
            lienzo.DrawPie(lapiz, rectangulo, 0F, 90F);
            lienzo.DrawPie(lapiz, rectangulo, 90F, 180F);
            lienzo.DrawPie(lapiz, rectangulo, 180F, 270F);
            lienzo.DrawPie(lapiz, rectangulo, 270F, 360F);*/
        }
        
        private void drawPie(float[] pieProportion/*, object sender, PaintEventArgs e*/)
        {
            // Graphics lienzo = e.Graphics;
            Graphics lienzo = this.CreateGraphics();
            SolidBrush redBrush = new SolidBrush(Color.Red);
            SolidBrush BrochaPinta = new SolidBrush(Color.White);
            Rectangle rectangulo = new Rectangle(306, 12, 295, 265);
            lienzo.FillPie(redBrush, rectangulo, 0F, 90F);
            /* for( int i=0;i < pieProportion.Length; i++)
            {
                lienzo.FillPie(redBrush, rectangulo, 0F, 90F);
                lienzo.FillRectangle(BrochaPinta, 306, 12, 300, 270);
            }*/
            
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            float[] pieProportion = new float[dataGridView1.RowCount];

            int sum = 0;
            for (int i = 0; i < dataGridView1.Rows.Count-1 ; ++i)
            {
                sum += int.Parse(dataGridView1.Rows[i].Cells["valueSales"].Value.ToString());
            }
            

            for (int i = 0; i < dataGridView1.RowCount-1; i++)
            {
                pieProportion[i] = float.Parse(dataGridView1.Rows[i].Cells["valueSales"].Value.ToString()) / sum;
            }
            drawPie(pieProportion);
        }
    }
}
