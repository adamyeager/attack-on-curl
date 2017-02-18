using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AttackOnCurl.Gui
{
    public partial class DefaultView : Form
    {
        #region Properties

        //progress members
        double currentPagesComplete = 0;
        double currentPagesTotal = 0;
        double currentOverallComplete = 0;
        double currentOverallTotal = 0;
        int overallProgressPercentage = 0;
        bool singleIssue = false;

        //issue number members
        int startIssueNumber = 1;
        int endIssueNumber = 1;

        /// <summary>
        /// Gets the base URL.
        /// </summary>
        /// <value>
        /// The base URL.
        /// </value>
        private string BaseUrl
        {
            get
            {
                return baseUrlTextBox.Text;
            }
        }

        /// <summary>
        /// Gets the file path.
        /// </summary>
        /// <value>
        /// The file path.
        /// </value>
        private string FilePath
        {
            get
            {
                return filePathTextBox.Text;
            }
        }

        /// <summary>
        /// Gets the file name format.
        /// </summary>
        /// <value>
        /// The file name format.
        /// </value>
        private string FileNameFormat
        {
            get
            {
                return fileNameTextBox.Text;
            }
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultView"/> class.
        /// </summary>
        public DefaultView()
        {
            InitializeComponent();
        }


        #region Handlers

        /// <summary>
        /// Handles the Click event of the startButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void startButton_Click(object sender, EventArgs e)
        {
            bool isInputValid = ValidateInput();

            if(isInputValid)
            {
                DisableControls();

                ResetMembers();
                SetSingleIssueBool();

                currentBackgroundWorker.RunWorkerAsync();
            }
        }

        /// <summary>
        /// Handles the Click event of the saveFilePathSelectButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void saveFilePathSelectButton_Click(object sender, EventArgs e)
        {
            DialogResult saveFilePathDialogResult = folderBrowserDialogSaveFilePath.ShowDialog();
            if(saveFilePathDialogResult == DialogResult.OK)
            {
                filePathTextBox.Text = folderBrowserDialogSaveFilePath.SelectedPath;
            }
        }


        /// <summary>
        /// Handles the DoWork event of the currentBackgroundWorker control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DoWorkEventArgs"/> instance containing the event data.</param>
        private void currentBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = startIssueNumber; i <= endIssueNumber; i++ )
            {
                currentPagesComplete = 0;
                currentPagesTotal = 100000;

                if(!singleIssue)
                {
                    currentOverallTotal = (endIssueNumber + 1 - startIssueNumber);
                }

                string issueNumberString = i.ToString();
                string issueNumber = issueNumberString.ToString().PadLeft(3, '0');

                string currentSaveLocation = string.Format("{0}\\{1}", FilePath, issueNumber);
                System.IO.Directory.CreateDirectory(currentSaveLocation);
                //string nextPage = string.Format("{0}/{1}/{2}", BaseUrl, BasePath, i);
                string nextPage = BaseUrl;
                int pageNumber = 1;

                List<string> childPages = new List<string>();

                var request = (HttpWebRequest)WebRequest.Create(nextPage);
                request.UserAgent = "Mozilla/5.0";

                bool tipUrl = false;

                while(!tipUrl)
                {
                    string nextUrl = GetAndSaveChildPage(nextPage, currentSaveLocation, pageNumber);
                    pageNumber++;
                    nextPage = nextUrl;

                    if(nextUrl.EndsWith("tip") || nextUrl.EndsWith("/1"))
                    {
                        tipUrl = true;
                    }
                }

                //using (var response = request.GetResponse())
                //{
                //    using (var reader = new StreamReader(response.GetResponseStream()))
                //    {
                //        string html = reader.ReadToEnd();

                //        HtmlNode bodyNode = GetHtmlBodyNode(html);

                //        //save first page
                //        string imageUrl = GetImageUrl(bodyNode);
                //        SavePage(imageUrl, currentSaveLocation, pageNumber);
                //        IncrementProgress();

                //        //System.Threading.Thread.Sleep(waitTime);
                //        pageNumber++;
                //        Console.WriteLine("");

                //        childPages = GetPagesFromSelectHtmlElement(bodyNode);
                //    }
                //}

                //List<KeyValuePair<int, string>> numberedChildPages = new List<KeyValuePair<int, string>>();
                //foreach (var page in childPages)
                //{
                //    numberedChildPages.Add(new KeyValuePair<int, string>(pageNumber, page));
                //    pageNumber++;
                //}

                //currentPagesTotal = childPages.Count() + 1;

                //Parallel.ForEach(numberedChildPages, kvp =>
                //{
                //    GetAndSaveChildPage(kvp.Value, currentSaveLocation, kvp.Key);
                //    IncrementProgress();
                //});

                BuildCBZFile(currentSaveLocation, issueNumber);
                System.IO.Directory.Delete(currentSaveLocation, true);
            }
        }


        /// <summary>
        /// Handles the RunWorkerCompleted event of the currentBackgroundWorker control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RunWorkerCompletedEventArgs"/> instance containing the event data.</param>
        private void currentBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            EnableControls();
        }


        /// <summary>
        /// Handles the ProgressChanged event of the currentBackgroundWorker control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ProgressChangedEventArgs"/> instance containing the event data.</param>
        private void currentBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // Change the value of the ProgressBar to the BackgroundWorker progress.
            currentProgressBar.Value = e.ProgressPercentage;
            overallProgressBar.Value = overallProgressPercentage;
        }


        /// <summary>
        /// Handles the ValueChanged event of the endNumericUpDown control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void endNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (sender is NumericUpDown)
            {
                NumericUpDown senderObject = sender as NumericUpDown;
                if (senderObject.Value < startNumericUpDown.Value)
                {
                    startNumericUpDown.Value = senderObject.Value;
                }
            }
        }


        /// <summary>
        /// Handles the ValueChanged event of the startNumericUpDown control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void startNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (sender is NumericUpDown)
            {
                NumericUpDown senderObject = sender as NumericUpDown;
                if (senderObject.Value > endNumericUpDown.Value)
                {
                    endNumericUpDown.Value = senderObject.Value;
                }
            }
        }

        #endregion Handlers


        #region Private Download Methods

        private void BuildCBZFile(string location, string issueNumber)
        {
            string destinationFile = string.Format("{0}\\{1} {2}.cbz", FilePath, FileNameFormat, issueNumber);
            ZipFile.CreateFromDirectory(location, destinationFile, CompressionLevel.Optimal, true);
        }

        private string GetAndSaveChildPage(string pageUrl, string saveLocation, int pageNumber)
        {
            var request = WebRequest.Create(pageUrl);

            using (var response = request.GetResponse())
            {
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    Console.WriteLine(string.Format("Reqeusting {0}", pageUrl));

                    string html = reader.ReadToEnd();
                    Console.WriteLine("HTML received!");

                    HtmlNode bodyNode = GetHtmlBodyNode(html);

                    string imageUrl = GetImageUrl(bodyNode);
                    SavePage(imageUrl, saveLocation, pageNumber);

                    return GetNextUrl(bodyNode);
                }
            }
        }

        private void SavePage(string imageUrl, string saveLocation, int pageNumber)
        {
            string pageNumberString = pageNumber.ToString();
            string pageName = pageNumber.ToString().PadLeft(3, '0');

            string fileName = string.Format("{0}\\{1}.jpg", saveLocation, pageName);
            Console.WriteLine(string.Format("Attempting to save {0}", fileName));

            var request = WebRequest.Create(imageUrl);

            using (var response = request.GetResponse())
            {
                using (var fileStream = File.Create(fileName))
                {
                    response.GetResponseStream().CopyTo(fileStream);
                }
            }

            Console.WriteLine(string.Format("Page {0} saved!", pageNumber));
        }

        private string GetImageUrl(HtmlNode bodyNode)
        {
            if (bodyNode != null)
            {
                var imageElement = bodyNode.SelectNodes("//img[@id='manga-page']").FirstOrDefault();

                if (imageElement != null)
                {
                    if (imageElement.HasAttributes)
                    {
                        string imageUrl = imageElement.Attributes.Where(o => o.Name == "src").Select(o => o.Value).FirstOrDefault();
                        return imageUrl;
                    }
                }
            }

            return "";
        }

        private string GetNextUrl(HtmlNode bodyNode)
        {
            if(bodyNode != null)
            {
                var aNode = bodyNode.SelectNodes("//div[@class='page']//a").FirstOrDefault();

                if (aNode != null)
                {
                    if(aNode.HasAttributes)
                    {
                        string nextPageUrl = aNode.Attributes.Where(o => o.Name == "href").Select(o => o.Value).FirstOrDefault();
                        return nextPageUrl;
                    }
                }
            }

            return "";
        }

        private List<string> GetPagesFromSelectHtmlElement(HtmlNode bodyNode)
        {
            List<string> results = new List<string>();

            var options = bodyNode.SelectNodes("//*[contains(@class,'btn-reader-page')]//ul//li");

            if (options != null)
            {
                foreach (var option in options.Skip(1))
                {
                    if (option.Attributes.Count() < 2)
                    {
                        results.Add(option.FirstChild.Attributes.Select(o => o.Value).FirstOrDefault());
                    }
                }
            }

            return results;
        }

        private string GetNextPageFromHtml(HtmlNode bodyNode)
        {
            if (bodyNode != null)
            {
                // Do something with bodyNode
                var nextPageHtmlElement = bodyNode.SelectNodes("//div[@id='imgholder']//a").FirstOrDefault();

                if (nextPageHtmlElement != null)
                {
                    if (nextPageHtmlElement.HasAttributes)
                    {
                        string nextPage = nextPageHtmlElement.Attributes.Where(o => o.Name == "href").Select(o => o.Value).FirstOrDefault();

                        if (!string.IsNullOrEmpty(nextPage))
                        {
                            var parts = nextPage.Split("/".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                            if (parts.Count() > 2)
                            {
                                return nextPage;
                            }
                        }
                    }
                }
            }

            return "";
        }

        private HtmlNode GetHtmlBodyNode(string html)
        {
            HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();

            // There are various options, set as needed
            htmlDoc.OptionFixNestedTags = true;

            // filePath is a path to a file containing the html
            htmlDoc.LoadHtml(html);

            if (htmlDoc.DocumentNode != null)
            {
                var bodyNode = htmlDoc.DocumentNode.SelectSingleNode("//body");
                return bodyNode;
            }
            else
            {
                return null;
            }
        }

        #endregion Private Download Methods




        #region Private Helpers

        /// <summary>
        /// Disables the controls.
        /// </summary>
        private void DisableControls()
        {
            baseUrlTextBox.Enabled = false;
            filePathTextBox.Enabled = false;
            saveFilePathSelectButton.Enabled = false;
            fileNameTextBox.Enabled = false;
            startNumericUpDown.Enabled = false;
            endNumericUpDown.Enabled = false;
            startButton.Enabled = false;
        }


        /// <summary>
        /// Enables the controls.
        /// </summary>
        private void EnableControls()
        {
            baseUrlTextBox.Enabled = true;
            filePathTextBox.Enabled = true;
            saveFilePathSelectButton.Enabled = true;
            fileNameTextBox.Enabled = true;
            startNumericUpDown.Enabled = true;
            endNumericUpDown.Enabled = true;
            startButton.Enabled = true;
        }


        /// <summary>
        /// Validates the input.
        /// </summary>
        /// <returns></returns>
        private bool ValidateInput()
        {
            return true;
        }


        /// <summary>
        /// Resets the progress bars.
        /// </summary>
        private void ResetMembers()
        {
            currentProgressBar.Value = 0;
            overallProgressBar.Value = 0;
            currentPagesComplete = 0;
            currentPagesTotal = 0;
            currentOverallComplete = 0;
            currentOverallTotal = 0;
            overallProgressPercentage = 0;
            singleIssue = false;
        }


        /// <summary>
        /// Sets the single issue bool.
        /// </summary>
        private void SetSingleIssueBool()
        {
            startIssueNumber = Convert.ToInt32(startNumericUpDown.Value);
            endIssueNumber = Convert.ToInt32(endNumericUpDown.Value);

            if(startIssueNumber == endIssueNumber)
            {
                singleIssue = true;
            }
        }


        /// <summary>
        /// Updates the current progress.
        /// </summary>
        private void IncrementProgress()
        {
            currentPagesComplete++;
            double currentIssueProgress = (currentPagesComplete / currentPagesTotal) * 100.0;


            if (singleIssue)
            {
                overallProgressPercentage = Convert.ToInt32(currentIssueProgress);
            }
            else
            {
                double overallProgress = (currentOverallComplete / currentOverallTotal) * 100;
                overallProgressPercentage = Convert.ToInt32(overallProgress);
            }


            if(currentPagesComplete == currentPagesTotal)
            {
                currentOverallComplete++;

                if(currentOverallComplete < currentOverallTotal)
                {
                    currentBackgroundWorker.ReportProgress(0);
                }
                else
                {
                    overallProgressPercentage = 100;
                    currentBackgroundWorker.ReportProgress(100);
                }
            }
            else
            {
                currentBackgroundWorker.ReportProgress(Convert.ToInt32(currentIssueProgress));
            }
        }

        #endregion Private Helpers
    }
}