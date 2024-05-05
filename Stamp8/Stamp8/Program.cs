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
                    
            //string[] argsTest = { "C:\\test\\file.pdf"  , "C:\\test\\stamp_.png" };//    , "C:\\test\\testStamp8\\facsimile.png" };
            //args = argsTest;
            if (args.Length != 0)
            {
                ApplicationConfiguration.Initialize();
                // ������������� �����������
                //InitializeLogging();
                //�������� ������� ������ � ����������� �� ���������� ����������
                if (args.Length == 3)
                {
                   //MessageBox.Show("3");
                    Application.Run(new Form1(args, 3));
                }
                else if (args.Length == 2)
                {
                    //MessageBox.Show("2");
                    Application.Run(new Form1(args, 2));
                }
                else if (args.Length == 1)
                {
                    //MessageBox.Show("1");
                    MessageBox.Show("������� ������ ���� ��������. ��������� ������ ����������");
                }
            }
            else MessageBox.Show("�� �������� �� ������ ���������");
        }        

    }

}
