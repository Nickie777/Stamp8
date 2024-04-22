using iText.IO.Image;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;
using System.Windows.Forms;
using Document = iText.Layout.Document;
using iText.Forms;
using iText.Kernel.Colors;
using iText.Kernel.Geom;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Kernel.Pdf.Layer;
using iText.Kernel.Pdf.Xobject;
using PdfiumViewer;
using Microsoft.VisualBasic;
using Patagames.Pdf.Net.Wrappers;

namespace Stamp8
{
    public partial class Form1 : Form
    {
        private string[] args;
        private int mode;
        private string outputPdfFilePath;
        private int pageCount;
        private bool editMode = false;
        private bool setFirst = true;
        private int firstStampCoordinateX = 100;
        private int firstStampCoordinateY = 100;
        private int firstStampWidth = 200;
        private int firstStampHeight = 200;
        private int firstFacsimileCoordinateX = 150;
        private int firstFacsimileCoordinateY = 150;
        private List<StampPictures> StampPicturesList = new List<StampPictures>();
        //private PdfiumViewer.PdfDocument pdfDocumentViewver;
        public Form1(string[] args, int mode)
        {
            //outputPdfFilePath = Path.GetTempFileName();
            this.args = args;
            outputPdfFilePath = args[0];
            this.mode = mode;
            InitializeComponent();
            setPageCount();
            //����� ���������� �����������
            updatePDFViewer(args[0]);
            //����� ���������� ������ �������
            setButtons();
            //����� ���������� ������ ��������������
            updateEditMode(false);
        }

        private void updateEditMode(bool value)
        {
            if (value) 
            {
                editMode = true;
                textBoxEditMode.Text = "����� ��������������";
                textBoxEditMode.BackColor = System.Drawing.Color.Red;
                labelCurrentPage.Visible = true;
                numericUpDownCurrentPage.Visible = true;
            }
            else
            {
                editMode = false;
                textBoxEditMode.Text = "����� ���������";
                textBoxEditMode.BackColor = System.Drawing.Color.LightBlue;
                labelCurrentPage.Visible = false;
                numericUpDownCurrentPage.Visible = false;
            }
        }

        private void setButtons()
        {
            if (mode == 3)
            {
                for (var i = 1; i <= pageCount; i++)
                {
                    //�������� ������� ������
                    groupBox1.Visible = false;
                    //������ ��� ��������
                    var button = new Button();
                    button.Text = $"��� {i}";
                    button.BackColor = System.Drawing.Color.LightBlue;
                    button.Width = 50;
                    button.Margin = new Padding(3); // ������ ����� ��������
                    button.Click += Button_Click; // ���������� ������� Click
                    flowLayoutPanel1.Controls.Add(button);
                    //�������
                    var button1 = new Button();
                    button1.Text = $"��� {i}";
                    button1.BackColor = System.Drawing.Color.LightBlue;
                    button1.Width = 50;
                    button1.Margin = new Padding(3); // ������ ����� ��������
                    button1.Click += Button1_Click; // ���������� ������� Click
                    flowLayoutPanel2.Controls.Add(button1);
                }

            }
        }

        private void updatePDFViewer(string updNamd)
        {
            pdfViewer1.Document = PdfiumViewer.PdfDocument.Load(updNamd);
            pdfViewer1.Show();
            //pdfViewer1.Document = pdfDocumentViewver;
        }

        private void setPageCount()
        {
            // �������� ������� PdfDocument
            using (iText.Kernel.Pdf.PdfDocument pdfDocument = new iText.Kernel.Pdf.PdfDocument(new PdfReader(args[0])))
            {
                // ��������� ���������� ������� � ���������
                pageCount = pdfDocument.GetNumberOfPages();
                // �������� PdfDocument
            }
        }

        private async Task OverlayImageOnPDF(string pdfFilePath, string imageFilePath, float x, float y, int width, int height, int pageNumber)
        {
            outputPdfFilePath = System.IO.Path.ChangeExtension(System.IO.Path.GetTempFileName(), ".pdf");
            using (PdfReader pdfReader = new PdfReader(pdfFilePath))
            using (PdfWriter pdfWriter = new PdfWriter(outputPdfFilePath))
            using (iText.Kernel.Pdf.PdfDocument pdfDocument = new iText.Kernel.Pdf.PdfDocument(pdfReader, pdfWriter))
            {
                ImageData imageData = ImageDataFactory.Create(imageFilePath);
                imageData.SetWidth(width);
                imageData.SetHeight(height);
                // ����������� ��������� ��� ���������� ����������� �� �������� PDF
                //float x = 100;
                //float y = 100;
                // ��������� �������� PDF
                PdfPage page = pdfDocument.GetPage(pageNumber);
                // �������� Canvas ��� �������� PDF
                PdfCanvas canvas = new PdfCanvas(page);
                // ��������� ����������� �� �������� PDF � ������� Canvas
                canvas.AddImageAt(imageData, x, y, true);
            }
        }


        async private void OverlayImageOnPDF1(string pdfFilePath, string imageFilePath, string outputPdfFilePath)
        {
            using (PdfReader pdfReader = new PdfReader(pdfFilePath))
            using (PdfWriter pdfWriter = new PdfWriter(outputPdfFilePath))
            using (iText.Kernel.Pdf.PdfDocument pdfDocument = new iText.Kernel.Pdf.PdfDocument(pdfReader, pdfWriter))
            {
                Document document = new Document(pdfDocument);

                // �������� ����������� �� ������
                /*byte[] imageDataBytes;
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    imageStream.CopyTo(memoryStream);
                    imageDataBytes = memoryStream.ToArray();
                }*/

                // �������� ImageData �� ������
                ImageData imageData = ImageDataFactory.Create(imageFilePath);
                // ��������� ������� �����������
                imageData.SetWidth(200);
                imageData.SetHeight(200);

                // ����������� ��������� ��� ���������� ����������� �� �������� PDF
                float x = 100;
                float y = 100;

                // ��������� �������� PDF
                PdfPage page = pdfDocument.GetFirstPage();
                // �������� Canvas ��� �������� PDF
                PdfCanvas canvas = new PdfCanvas(page);

                // ��������� ����������� �� �������� PDF
                //canvas.AddImage (imageData, x, y, true);
                //document.Add(imageData);
                // �������� ���������
                document.Close();
            }
        }


        private void ����������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (setFirst) 
            {
                if (mode == 3)
                {
                    //setStampFirst();
                    setStamp3();
                    setFirst = false;
                }
            }
            
            //��������� ����� ��������
            //setStampPicturesData();
        }

        private void setStampFirst()
        {
            throw new NotImplementedException();
        }

        private async void setStamp3()
        {
            foreach (Control control in flowLayoutPanel1.Controls)
            {
                
                if (control is Button button)
                {
                   if (button.BackColor == System.Drawing.Color.Coral) 
                    {
                        string originalString = button.Text;
                        string substringToRemove = "��� ";

                        int index = originalString.IndexOf(substringToRemove); // ������� ������ ������ ���������
                        if (index != -1)
                        {
                            originalString = originalString.Remove(index, substringToRemove.Length); // ������� ���������
                            Console.WriteLine(originalString); // ������� "���  ������ ��� �������� ���������"
                            int number;
                            if (int.TryParse(originalString, out number))
                            {
                                MessageBox.Show("������ ������ �� �������� �" + number);
                                //await OverlayImageOnPDF5(outputPdfFilePath, args[1], firstStampCoordinateX, firstStampCoordinateY, firstStampWidth, firstStampHeight, number);
                                var v = await OverlayImageOnPDF6(outputPdfFilePath, args[1], firstStampCoordinateX, firstStampCoordinateY, firstStampWidth, firstStampHeight, number);
                                updatePDFViewer(outputPdfFilePath);
                                //MessageBox.Show(outputPdfFilePath);
                            }
                            else
                            {
                                MessageBox.Show("������ ��� �������������� � ����� ��� ������ �������");
                            }





                        }

                    }
                }
            }
        }

        private void ����������������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mode == 3)
            {
                for (var i=1; i<=pageCount; i++) 
                {
                    //�������� ������� ������
                    groupBox1.Visible = false;
                    //������ ��� ��������
                    var button = new Button();
                    button.Text = $"��� {i}";
                    button.BackColor = System.Drawing.Color.LightBlue;
                    button.Width = 50;
                    button.Margin = new Padding(3); // ������ ����� ��������
                    button.Click += Button_Click; // ���������� ������� Click
                    flowLayoutPanel1.Controls.Add(button);
                    //�������
                    var button1 = new Button();
                    button1.Text = $"��� {i}";
                    button1.BackColor = System.Drawing.Color.LightBlue;
                    button1.Width = 50;
                    button1.Margin = new Padding(3); // ������ ����� ��������
                    button1.Click += Button1_Click; // ���������� ������� Click
                    flowLayoutPanel2.Controls.Add(button1);
                }
              

            }

            
        }

        private void Button1_Click(object? sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            //��������� ��������� ����� ��� �������
            if (clickedButton.BackColor == System.Drawing.Color.Coral)
                clickedButton.BackColor = System.Drawing.Color.LightBlue;
            else
                clickedButton.BackColor = System.Drawing.Color.Coral;
        }

        private void Button_Click(object? sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            //��������� ��������� ����� ��� �������
            if (clickedButton.BackColor == System.Drawing.Color.Coral)
                clickedButton.BackColor = System.Drawing.Color.LightBlue; 
            else
                clickedButton.BackColor = System.Drawing.Color.Coral;
        }



        private async Task<string> OverlayImageOnPDF5(string pdfFilePath, string imageFilePath, float x, float y, int width, int height, int pageNumber)
        {
            outputPdfFilePath = System.IO.Path.ChangeExtension(System.IO.Path.GetTempFileName(), ".pdf");

            using (PdfReader pdfReader = new PdfReader(pdfFilePath))
            using (PdfWriter pdfWriter = new PdfWriter(outputPdfFilePath))
            using (var pdfDocument = new iText.Kernel.Pdf.PdfDocument(pdfReader, pdfWriter))
            {
                var doc = new Document(pdfDocument);

                // �������� ��������, �� ������� ����� �������� �����������
                PdfPage page = pdfDocument.GetPage(2);

                // ��������� �����������
                ImageData imageData = ImageDataFactory.Create(imageFilePath);

                // ������� ������ �����������
                iText.Layout.Element.Image image = new iText.Layout.Element.Image(imageData);

                // ������������� ������� � ������ �����������
                image.SetFixedPosition(x, y);
                image.SetWidth(width);
                image.SetHeight(height);

                // ��������� ����������� �� ��������
                doc.Add(image);
                // ��������� ����������� �� ��������
                //new Document(page.GetDocument()).Add(image);

            }
            return outputPdfFilePath;
            //MessageBox.Show(outputPdfFilePath);
        }

        private async void ����ToolStripMenuItem_ClickAsync(object sender, EventArgs e)
        {
            //var w = await OverlayImageOnPDF5(outputPdfFilePath, args[1], firstStampCoordinateX, firstStampCoordinateY, firstStampWidth, firstStampHeight, 1);
            updatePDFViewer(outputPdfFilePath);
        }
        private async Task<string> OverlayImageOnPDF6(string pdfFilePath, string imageFilePath, float x, float y, int width, int height, int pageNumber)
        {
            outputPdfFilePath = System.IO.Path.ChangeExtension(System.IO.Path.GetTempFileName(), ".pdf");

            using (PdfReader pdfReader = new PdfReader(pdfFilePath))
            using (PdfWriter pdfWriter = new PdfWriter(outputPdfFilePath))
            using (var pdfDocument = new iText.Kernel.Pdf.PdfDocument(pdfReader, pdfWriter))
            {
                // �������� ��������, �� ������� ����� �������� �����������
                PdfPage page = pdfDocument.GetPage(pageNumber);



 

                //PdfLayer layer = new PdfLayer("Stamp", pdfDocument);

                // ��������� ���� � ��������
                //pdfDocument.GetCatalog().AddOCGRadioGroup(layer);

                //PdfLayer pdflayer = new PdfLayer("Stamp", pdfDocument); //+
                //pdflayer.IsOn();                                        //+
                
                // ������� ������ �����������
                iText.Layout.Element.Image image = new iText.Layout.Element.Image(ImageDataFactory.Create(imageFilePath));



                // ������������� ������� � ������ �����������
                image.SetFixedPosition(x, y);
                image.SetWidth(width);
                image.SetHeight(height);

                // ������� �������������, �������������� ������� ��������
                iText.Kernel.Geom.Rectangle pageSize = page.GetPageSize();

                // ������� ������ Canvas ��� ���������� ����������� �� ��������
                Canvas canvas = new Canvas(new PdfCanvas(page), pageSize);

                // ��������� ����������� �� ��������
                //canvas.BeginLayer(ocg);
                canvas.Add(image);
                // ������� ��������� StampPictures
                StampPictures stampPictures = new StampPictures();
                stampPictures.image = image;
                stampPictures.filePath = imageFilePath;
                stampPictures.pageNumber= pageNumber;
                StampPicturesList.Add(stampPictures);
            }           


            return outputPdfFilePath;
        }

        private void �������������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updateEditMode(true);
        }
    }
}