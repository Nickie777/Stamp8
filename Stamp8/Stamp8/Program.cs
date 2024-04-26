namespace Stamp8
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args != null)
            {
                ApplicationConfiguration.Initialize();
                //string[] argsTest = { "C:\\test\\testStamp8\\file.pdf", "C:\\test\\testStamp8\\stamp_.png", "C:\\test\\testStamp8\\facsimile.png" };
                //args = argsTest;
                //выбираем вариант работы в зависимости от количества аргументов
                if (args.Length == 3)
                {
                    Application.Run(new Form1(args, 3));
                }
                else if (args.Length == 2)
                {
                    Application.Run(new Form1(args, 2));
                }
                else if (args.Length == 1)
                {
                    MessageBox.Show("Передан только один аргумент. Установка печати невозможна");
                }
                MessageBox.Show("Запуск программы необходимо осуществлять из 1С");
            }



        }
    }
}