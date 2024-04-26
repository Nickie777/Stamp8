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
            string[] argsTest = { "C:\\test\\testStamp8\\file.pdf" };// , "C:\\test\\testStamp8\\stamp_.png" };//    , "C:\\test\\testStamp8\\facsimile.png" };
            //args = argsTest;
            if (args.Length != 0)
            {
                ApplicationConfiguration.Initialize();

                //выбираем вариант работы в зависимости от количества аргументов
                if (args.Length == 3)
                {
                    MessageBox.Show("3");
                    Application.Run(new Form1(args, 3));
                }
                else if (args.Length == 2)
                {
                    MessageBox.Show("2");
                    Application.Run(new Form1(args, 2));
                }
                else if (args.Length == 1)
                {
                    MessageBox.Show("1");
                    MessageBox.Show("Передан только один аргумент. Установка печати невозможна");
                }
                //MessageBox.Show(args.Length.ToString());
            }
            else MessageBox.Show("Не передано ни одного аргумента");
        }
    }
}