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
            //метод обновления отображения
            updatePDFViewer(args[0]);
            //метод заполнения кнопок печатей
            setButtons();
            //метод обновления режима редактиварония
            updateEditMode(false);
        }

        private void updateEditMode(bool value)
        {
            if (value) 
            {
                editMode = true;
                textBoxEditMode.Text = "Режим редактирования";
                textBoxEditMode.BackColor = System.Drawing.Color.Red;
                labelCurrentPage.Visible = true;
                numericUpDownCurrentPage.Visible = true;
            }
            else
            {
                editMode = false;
                textBoxEditMode.Text = "Режим просмотра";
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
                    //скрываем базовые печати
                    groupBox1.Visible = false;
                    //печати без подписей
                    var button = new Button();
                    button.Text = $"Стр {i}";
                    button.BackColor = System.Drawing.Color.LightBlue;
                    button.Width = 50;
                    button.Margin = new Padding(3); // Отступ между кнопками
                    button.Click += Button_Click; // Обработчик события Click
                    flowLayoutPanel1.Controls.Add(button);
                    //подписи
                    var button1 = new Button();
                    button1.Text = $"Стр {i}";
                    button1.BackColor = System.Drawing.Color.LightBlue;
                    button1.Width = 50;
                    button1.Margin = new Padding(3); // Отступ между кнопками
                    button1.Click += Button1_Click; // Обработчик события Click
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
            // Создание объекта PdfDocument
            using (iText.Kernel.Pdf.PdfDocument pdfDocument = new iText.Kernel.Pdf.PdfDocument(new PdfReader(args[0])))
            {
                // Получение количества страниц в документе
                pageCount = pdfDocument.GetNumberOfPages();
                // Закрытие PdfDocument
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
                // Определение координат для размещения изображения на странице PDF
                //float x = 100;
                //float y = 100;
                // Получение страницы PDF
                PdfPage page = pdfDocument.GetPage(pageNumber);
                // Создание Canvas для страницы PDF
                PdfCanvas canvas = new PdfCanvas(page);
                // Наложение изображения на страницу PDF с помощью Canvas
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

                // Загрузка изображения из потока
                /*byte[] imageDataBytes;
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    imageStream.CopyTo(memoryStream);
                    imageDataBytes = memoryStream.ToArray();
                }*/

                // Создание ImageData из байтов
                ImageData imageData = ImageDataFactory.Create(imageFilePath);
                // Установка размера изображения
                imageData.SetWidth(200);
                imageData.SetHeight(200);

                // Определение координат для размещения изображения на странице PDF
                float x = 100;
                float y = 100;

                // Получение страницы PDF
                PdfPage page = pdfDocument.GetFirstPage();
                // Создание Canvas для страницы PDF
                PdfCanvas canvas = new PdfCanvas(page);

                // Наложение изображения на страницу PDF
                //canvas.AddImage (imageData, x, y, true);
                //document.Add(imageData);
                // Закрытие документа
                document.Close();
            }
        }


        private void установитьПечатиToolStripMenuItem_Click(object sender, EventArgs e)
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
            
            //заполняем класс картинок
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
                        string substringToRemove = "Стр ";

                        int index = originalString.IndexOf(substringToRemove); // Находим индекс начала подстроки
                        if (index != -1)
                        {
                            originalString = originalString.Remove(index, substringToRemove.Length); // Удаляем подстроку
                            Console.WriteLine(originalString); // Выведет "Это  строки для удаления подстроки"
                            int number;
                            if (int.TryParse(originalString, out number))
                            {
                                MessageBox.Show("Ставим печать на странице №" + number);
                                //await OverlayImageOnPDF5(outputPdfFilePath, args[1], firstStampCoordinateX, firstStampCoordinateY, firstStampWidth, firstStampHeight, number);
                                var v = await OverlayImageOnPDF6(outputPdfFilePath, args[1], firstStampCoordinateX, firstStampCoordinateY, firstStampWidth, firstStampHeight, number);
                                updatePDFViewer(outputPdfFilePath);
                                //MessageBox.Show(outputPdfFilePath);
                            }
                            else
                            {
                                MessageBox.Show("Ошибка при преобразовании в число при поиске страниц");
                            }





                        }

                    }
                }
            }
        }

        private void заполнитьКнопкиПечатейToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mode == 3)
            {
                for (var i=1; i<=pageCount; i++) 
                {
                    //скрываем базовые печати
                    groupBox1.Visible = false;
                    //печати без подписей
                    var button = new Button();
                    button.Text = $"Стр {i}";
                    button.BackColor = System.Drawing.Color.LightBlue;
                    button.Width = 50;
                    button.Margin = new Padding(3); // Отступ между кнопками
                    button.Click += Button_Click; // Обработчик события Click
                    flowLayoutPanel1.Controls.Add(button);
                    //подписи
                    var button1 = new Button();
                    button1.Text = $"Стр {i}";
                    button1.BackColor = System.Drawing.Color.LightBlue;
                    button1.Width = 50;
                    button1.Margin = new Padding(3); // Отступ между кнопками
                    button1.Click += Button1_Click; // Обработчик события Click
                    flowLayoutPanel2.Controls.Add(button1);
                }
              

            }

            
        }

        private void Button1_Click(object? sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            //реализуем изменения цвета при нажатии
            if (clickedButton.BackColor == System.Drawing.Color.Coral)
                clickedButton.BackColor = System.Drawing.Color.LightBlue;
            else
                clickedButton.BackColor = System.Drawing.Color.Coral;
        }

        private void Button_Click(object? sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            //реализуем изменения цвета при нажатии
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

                // Получаем страницу, на которую нужно добавить изображение
                PdfPage page = pdfDocument.GetPage(2);

                // Загружаем изображение
                ImageData imageData = ImageDataFactory.Create(imageFilePath);

                // Создаем объект изображения
                iText.Layout.Element.Image image = new iText.Layout.Element.Image(imageData);

                // Устанавливаем позицию и размер изображения
                image.SetFixedPosition(x, y);
                image.SetWidth(width);
                image.SetHeight(height);

                // Добавляем изображение на страницу
                doc.Add(image);
                // Добавляем изображение на страницу
                //new Document(page.GetDocument()).Add(image);

            }
            return outputPdfFilePath;
            //MessageBox.Show(outputPdfFilePath);
        }

        private async void тестToolStripMenuItem_ClickAsync(object sender, EventArgs e)
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
                // Получаем страницу, на которую нужно добавить изображение
                PdfPage page = pdfDocument.GetPage(pageNumber);



 

                //PdfLayer layer = new PdfLayer("Stamp", pdfDocument);

                // Добавляем слой в документ
                //pdfDocument.GetCatalog().AddOCGRadioGroup(layer);

                //PdfLayer pdflayer = new PdfLayer("Stamp", pdfDocument); //+
                //pdflayer.IsOn();                                        //+
                
                // Создаем объект изображения
                iText.Layout.Element.Image image = new iText.Layout.Element.Image(ImageDataFactory.Create(imageFilePath));



                // Устанавливаем позицию и размер изображения
                image.SetFixedPosition(x, y);
                image.SetWidth(width);
                image.SetHeight(height);

                // Создаем прямоугольник, представляющий область страницы
                iText.Kernel.Geom.Rectangle pageSize = page.GetPageSize();

                // Создаем объект Canvas для добавления изображения на страницу
                Canvas canvas = new Canvas(new PdfCanvas(page), pageSize);

                // Добавляем изображение на страницу
                //canvas.BeginLayer(ocg);
                canvas.Add(image);
                // Создаем экземпляр StampPictures
                StampPictures stampPictures = new StampPictures();
                stampPictures.image = image;
                stampPictures.filePath = imageFilePath;
                stampPictures.pageNumber= pageNumber;
                StampPicturesList.Add(stampPictures);
            }           


            return outputPdfFilePath;
        }

        private void режимРедактированияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updateEditMode(true);
        }
    }
}