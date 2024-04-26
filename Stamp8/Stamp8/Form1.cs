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
        private iText.Layout.Element.Image globalImageStamp;
        private iText.Layout.Element.Image globalImageFacsimile;
        private int mode; //1-2-3
        private string outputPdfFilePath;
        private int pageCount;
        private bool editMode = false;
        private int currentEditPage = 1;
        private bool setFirst = true;
        private int changeMode = 0; //1-масштаб
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
        //private PdfiumViewer.PdfDocument pdfDocumentViewver;
        public Form1(string[] args, int mode)
        {
            dataGridViewStamps = null;
            //outputPdfFilePath = Path.GetTempFileName();
            this.args = args;
            outputPdfFilePath = args[0];
            this.mode = mode;
            InitializeComponent();
            setPageCount();
            //setStartSizeImage();
            CreateGlobalImages();
            //метод обновления отображения
            updatePDFViewer(args[0]);
            //метод заполнения кнопок печатей
            setButtons();
            //метод обновления режима редактиварония
            updateEditMode(false);
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
                editMode = true;
                textBoxEditMode.Text = "Режим редактирования";
                textBoxEditMode.BackColor = System.Drawing.Color.Red;
                labelCurrentPage.Visible = true;
                numericUpDownCurrentPage.Visible = true;
                numericUpDownCurrentPage.Maximum = pageCount;
                установитьПечатиToolStripMenuItem.Visible = false;
                if (mode == 3) 
                {
                   // comboBoxChangeObject.Maximum = 2;
                }
                режимПросмотраToolStripMenuItem.Visible = true;
                режимРедактированияToolStripMenuItem.Visible = false;
                dataGridViewStamps.Visible = true;
            }
            else
            {
                editMode = false;
                textBoxEditMode.Text = "Режим просмотра";
                textBoxEditMode.BackColor = System.Drawing.Color.LightBlue;
                labelCurrentPage.Visible = false;
                numericUpDownCurrentPage.Visible = false;
                установитьПечатиToolStripMenuItem.Visible = true;
                режимПросмотраToolStripMenuItem.Visible = false;
                режимРедактированияToolStripMenuItem.Visible = true;
                dataGridViewStamps.Visible = false;
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
        }

        private void setPageCount()
        {
            // Создание объекта PdfDocument
            using (iText.Kernel.Pdf.PdfDocument pdfDocument = new iText.Kernel.Pdf.PdfDocument(new PdfReader(args[0])))
            {
                // Получение количества страниц в документе
                pageCount = pdfDocument.GetNumberOfPages();
                // Получение размеров каждой страницы
                for (int i = 1; i <= pageCount; i++)
                {
                    // Получение объекта размеров страницы
                    var pageSize = pdfDocument.GetPage(i).GetPageSize();

                    // Ширина страницы
                    widthPagePDF = pageSize.GetWidth();

                    // Высота страницы
                    heightPagePDF = pageSize.GetHeight();

                    // Вывод размеров страницы
                    //Console.WriteLine($"Размер страницы {i}: Ширина = {width}, Высота = {height}");
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


        private void установитьПечатиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StampPicturesList.Clear();
            outputPdfFilePath = args[0];
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
            StampPicturesList.Clear();
            
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
                            //Console.WriteLine(originalString); // Выведет "Это  строки для удаления подстроки"
                            int number;
                            if (int.TryParse(originalString, out number))
                            {
                                MessageBox.Show("Ставим печать на странице №" + number);
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
                                MessageBox.Show("Ошибка при преобразовании в число при поиске страниц");
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
                        string substringToRemove = "Стр ";

                        int index = originalString.IndexOf(substringToRemove); // Находим индекс начала подстроки
                        if (index != -1)
                        {
                            originalString = originalString.Remove(index, substringToRemove.Length); // Удаляем подстроку
                            //Console.WriteLine(originalString); // Выведет "Это  строки для удаления подстроки"
                            int number;
                            if (int.TryParse(originalString, out number))
                            {
                                MessageBox.Show("Ставим подпись на странице №" + number);
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
                                //updatePDFViewer(outputPdfFilePath);
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
                        //outputPdfFilePath = System.IO.Path.ChangeExtension(System.IO.Path.GetTempFileName(), ".pdf");
                        outputPdfFilePath = await OverlayImageOnPDF8(outputPdfFilePath, args[1], indexer.xCoordinate, indexer.yCoordinate, indexer.width, indexer.width, indexer.pageNumber, indexer.typePicture, indexer.scale, indexer.rotation);
                        isUpdate= false;
                     }
                    
                    if (indexer.typePicture == 2)
                    {
                        //outputPdfFilePath = System.IO.Path.ChangeExtension(System.IO.Path.GetTempFileName(), ".pdf");
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
                // Получаем страницу, на которую нужно добавить изображение
                PdfPage page = pdfDocument.GetPage(pageNumber);

                //PdfLayer layer = new PdfLayer("Stamp", pdfDocument);

                // Добавляем слой в документ
                //pdfDocument.GetCatalog().AddOCGRadioGroup(layer);

                //PdfLayer pdflayer = new PdfLayer("Stamp", pdfDocument); //+
                //pdflayer.IsOn();                                        //+

                // Создаем объект изображения
                iText.Layout.Element.Image image = new iText.Layout.Element.Image(ImageDataFactory.Create(pathPicture));




                // Устанавливаем позицию и размер изображения
                image.SetFixedPosition(xCoordinate, yCoordinate);
                image.SetWidth(width);
                //image.SetWidth(image.GetImageWidth());
                image.SetHeight(height);
                image.Scale(scale, scale);
                //image.SetHeight(image.GetImageHeight());

                // Создаем прямоугольник, представляющий область страницы
                iText.Kernel.Geom.Rectangle pageSize = page.GetPageSize();

                // Создаем объект Canvas для добавления изображения на страницу
                Canvas canvas = new Canvas(new PdfCanvas(page), pageSize);

                // Добавляем изображение на страницу
                //canvas.BeginLayer(ocg);
                canvas.Add(image);
                canvas.Close();
                //globalPdfDocument = pdfDocument;

            }

            return outputPdfFilePath;
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


        private async void тестToolStripMenuItem_ClickAsync(object sender, EventArgs e)
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
                //image.SetWidth(width);
                image.SetWidth(image.GetImageWidth());
                //image.SetHeight(height);
                image.SetHeight(image.GetImageHeight());

                // Создаем прямоугольник, представляющий область страницы
                iText.Kernel.Geom.Rectangle pageSize = page.GetPageSize();

                // Создаем объект Canvas для добавления изображения на страницу
                Canvas canvas = new Canvas(new PdfCanvas(page), pageSize);

                // Добавляем изображение на страницу
                //canvas.BeginLayer(ocg);
                canvas.Add(image);
                canvas.Close();
                //globalPdfDocument = pdfDocument;
                // Создаем экземпляр StampPictures
                StampPictures stampPictures = new StampPictures();
                stampPictures.image       = image;
                stampPictures.filePath    = imageFilePath;
                stampPictures.pageNumber  = pageNumber;
                stampPictures.typePicture = typePicture;
                StampPicturesList.Add(stampPictures);
            }           


            return outputPdfFilePath;
        }

        private void режимРедактированияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updateEditMode(true);
        }

        private void режимПросмотраToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updateEditMode(false);
        }

        private void numericUpDownCurrentPage_ValueChanged(object sender, EventArgs e)
        {
            currentEditPage = (int)numericUpDownCurrentPage.Value;
        }


/*
        private async void trackBarChange_Scroll(object sender, EventArgs e)
        {
            if (changeMode== 0) 
            {
                MessageBox.Show("Не выбран ни один режим изменения");
            }
            else if (changeMode==1) 
            {

                //MessageBox.Show(StampPicturesList.Count().ToString());
                foreach (var stampPicture in StampPicturesList)
                {
                    if (currentEditPage == stampPicture.pageNumber) 
                    {
                      //MessageBox.Show(stampPicture.pageNumber.ToString());
                        //определяем, какой объект меняем
                        string selectedValue = comboBoxChangeObject.SelectedItem.ToString();
                        if (selectedValue == "Печать") 
                        { 
                            if (stampPicture.typePicture == 1) 
                            {
                                stampPicture.scale = trackBarChange.Value;
                                //stampPicture.image.Scale(trackBarChange.Value, trackBarChange.Value);
                                //var result = await updateAddingImage(stampPicture);

                            }
                        }
                        else if (selectedValue == "Подпись")
                        {
                            if (stampPicture.typePicture == 2)
                            {
                                stampPicture.scale = trackBarChange.Value;
                                //stampPicture.image.Scale(trackBarChange.Value, trackBarChange.Value);
                                //var result = await updateAddingImage(stampPicture);
                            }
                        }
                        CreatePDFOnStampPicturesList();
                        //updatePDFViewer(outputPdfFilePath);
                    }
                    else
                    {
                        MessageBox.Show("На выбранной странице нет объектов для редактирования");
                    }
                }
            }
        }*/

        async Task<string> updateAddingImage(StampPictures stampPicture)
        {
            outputPdfFilePath = System.IO.Path.ChangeExtension(System.IO.Path.GetTempFileName(), ".pdf");
            using (PdfReader pdfReader = new PdfReader(args[0]))
            using (PdfWriter pdfWriter = new PdfWriter(outputPdfFilePath))
            using (var pdfDocument = new iText.Kernel.Pdf.PdfDocument(pdfReader, pdfWriter))
            {
                PdfPage page = pdfDocument.GetPage(stampPicture.pageNumber);
                // Создаем прямоугольник, представляющий область страницы
                iText.Kernel.Geom.Rectangle pageSize = page.GetPageSize();
                // Создаем объект Canvas для добавления изображения на страницу
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
                    if (stampPicture.typePicture == 1) imageTypeString = "Печать";
                    if (stampPicture.typePicture == 2) imageTypeString = "Подпись";
                    DataGridViewRow newRow = new DataGridViewRow();
                    // Добавляем ячейки в строку
                    newRow.Cells.Add(new DataGridViewTextBoxCell { Value = imageTypeString });
                    newRow.Cells.Add(new DataGridViewTextBoxCell { Value = stampPicture.scale });


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
                    //MessageBox.Show("Введено число: " + cellValue);
                    if (scaleValue > 0 && scaleValue < 10) 
                    {
                        updateDataStampPictures(Id,"scale", cellValue);

                    }
                    else MessageBox.Show("Введено некорректное значение масштаба, исправьте: " + cellValue);

                }
                else
                {
                    MessageBox.Show("Пожалуйста, введите число в столбец " + columnName);
                    // Очистить значение ячейки или выполнить другие действия при неверном вводе
                }
            }
        }

        private void updateDataStampPictures(Guid Id, string parameter, string value)
        {
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



                }


            }
        }
    }
}