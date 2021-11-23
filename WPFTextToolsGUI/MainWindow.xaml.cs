using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFTextGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static string bigfilesdir = @"c:\Users\pes.PHA\source\repos\PeSul\NET2\Playground\BigFiles";

        static IEnumerable<string> GetBigFiles()
        {
            return Directory.EnumerateFiles(bigfilesdir, "*.txt");
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //var bookdir = @"C:\Users\Student\source\repos\CNET2\Books";

            //foreach (var file in GetFilesFromDir(bookdir))
            //{
            //    var dict = TextTools.TextTools.FreqAnalysis(file);
            //    var top10 = TextTools.TextTools.GetTopWords(10, dict);
            //    var fi = new FileInfo(file);

            //    txbInfo.Text += fi.Name + Environment.NewLine;
            //    foreach (var kv in top10)
            //    {
            //        txbInfo.Text += $"{kv.Key}: {kv.Value} {Environment.NewLine}";
            //    }
            //    txbInfo.Text += Environment.NewLine;
            //}
        }

        static IEnumerable<string> GetFilesFromDir(string dir)
        {
            return Directory.EnumerateFiles(dir);
        }

        private async void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Wait;

            txbInfo.Text = txbDebugInfo.Text = "";
            Stopwatch stopwatch = new();
            stopwatch.Start();
            
            var files = GetBigFiles();

            //var bigfilesdir = @"c:\Users\pes.PHA\source\repos\PeSul\NET2\Playground\BigFiles";

            //var files = Directory.EnumerateFiles(bigfilesdir, "*.txt");

            //var file = System.IO.Path.Combine(bigfiles, "words01.txt");

            //var files = Directory.EnumerateFiles(bigfilesdir);

            foreach (var file in files)
            {
                var wordsstat = await TextTools.TextTools.FreqAnalysisFromFileAsync(file, Environment.NewLine);
                var top10 = TextTools.TextTools.GetTopWords(10, wordsstat);

                var fi = new FileInfo(file);
                txbInfo.Text += fi.Name + Environment.NewLine;
                foreach (var kv in top10)
                {
                    txbInfo.Text += $"{kv.Key}: {kv.Value} {Environment.NewLine}";
                }
                txbInfo.Text += Environment.NewLine;
                txbDebugInfo.Text += $"mezičas ms: {stopwatch.ElapsedMilliseconds} {Environment.NewLine}";

            }

            stopwatch.Stop();
            txbDebugInfo.Text += "celkový čas ms:" + stopwatch.ElapsedMilliseconds;

            Mouse.OverrideCursor = null;

            //var content = File.ReadAllText(file);

            //txbInfo.Text = "Načteno";

            //var xx = content.Split(Environment.NewLine).Count();
        }

        private async void btnAwaitDemo_Click(object sender, RoutedEventArgs e)
        {
            txbDebugInfo.Text = "button clecked";

            await Task.Delay(5000);

            txbDebugInfo.Text = "task done";

        }

        private void btnStatAll_Click(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Wait;

            txbInfo.Text = txbDebugInfo.Text = "";
            Stopwatch stopwatch = new();
            stopwatch.Start();
            

            var files = GetBigFiles();

            var allwords =
                string.Join(Environment.NewLine,
                files.Select(f => File.ReadAllText(f)));

            var dict = TextTools.TextTools.FreqAnalysisFromString(allwords, Environment.NewLine);
            var top10 = TextTools.TextTools.GetTopWords(10, dict);

            foreach (var kv in top10)
            {
                txbInfo.Text += $"{kv.Value}: {kv.Key} {Environment.NewLine}";
            }

            stopwatch.Stop();
            txbDebugInfo.Text += "celkový čas ms:" + stopwatch.ElapsedMilliseconds;
            Mouse.OverrideCursor = null;

            //txbDebugInfo.Text = "ok";
        }
    }
}