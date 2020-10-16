using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QRCoder;

namespace QR
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        string img = String.Empty;
        private void Generar_Click(object sender, EventArgs e)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(richTextBox1.Text, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            if (img != "")
            {
                qrCodeImage = qrCode.GetGraphic(20, Color.Black, Color.White, (Bitmap)Bitmap.FromFile(img));
            }
            pictureBox1.Image = qrCodeImage;
        }

        private void Logo_Click(object sender, EventArgs e)
        {
            if (Abrir.ShowDialog() == DialogResult.OK)
            {
                img = Abrir.FileName;
            }
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog Guardar = new SaveFileDialog();

            if (Guardar.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image.Save(Guardar.FileName);
            }
        }
    }
}
