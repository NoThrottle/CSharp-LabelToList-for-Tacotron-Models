using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Shell.PropertySystem;

namespace filename_to_list
{
    public partial class Form1 : Form
    {
        #region Private Variables
        string inpath = null;
        string outend = null;
        List<string> filestotrans = new List<string>();
        List<string> pathoffilestotrans = new List<string>();
        List<string> rawpathfilestotrans = new List<string>();
        List<string> voiceline = new List<string>();

        static string logline = null;

        static int maxval = 1;
        static int curval = 0;

        TextWriter _writer = null;
        #endregion

        //Edit These
        string extension = "wav"; //"wav" default

        private void listadd(int i, string line)
        {
            voiceline.Add("wavs/" + i + ".wav| " + line);
        }

        //-----------
        //Don't touch anything below unless you're modifying 'the software'.

        public Form1()
        {
            InitializeComponent();
        }

        private void ListOfFiles()
        {
            FileInfo[] files = new DirectoryInfo(inpath).GetFiles().AsEnumerable().OrderBy(item => item.FullName, new NaturalSortComparer<string>()).ToArray();
            progressBar1.Maximum = files.Length;
            progressBar1.Value = 0;

            int i = 0;
            foreach (FileInfo file in files)
            {
                Console.WriteLine(file.Directory.ToString());

                string end = file.FullName.Substring(file.FullName.Length - extension.Length, extension.Length);
                curval = i;
                progressBar1.Value = curval;

                if (end == extension)
                {
                    filestotrans.Add(ShellFile.FromFilePath(Path.Combine(file.Directory.ToString(), file.FullName)).Properties.System.Title.Value);
                    rawpathfilestotrans.Add(file.Directory.ToString());
                    pathoffilestotrans.Add(Path.Combine(file.Directory.ToString(), file.FullName));

                    logline = ("Added:" + file.FullName + " From: " + file.Directory.ToString());
                    i++;
                }
                else
                {
                    i++;
                }
            }
        }

        private void processfiles()
        {
            Console.WriteLine("Processing Files");

            progressBar1.Maximum = filestotrans.Count;
            curval = 0;
            int i = 0;

            foreach(string filesto in filestotrans)
            {
                curval++;
                Console.WriteLine("Processing: " + pathoffilestotrans[i]);
                Console.WriteLine("To: " + Path.Combine(rawpathfilestotrans[i], i + "." + extension));
                System.IO.File.Move(pathoffilestotrans[i], Path.Combine(rawpathfilestotrans[i], i + "." + extension));
                listadd(i, filestotrans[i]);
                Console.WriteLine("Added to list: " + voiceline[i]);
                progressBar1.Value = curval;
                i++;
            }
        }

        private void writelist()
        {
            Console.WriteLine("Writing to File");
            StreamWriter sw = new StreamWriter(Path.Combine(outend, "list.txt"));

            progressBar1.Maximum = voiceline.Count;
            curval = 0;


            foreach (var voice in voiceline)
            {
                
                curval++;
                progressBar1.Value = curval;
                Console.WriteLine(voice);
                sw.WriteLine(voice);
            }

            sw.Close();
        }

        private void writeLogs()
        {
            Console.WriteLine("Writing Logs");
            StreamWriter sw = new StreamWriter(Path.Combine(outend, "logs." + DateTime.Now.ToFileTime() + ".txt"));
            progressBar1.Maximum = logs.Text.Split(
                        new string[] { Environment.NewLine },
                        StringSplitOptions.None).Length;
            curval = 0;



            foreach (var voice in logs.Text.Split(
                        new string[] { Environment.NewLine },
                        StringSplitOptions.None))
            {

                curval++;
                progressBar1.Value = curval;
            }

            sw.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _writer = new TextBoxStreamWriter(logs);
            // Redirect the out Console stream
            Console.SetOut(_writer);
        }

        private void inbrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog give = new FolderBrowserDialog();
            give.ShowDialog();

            filepath.Text = give.SelectedPath;
            outpath.Text = filepath.Text;

        }

        private void outbrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog give = new FolderBrowserDialog();
            give.ShowDialog();

            outpath.Text = give.SelectedPath;
        }

        private void start_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(outpath.Text) && string.IsNullOrEmpty(filepath.Text)) 
            {
                MessageBox.Show("At least one of the paths are empty", "Error", MessageBoxButtons.OK);

            }
            else
            {

                filestotrans = null;
                rawpathfilestotrans = null;
                voiceline = null;
                pathoffilestotrans = null;

                filestotrans = new List<string>();
                rawpathfilestotrans = new List<string>();
                voiceline = new List<string>();
                pathoffilestotrans = new List<string>();

                Console.WriteLine("Initiated");

                inpath = filepath.Text;
                outend = outpath.Text;

                ListOfFiles();
                processfiles();
                writelist();
                writeLogs();
            }


        }
    }

    public class TextBoxStreamWriter : TextWriter
    {
        TextBox _output = null;

        public TextBoxStreamWriter(TextBox output)
        {
            _output = output;
        }

        public override void Write(char value)
        {
            base.Write(value);

            if (value.ToString() == "\n")
            {
                _output.AppendText("\r\n" + DateTime.Now + ": "); // When character data is written, append it to the text box.

            }
            else
            {
                _output.AppendText(value.ToString());
            }

        }

        public override Encoding Encoding
        {
            get { return System.Text.Encoding.UTF8; }
        }
    }

    public class NaturalSortComparer<T> : IComparer<string>, IDisposable
    {
        private bool isAscending;

        public NaturalSortComparer(bool inAscendingOrder = true)
        {
            this.isAscending = inAscendingOrder;
        }

        #region IComparer<string> Members

        public int Compare(string x, string y)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IComparer<string> Members

        int IComparer<string>.Compare(string x, string y)
        {
            if (x == y)
                return 0;

            string[] x1, y1;

            if (!table.TryGetValue(x, out x1))
            {
                x1 = Regex.Split(x.Replace(" ", ""), "([0-9]+)");
                table.Add(x, x1);
            }

            if (!table.TryGetValue(y, out y1))
            {
                y1 = Regex.Split(y.Replace(" ", ""), "([0-9]+)");
                table.Add(y, y1);
            }

            int returnVal;

            for (int i = 0; i < x1.Length && i < y1.Length; i++)
            {
                if (x1[i] != y1[i])
                {
                    returnVal = PartCompare(x1[i], y1[i]);
                    return isAscending ? returnVal : -returnVal;
                }
            }

            if (y1.Length > x1.Length)
            {
                returnVal = 1;
            }
            else if (x1.Length > y1.Length)
            {
                returnVal = -1;
            }
            else
            {
                returnVal = 0;
            }

            return isAscending ? returnVal : -returnVal;
        }

        private static int PartCompare(string left, string right)
        {
            int x, y;
            if (!int.TryParse(left, out x))
                return left.CompareTo(right);

            if (!int.TryParse(right, out y))
                return left.CompareTo(right);

            return x.CompareTo(y);
        }

        #endregion

        private Dictionary<string, string[]> table = new Dictionary<string, string[]>();

        public void Dispose()
        {
            table.Clear();
            table = null;
        }
    }
}
