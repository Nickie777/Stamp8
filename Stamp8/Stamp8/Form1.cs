using iText.IO.Image;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;
using Document = iText.Layout.Document;
using iText.Layout;
using System.ComponentModel;

namespace Stamp8
{
    public partial class Form1 : Form
    {
        private string[] args;
        //private iText.Layout.Element.Image globalImageStamp;
        //private iText.Layout.Element.Image globalImageFacsimile;
        private int mode; //1-2-3
        private string outputPdfFilePath;
        private int pageCount;
        //private bool editMode = false;
        private int currentEditPage = 1;
        private bool PDFchanged = false;
        //private int changeMode = 0; //1-�������
        private int firstStampCoordinateX = 100;
        private int firstStampCoordinateY = 100;
        private int firstStampWidth = 150;
        private int firstStampHeight = 150;
        private float firstStampScale = 1;
        private int firstFacsimileCoordinateX = 150;
        private int firstFacsimileCoordinateY = 150;
        private int firstFacsimileWidth = 100;
        private int firstFacsimileHeight = 100;
        private float firstFacsimileScale = 1;
        private float widthPagePDF;
        private float heightPagePDF;
        private List<StampPictures> StampPicturesList = new List<StampPictures>();
        
        public Form1(string[] args, int mode)
        {
            //������� ������� ����������
            dataGridViewStamps = null;
            //MessageBox.Show("���� 1");
            //�������� ���������, ���������� �� ��������� ������
            this.args = args;
            //MessageBox.Show("���� 2");
            //����������� ���������� ���� ������ pdf
            outputPdfFilePath = args[0];
            //MessageBox.Show("���� 3");

            //�������� ����� ������
            this.mode = mode;
            //MessageBox.Show("���� 4");
            InitializeComponent();
            //MessageBox.Show("���� 5");
            //������������� ���������� ������� �������
            setPageCount();
            //MessageBox.Show("���� 6");
            //CreateGlobalImages();
            //��������� ����� ���������� ����������� �������� pdf
            updatePDFViewer(args[0]);
            //MessageBox.Show("���� 7");
            //����� ���������� ������ �������
            setButtons();
            //MessageBox.Show("���� 8");
            //����� ���������� ������ ��������������
            updateEditMode(false);
            //MessageBox.Show("���� 9");
        }

        

        private void setStartSizeImage()
        {
            if (mode == 3) 
            {
                iText.Layout.Element.Image image1 = new iText.Layout.Element.Image(ImageDataFactory.Create(args[1]));
                firstStampWidth = (int)image1.GetImageWidth();
                firstStampHeight = (int)image1.GetImageHeight();
                iText.Layout.Element.Image image2 = new iText.Layout.Element.Image(ImageDataFactory.Create(args[2]));
                firstFacsimileWidth = (int)image1.GetImageWidth();
                firstFacsimileHeight = (int)image1.GetImageHeight();
            }
           
        }

        private void updateEditMode(bool value)
        {
            if (value) 
            {
                textBoxEditMode.Text = "����� ��������������";
                textBoxEditMode.BackColor = System.Drawing.Color.Red;
                labelCurrentPage.Visible = true;
                numericUpDownCurrentPage.Visible = true;
                numericUpDownCurrentPage.Maximum = pageCount;
                ����������������ToolStripMenuItem.Visible = false;
                ��������������ToolStripMenuItem.Visible = true;
                �������������������ToolStripMenuItem.Visible = false;
                dataGridViewStamps.Visible = true;
                button1.Visible = true;
            }
            else
            {
                textBoxEditMode.Text = "����� ���������";
                textBoxEditMode.BackColor = System.Drawing.Color.LightBlue;
                labelCurrentPage.Visible = false;
                numericUpDownCurrentPage.Visible = false;
                ����������������ToolStripMenuItem.Visible = true;
                ��������������ToolStripMenuItem.Visible = false;
                �������������������ToolStripMenuItem.Visible = true;
                dataGridViewStamps.Visible = false;
                button1.Visible = false;
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
            else if (mode == 2) 
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

                }
            }
        }


        static async Task CopyFileAsync(string sourceFilePath, string targetFilePath)
        {
            using (FileStream sourceStream = new FileStream(sourceFilePath, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize: 4096, useAsync: true))
            using (FileStream targetStream = new FileStream(targetFilePath, FileMode.Create, FileAccess.Write, FileShare.None, bufferSize: 4096, useAsync: true))
            {
                await sourceStream.CopyToAsync(targetStream);
            }
        }

        private async void updatePDFViewer(string updNamd)
        {

            // ��������� ������������� ��������� �����
            documentViewer1.LoadDocument(updNamd);
            documentViewer1.Show();
            /*if (File.Exists(updNamd))
            {
                try
                {
                    var targetFilePath = System.IO.Path.ChangeExtension(System.IO.Path.GetTempFileName(), ".pdf");
                    // �������� �������� ���� �� ��������� ����
                    //await CopyFileAsync(updNamd, targetFilePath);
                    //File.Copy(updNamd, targetFilePath, true);
                    //pdfRenderer1.Document = PdfiumViewer.PdfDocument.Load(targetFilePath);
                   // pdfViewerSpire.LoadFromFile(updNamd);
                    //pdfDocumentViewer1.LoadFromFile(updNamd);
                    //pdfViewer1.Document = PdfiumViewer.PdfDocument.Load(targetFilePath);
                    //pdfViewer1.Show();  
                    //Console.WriteLine("���� ������� ����
                    //
                    //������.");
                }
                catch (IOException ex)
                {
                    MessageBox.Show($"������ ��� ����������� �����: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("�������� ���� �� ����������.");
            }*/
           
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
                }
            }
        }

        private void ����������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (PDFchanged)
            {
                var result = MessageBox.Show("���� �� �������� ���������� ������ � �������, �� ���������� ��������� �� �����������.���������� �������� ?", "��������!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    StampPicturesList.Clear();
                    outputPdfFilePath = args[0];
                    setStamp3();
                }
                else
                {
                   
                }
            }
            else
            {
                StampPicturesList.Clear();
                outputPdfFilePath = args[0];
                setStamp3();
            }

        }

        private void setStampFirst()
        {
            throw new NotImplementedException();
        }

        private async void setStamp3()
        {   
            //������� ����� �������
            StampPicturesList.Clear();
            
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
                                //MessageBox.Show("������ ������ �� �������� �" + number);
                                //await OverlayImageOnPDF5(outputPdfFilePath, args[1], firstStampCoordinateX, firstStampCoordinateY, firstStampWidth, firstStampHeight, number);
                                //var pic1 = await OverlayImageOnPDF(outputPdfFilePath, args[1], firstStampCoordinateX, firstStampCoordinateY, firstStampWidth, firstStampHeight, number,1);
                                // updatePDFViewer(outputPdfFilePath);
                                //var pic2 = await OverlayImageOnPDF(outputPdfFilePath, args[2], firstFacsimileCoordinateX, firstFacsimileCoordinateY, firstStampWidth, firstStampHeight, number);
                                StampPictures stampPictures = new StampPictures();
                                stampPictures.typePicture = 1;
                                stampPictures.height = firstStampHeight;
                                stampPictures.width = firstStampWidth;
                                stampPictures.pageNumber = number;
                                stampPictures.xCoordinate = firstStampCoordinateX;
                                stampPictures.yCoordinate = firstStampCoordinateY;
                                stampPictures.scale= firstStampScale;
                                stampPictures.rotation = 0;
                                stampPictures.Id = Guid.NewGuid();
                                StampPicturesList.Add(stampPictures);
                                //updatePDFViewer(outputPdfFilePath);
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

            if (mode == 3)
            {
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
                                int number;
                                if (int.TryParse(originalString, out number))
                                {
                                    //MessageBox.Show("������ ������� �� �������� �" + number);
                                    //await OverlayImageOnPDF5(outputPdfFilePath, args[1], firstStampCoordinateX, firstStampCoordinateY, firstStampWidth, firstStampHeight, number);
                                    //var pic1 = await OverlayImageOnPDF(outputPdfFilePath, args[1], firstStampCoordinateX, firstStampCoordinateY, firstStampWidth, firstStampHeight, number);
                                    // updatePDFViewer(outputPdfFilePath);
                                    //var pic2 = await OverlayImageOnPDF(outputPdfFilePath, args[2], firstFacsimileCoordinateX, firstFacsimileCoordinateY, firstStampWidth, firstStampHeight, number,2);
                                    StampPictures stampPictures = new StampPictures();
                                    stampPictures.typePicture = 2;
                                    stampPictures.height = firstFacsimileHeight;
                                    stampPictures.width = firstFacsimileWidth;
                                    stampPictures.pageNumber = number;
                                    stampPictures.xCoordinate = firstFacsimileCoordinateX;
                                    stampPictures.yCoordinate = firstFacsimileCoordinateY;
                                    stampPictures.scale = firstFacsimileScale;
                                    stampPictures.rotation = 0;
                                    stampPictures.Id = Guid.NewGuid();
                                    StampPicturesList.Add(stampPictures);
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
            CreatePDFOnStampPicturesList(false);

        }

        private async void CreatePDFOnStampPicturesList(bool isUpdate)
        {
            foreach (var indexer in StampPicturesList) 
            { 
                if (indexer != null) 
                {
                   if (isUpdate) outputPdfFilePath = args[0];
                     if (indexer.typePicture == 1) 
                     {
                        outputPdfFilePath = await OverlayImageOnPDF8(outputPdfFilePath, args[1], indexer.xCoordinate, indexer.yCoordinate, indexer.width, indexer.width, indexer.pageNumber, indexer.typePicture, indexer.scale, indexer.rotation);
                        isUpdate= false;
                     }
                    
                    if (indexer.typePicture == 2)
                    {
                        outputPdfFilePath = await OverlayImageOnPDF8(outputPdfFilePath, args[2], indexer.xCoordinate, indexer.yCoordinate, indexer.width, indexer.width, indexer.pageNumber, indexer.typePicture, indexer.scale, indexer.rotation);
                        isUpdate = false;
                    }
                }
                updatePDFViewer(outputPdfFilePath);
            }
        }

        private async Task<string> OverlayImageOnPDF8(string pdfFilePath, string pathPicture, int xCoordinate, int yCoordinate, int width, int height, int pageNumber, int typePicture, float scale, int rotation)
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
                iText.Layout.Element.Image image = new iText.Layout.Element.Image(ImageDataFactory.Create(pathPicture));

                // ������������� ������� � ������ �����������
                image.SetFixedPosition(xCoordinate, yCoordinate);
                image.SetWidth(width);
                //image.SetWidth(image.GetImageWidth());
                image.SetHeight(height);
                image.Scale(scale, scale);
                image.SetRotationAngle(rotation);
                //image.SetHeight(image.GetImageHeight());

                // ������� �������������, �������������� ������� ��������
                iText.Kernel.Geom.Rectangle pageSize = page.GetPageSize();

                // ������� ������ Canvas ��� ���������� ����������� �� ��������
                Canvas canvas = new Canvas(new PdfCanvas(page), pageSize);

                // ��������� ����������� �� ��������
                canvas.Add(image);
                canvas.Close();
            }

            return outputPdfFilePath;
        }

        private void ����������������������ToolStripMenuItem_Click(object sender, EventArgs e)
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
                    if (mode == 3)
                    {
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
            updatePDFViewer(outputPdfFilePath);
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

        private void button1_Click_1(object sender, EventArgs e)
        {
             
            dataGridViewStamps.Visible = true;
            dataGridViewStamps.Rows.Clear();
            
            foreach (var stampPicture in StampPicturesList)
            {
                if (currentEditPage == stampPicture.pageNumber)
                {
                    string imageTypeString = String.Empty;
                    if (stampPicture.typePicture == 1) imageTypeString = "������";
                    if (stampPicture.typePicture == 2) imageTypeString = "�������";
                    DataGridViewRow newRow = new DataGridViewRow();
                    // ��������� ������ � ������
                    newRow.Cells.Add(new DataGridViewTextBoxCell { Value = imageTypeString });
                    newRow.Cells.Add(new DataGridViewTextBoxCell { Value = stampPicture.scale });
                    newRow.Cells.Add(new DataGridViewTextBoxCell { Value = stampPicture.width });
                    newRow.Cells.Add(new DataGridViewTextBoxCell { Value = stampPicture.height });
                    newRow.Cells.Add(new DataGridViewTextBoxCell { Value = stampPicture.rotation });

                    newRow.Cells.Add(new DataGridViewTextBoxCell { Value = stampPicture.Id });
                    dataGridViewStamps.Rows.Add(newRow);
                }
            }









        }



        private void dataGridViewStamps_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string columnName = dataGridViewStamps.Columns[e.ColumnIndex].Name;
            string cellValue  = dataGridViewStamps.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();
            int    IdIndex    = dataGridViewStamps.Columns["GUID"].Index;
            Guid Id = (Guid)dataGridViewStamps.Rows[e.RowIndex].Cells[IdIndex].Value;

            if (columnName == "Scale" && cellValue != null)
            {
                if (float.TryParse(cellValue, out float scaleValue))
                {
                    //MessageBox.Show("������� �����: " + cellValue);
                    if (scaleValue > 0 && scaleValue < 10) 
                    {
                        updateDataStampPictures(Id,"scale", cellValue);

                    }
                    else MessageBox.Show("������� ������������ �������� ��������, ���������: " + cellValue);

                }
                else
                {
                    MessageBox.Show("����������, ������� ����� � ������� " + columnName);
                    // �������� �������� ������ ��� ��������� ������ �������� ��� �������� �����
                }
            }

            //�� �����������
            if (columnName == "XCoordinate" && cellValue != null)
            {
                if (int.TryParse(cellValue, out int scaleValue))
                {
                    //MessageBox.Show("������� �����: " + cellValue);
                    if (scaleValue > 0 && scaleValue < 400)
                    {
                        updateDataStampPictures(Id, "x", cellValue);
                    }
                    else MessageBox.Show("������� ������������ �������� ��������� �� �����������, ���������: " + cellValue);

                }
                else
                {
                    MessageBox.Show("����������, ������� ����� � ������� " + columnName);
                    // �������� �������� ������ ��� ��������� ������ �������� ��� �������� �����
                }
            }

            //�� ���������
            if (columnName == "YCoordinate" && cellValue != null)
            {
                if (int.TryParse(cellValue, out int scaleValue))
                {
                    //MessageBox.Show("������� �����: " + cellValue);
                    if (scaleValue > 0 && scaleValue < 400)
                    {
                        updateDataStampPictures(Id, "y", cellValue);
                    }
                    else MessageBox.Show("������� ������������ �������� ��������� �� ���������, ���������: " + cellValue);

                }
                else
                {
                    MessageBox.Show("����������, ������� ����� � ������� " + columnName);
                    // �������� �������� ������ ��� ��������� ������ �������� ��� �������� �����
                }
            }
            //��������
            if (columnName == "Rotation" && cellValue != null)
            {
                if (int.TryParse(cellValue, out int scaleValue))
                {
                    //MessageBox.Show("������� �����: " + cellValue);
                    if (scaleValue > 0 && scaleValue < 360)
                    {
                        updateDataStampPictures(Id, "rotation", cellValue);
                    }
                    else MessageBox.Show("������� ������������ �������� ���� ��������, ���������: " + cellValue);

                }
                else
                {
                    MessageBox.Show("����������, ������� ����� � ������� " + columnName);
                    // �������� �������� ������ ��� ��������� ������ �������� ��� �������� �����
                }
            }
        }

        private void updateDataStampPictures(Guid Id, string parameter, string value)
        {
            PDFchanged = true;
            foreach (var stampPicture in StampPicturesList)
            {
                if (stampPicture.Id == Id)
                {
                    if (parameter == "scale")
                    {
                        stampPicture.scale = float.Parse(value);
                        if (stampPicture.typePicture == 1)
                        {
                            stampPicture.width = (int)(firstStampWidth * float.Parse(value));
                            stampPicture.height = (int)(firstStampHeight * float.Parse(value));
                           
                        }
                        else if (stampPicture.typePicture == 2)
                        {
                            stampPicture.width = (int)(firstFacsimileWidth * float.Parse(value));
                            stampPicture.height = (int)(firstFacsimileHeight * float.Parse(value));
                        }
                        CreatePDFOnStampPicturesList(true);
                    }
                    else if (parameter == "x")
                    {
                        stampPicture.xCoordinate = int.Parse(value);
                        /*if (stampPicture.typePicture == 1)
                        {
                            stampPicture.xCoordinate = stampPicture.xCoordinate;                           
                        }
                        else if (stampPicture.typePicture == 2)
                        {
                            stampPicture.xCoordinate = stampPicture.xCoordinate;
                        }*/
                        CreatePDFOnStampPicturesList(true);
                    }
                    else if (parameter == "y")
                    {
                        stampPicture.yCoordinate = int.Parse(value);
                        /*if (stampPicture.typePicture == 1)
                        {
                            stampPicture.yCoordinate = stampPicture.yCoordinate;
                        }
                        else if (stampPicture.typePicture == 2)
                        {
                            stampPicture.xCoordinate = stampPicture.xCoordinate;
                        }*/
                        CreatePDFOnStampPicturesList(true);
                    }
                    else if (parameter == "rotation")
                    {
                        stampPicture.rotation = int.Parse(value);
                    }


                }


            }
        }


    }
}