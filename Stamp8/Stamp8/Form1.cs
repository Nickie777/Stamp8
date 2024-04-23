using iText.IO.Image;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;
using Document = iText.Layout.Document;
using iText.Layout;

namespace Stamp8
{
    public partial class Form1 : Form
    {
        private string[] args;
        private iText.Layout.Element.Image globalImageStamp;
        private iText.Layout.Element.Image globalImageFacsimile;
        private int mode; //1-2-3
        private string outputPdfFilePath;
        private int pageCount;
        private bool editMode = false;
        private int currentEditPage = 1;
        private bool setFirst = true;
        private int changeMode = 0; //1-�������
        private int firstStampCoordinateX = 100;
        private int firstStampCoordinateY = 100;
        private int firstStampWidth = 200;
        private int firstStampHeight = 200;
        private int firstFacsimileCoordinateX = 150;
        private int firstFacsimileCoordinateY = 150;
        private float widthPagePDF;
        private float heightPagePDF;
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
            CreateGlobalImages();
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
                numericUpDownCurrentPage.Maximum = pageCount;
                comboBoxChangeObject.Visible = true;
                labelCurrentImage.Visible = true;
                trackBarChange.Visible = true;
                ����������������ToolStripMenuItem.Visible = false;
                if (mode == 3) 
                {
                   // comboBoxChangeObject.Maximum = 2;
                }
                radioButtonChangeSize.Visible = true;
                ��������������ToolStripMenuItem.Visible = true;
                �������������������ToolStripMenuItem.Visible = false;
            }
            else
            {
                editMode = false;
                textBoxEditMode.Text = "����� ���������";
                textBoxEditMode.BackColor = System.Drawing.Color.LightBlue;
                labelCurrentPage.Visible = false;
                numericUpDownCurrentPage.Visible = false;
                comboBoxChangeObject.Visible = false;
                labelCurrentImage.Visible = false;
                trackBarChange.Visible = false;
                ����������������ToolStripMenuItem.Visible = true;
                radioButtonChangeSize.Visible = false;
                ��������������ToolStripMenuItem.Visible = false;
                �������������������ToolStripMenuItem.Visible = true;
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
        }

        private void setPageCount()
        {
            // �������� ������� PdfDocument
            using (iText.Kernel.Pdf.PdfDocument pdfDocument = new iText.Kernel.Pdf.PdfDocument(new PdfReader(args[0])))
            {
                // ��������� ���������� ������� � ���������
                pageCount = pdfDocument.GetNumberOfPages();
                // ��������� �������� ������ ��������
                for (int i = 1; i <= pageCount; i++)
                {
                    // ��������� ������� �������� ��������
                    var pageSize = pdfDocument.GetPage(i).GetPageSize();

                    // ������ ��������
                    widthPagePDF = pageSize.GetWidth();

                    // ������ ��������
                    heightPagePDF = pageSize.GetHeight();

                    // ����� �������� ��������
                    //Console.WriteLine($"������ �������� {i}: ������ = {width}, ������ = {height}");
                }
            }
        }

        private void CreateGlobalImages()
        {
            if (mode== 1 || mode == 1)
            {
                 globalImageStamp     = new iText.Layout.Element.Image(ImageDataFactory.Create(args[1]));
                 globalImageFacsimile = null;
            }
            else if (mode== 3)
            {
                globalImageStamp     = new iText.Layout.Element.Image(ImageDataFactory.Create(args[1]));
                globalImageFacsimile = new iText.Layout.Element.Image(ImageDataFactory.Create(args[2]));
            }

        }


        private void ����������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StampPicturesList.Clear();
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
                            //Console.WriteLine(originalString); // ������� "���  ������ ��� �������� ���������"
                            int number;
                            if (int.TryParse(originalString, out number))
                            {
                                MessageBox.Show("������ ������ �� �������� �" + number);
                                //await OverlayImageOnPDF5(outputPdfFilePath, args[1], firstStampCoordinateX, firstStampCoordinateY, firstStampWidth, firstStampHeight, number);
                                var pic1 = await OverlayImageOnPDF(outputPdfFilePath, args[1], firstStampCoordinateX, firstStampCoordinateY, firstStampWidth, firstStampHeight, number,1);
                               // updatePDFViewer(outputPdfFilePath);
                                //var pic2 = await OverlayImageOnPDF(outputPdfFilePath, args[2], firstFacsimileCoordinateX, firstFacsimileCoordinateY, firstStampWidth, firstStampHeight, number);
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

            foreach (Control control in flowLayoutPanel2.Controls)
            {

                if (control is Button button1)
                {
                    if (button1.BackColor == System.Drawing.Color.Coral)
                    {
                        string originalString = button1.Text;
                        string substringToRemove = "��� ";

                        int index = originalString.IndexOf(substringToRemove); // ������� ������ ������ ���������
                        if (index != -1)
                        {
                            originalString = originalString.Remove(index, substringToRemove.Length); // ������� ���������
                            //Console.WriteLine(originalString); // ������� "���  ������ ��� �������� ���������"
                            int number;
                            if (int.TryParse(originalString, out number))
                            {
                                MessageBox.Show("������ ������� �� �������� �" + number);
                                //await OverlayImageOnPDF5(outputPdfFilePath, args[1], firstStampCoordinateX, firstStampCoordinateY, firstStampWidth, firstStampHeight, number);
                                //var pic1 = await OverlayImageOnPDF(outputPdfFilePath, args[1], firstStampCoordinateX, firstStampCoordinateY, firstStampWidth, firstStampHeight, number);
                                // updatePDFViewer(outputPdfFilePath);
                                var pic2 = await OverlayImageOnPDF(outputPdfFilePath, args[2], firstFacsimileCoordinateX, firstFacsimileCoordinateY, firstStampWidth, firstStampHeight, number,2);
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


        private async void ����ToolStripMenuItem_ClickAsync(object sender, EventArgs e)
        {
            //var w = await OverlayImageOnPDF5(outputPdfFilePath, args[1], firstStampCoordinateX, firstStampCoordinateY, firstStampWidth, firstStampHeight, 1);
            updatePDFViewer(outputPdfFilePath);
        }
        private async Task<string> OverlayImageOnPDF(string pdfFilePath, string imageFilePath, float x, float y, int width, int height, int pageNumber, int typePicture)
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
                //image.SetWidth(width);
                image.SetWidth(image.GetImageWidth());
                //image.SetHeight(height);
                image.SetHeight(image.GetImageHeight());

                // ������� �������������, �������������� ������� ��������
                iText.Kernel.Geom.Rectangle pageSize = page.GetPageSize();

                // ������� ������ Canvas ��� ���������� ����������� �� ��������
                Canvas canvas = new Canvas(new PdfCanvas(page), pageSize);

                // ��������� ����������� �� ��������
                //canvas.BeginLayer(ocg);
                canvas.Add(image);
                canvas.Close();
                //globalPdfDocument = pdfDocument;
                // ������� ��������� StampPictures
                StampPictures stampPictures = new StampPictures();
                stampPictures.image       = image;
                stampPictures.filePath    = imageFilePath;
                stampPictures.pageNumber  = pageNumber;
                stampPictures.typePicture = typePicture;
                StampPicturesList.Add(stampPictures);
            }           


            return outputPdfFilePath;
        }

        private void �������������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updateEditMode(true);
        }

        private void ��������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updateEditMode(false);
        }

        private void numericUpDownCurrentPage_ValueChanged(object sender, EventArgs e)
        {
            currentEditPage = (int)numericUpDownCurrentPage.Value;
        }

        private void radioButtonChangeSize_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonChangeSize.Checked) 
            {
                changeMode = 1;
                //��������� ������ ��������
                trackBarChange.Maximum = 10;
                //MessageBox.Show(((int)widthPagePDF).ToString());

            }            
        }

        private async void trackBarChange_Scroll(object sender, EventArgs e)
        {
            if (changeMode== 0) 
            {
                MessageBox.Show("�� ������ �� ���� ����� ���������");
            }
            else if (changeMode==1) 
            {

                //MessageBox.Show(StampPicturesList.Count().ToString());
                foreach (var stampPicture in StampPicturesList)
                {
                    if (currentEditPage == stampPicture.pageNumber) 
                    {
                      MessageBox.Show(stampPicture.pageNumber.ToString());
                        //����������, ����� ������ ������
                        string selectedValue = comboBoxChangeObject.SelectedItem.ToString();
                        if (selectedValue == "������") 
                        { 
                            if (stampPicture.typePicture == 1) 
                            {
                                stampPicture.scale = trackBarChange.Value;
                                stampPicture.image.Scale(trackBarChange.Value, trackBarChange.Value);
                                //var result = await updateAddingImage(stampPicture);

                            }
                        }
                        else if (selectedValue == "�������")
                        {
                            if (stampPicture.typePicture == 2)
                            {
                                stampPicture.scale = trackBarChange.Value;
                                stampPicture.image.Scale(trackBarChange.Value, trackBarChange.Value);
                                //var result = await updateAddingImage(stampPicture);
                            }
                        }
                        updatePDFViewer(outputPdfFilePath);
                    }
                    else
                    {
                        MessageBox.Show("�� ��������� �������� ��� �������� ��� ��������������");
                    }
                }
            }
        }

        async Task<string> updateAddingImage(StampPictures stampPicture)
        {
            outputPdfFilePath = System.IO.Path.ChangeExtension(System.IO.Path.GetTempFileName(), ".pdf");
            using (PdfReader pdfReader = new PdfReader(args[0]))
            using (PdfWriter pdfWriter = new PdfWriter(outputPdfFilePath))
            using (var pdfDocument = new iText.Kernel.Pdf.PdfDocument(pdfReader, pdfWriter))
            {
                PdfPage page = pdfDocument.GetPage(stampPicture.pageNumber);
                // ������� �������������, �������������� ������� ��������
                iText.Kernel.Geom.Rectangle pageSize = page.GetPageSize();
                // ������� ������ Canvas ��� ���������� ����������� �� ��������
                Canvas canvas = new Canvas(new PdfCanvas(page), pageSize);
                canvas.Add(stampPicture.image);

            }

            return outputPdfFilePath;
        }
    }
}