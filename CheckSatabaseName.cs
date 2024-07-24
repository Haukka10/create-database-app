using CounterFiles;
using DATABASE_useing_CSharp.CheckValues;

namespace DATABASE_useing_CSharp.P
{
    internal class CheckNameSever
    {
        private ChecksNameValues checksNameValues1 = new ChecksNameValues();
        private ErrorsFiles ErrorsFiles = new ErrorsFiles();
        public List<string> NamesBD = new List<string>();
        private HDIRinfo HDIRinfo = new HDIRinfo();
        private int a = 0;
        /// <summary>
        /// Get server name from files 
        /// </summary>
        /// <param name="path"></param>
        public void CheckServerName(string path)
        {
            HDIRinfo.CheckSpaceToWereSeveF();
            HDIRinfo.CounterFiles(path);

            for (ErrorsFiles.CurrentFiles = 0; ErrorsFiles.CurrentFiles < HDIRinfo.DirList.Length; ErrorsFiles.CurrentFiles++)
            {
                try
                {
                    ErrorsFiles.ErrorNamesFiles = HDIRinfo.DirList.GetValue(ErrorsFiles.CurrentFiles).ToString();

                    if (ErrorsFiles.ErrorNamesFiles is not null)
                    {

                        ErrorsFiles.ErrorsFilesPath = ErrorsFiles.ErrorNamesFiles;

                    }else
                    {
                        Console.WriteLine("Error ErrorsFiles.ErrorNamesFiles is null");
                        return;
                    }
                    var FRAL = File.ReadAllLines(ErrorsFiles.ErrorsFilesPath);
                    var Names = FRAL[1]; // get 2 index from files

                    string FullName = Names.Remove(0, 3); // remove first 3 letter 
                    var FixName = FullName.Remove(FullName.Length - 1, 1); // remove last 1 letter
                    NamesBD.Add(ErrorsFiles.ErrorsFilesPath); // set to list path files 

                    if (NamesBD.Count > 0)
                    {
                        NamesShow(FixName);
                    }
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error can't open file and read him " + ErrorsFiles.ErrorNamesFiles.ToString());
                    Console.ResetColor();
                    ErrorsFiles.AllFiles = HDIRinfo.DirList.Length;
                    checksNameValues1.DeleteErrorFile(ErrorsFiles.ErrorsFilesPath, ErrorsFiles.ErrorsFilesPath);
                    return;
                }
            }
            a = 0;
        }
        private void NamesShow(string Names)
        {
            Console.WriteLine($"{a}. Names Databesa is {Names}");
            a++;
        }
    }
}
