//Franky Jiang
//April 25th
//File input and output exercise
//Notepad
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace _7Notepad
{
    public partial class NotepadForm : Form
    {
        //simple text editor
        //ability to save work
        //ability to load work
        //Ability to load previous version of work
        
        //Type of file
        private const string DEFAULT_FILE_EXTENTSION = "txt";

        //Stores all revisions
        private List<Revision> allRevisions = new List<Revision>();

        //Current revision number
        private int displayIndex;

        //0 is valid index to show nothing
        private const int DISPLAY_NOTHING = -1;
        
        public NotepadForm()
        {
            InitializeComponent();
            displayIndex = DISPLAY_NOTHING;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            //Make sure the user tyoed file name
            if (txtFileName.Text != "")
            {
                //Handle unforseeable errors
                try
                {
                    string fileName = txtFileName.Text + "." + DEFAULT_FILE_EXTENTSION;
                    if (File.Exists(fileName) == false)
                    {
                        using (StreamWriter file = new StreamWriter(fileName))
                        {
                            Revision edit = new Revision(1, DateTime.Now, txtContent.Text, CreateDelimiter());
                            OutputAllRevision(file, edit, true);

                            allRevisions.Clear();
                            allRevisions.Add(edit);
                        }

                    }

                    //If the file exists
                    else
                    {
                        //Reload the revisions
                        string entireFile = "";

                        //we need to see if the user typed in this old delimiter anywhere
                        string oldDelimiter;

                        using (StreamReader input = new StreamReader(fileName))
                        {
                            oldDelimiter = input.ReadLine();
                            entireFile = oldDelimiter + "\r\n" + input.ReadToEnd();
                        }

                        //If the oldDelimiter is in the textbox, we have to replacfe all the
                        if (txtContent.Text.Contains(oldDelimiter))
                        {
                            string newDelimiter;
                            do
                            {
                                newDelimiter = CreateDelimiter();

                            } while (txtContent.Text.Contains(newDelimiter) || entireFile.Contains(newDelimiter));

                            //Replace old delimiter with new delimiter
                            entireFile = entireFile.Replace(oldDelimiter, newDelimiter);

                            //Recreates the save file with new delimiter
                            using (StreamWriter saveFile = new StreamWriter(fileName))
                            {
                                saveFile.Write(entireFile);
                            }


                        }

                        allRevisions = LoadFile(txtFileName.Text);

                        Revision newRevision = new Revision(allRevisions.Count + 1, DateTime.Now, txtContent.Text, allRevisions[0].Delimiter);
                        allRevisions.Add(newRevision);

                        using (StreamWriter outputFile = new StreamWriter(fileName, true))
                        {
                            OutputAllRevision(outputFile, newRevision, false);
                        }

                    }

                    DisplayRevision(allRevisions[allRevisions.Count - 1]);
                    displayIndex = allRevisions.Count - 1;

                }

                catch (Exception ex)
                {
                    MessageBox.Show("Could not save file.", "Unknown error");

                }
            }

            else
            {
                MessageBox.Show("You failed to input a file name!!!");
            }
        }

        /// <summary>
        /// Saves revision to end of file
        /// </summary>
        /// <param name="file"></param>
        /// <param name="allRevisions"></param>
        /// <param name="startOfFile"></param>
        private void OutputAllRevision(StreamWriter file, Revision allRevisions, bool startOfFile)
        {
            //If this file is not empty, make a line to separate the revision
            if(!startOfFile)
            {
                file.WriteLine("\r\n");
            }
            file.WriteLine(allRevisions.Delimiter);           //Creates a random set of numbers 15 characters long
            file.WriteLine(allRevisions.RevisionNumber);
            file.WriteLine(allRevisions.RevisionDate);
            file.WriteLine(allRevisions.Content);
        }

        private string CreateDelimiter()
        {
            //Delimiter
            string delimiter = "";
            //Creates random numbers
            Random generator = new Random();
            //loop to create random numbers
            for (int i = 0; i < 15; i++)
            {
                delimiter += generator.Next(0, 10);
            }
            return delimiter;
        }


        private void btnLoad_Click(object sender, EventArgs e)
        {
            allRevisions = LoadFile(txtFileName.Text);
            if (allRevisions.Count > 0)
            {
                displayIndex = allRevisions.Count - 1;
                DisplayRevision(allRevisions[allRevisions.Count - 1]);
            }
        }

        private List <Revision> LoadFile(string fileName)
        {
            //Make sure there is a load file
            if (txtFileName.Text != "")
            {
                //Attempt to load file
                try
                {
                    using (StreamReader file = new StreamReader(fileName+ "." + DEFAULT_FILE_EXTENTSION))
                    {
                        //Stores each revision successfully loaded from the file. Copy it to allRevisions if file loads
                        List<Revision> loadedRevisions = new List<Revision>();
                        string delimiter, revisionNumber, dateTime, actualText;

                        delimiter = file.ReadLine();

                        //Start reading the next revision as long as there is more file to input
                        while (file.Peek() != -1)
                        {
                            
                            revisionNumber = file.ReadLine();
                            dateTime = file.ReadLine();
                            actualText = "";

                            //Stores current line in the file
                            string line = "";

                            do
                            {
                                // get 1) next line of text 2) a delimiter 3) a null
                                line = file.ReadLine();
                                //When line is actual text, add it to the rest of the actual text
                                if (line != delimiter && line != null)
                                {
                                    if (actualText != "")
                                    {
                                        actualText = actualText + "\r\n";
                                    }

                                    actualText = actualText + line;
                                }
                            } while (line != delimiter && line != null);
                            //Create a new revision after loading its info from the file
                            Revision newRevision = new Revision(int.Parse(revisionNumber), DateTime.Parse(dateTime), actualText, delimiter);
                            loadedRevisions.Add(newRevision);
                        }

                        return loadedRevisions;
                        
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Uknown error", "Cannot Load File");
                }


            }


            else
            {
                MessageBox.Show("Type in a file name.", "Cannot Load File");
            }

            //if there were errors just return last successful load
            return allRevisions;
        }


        private void DisplayRevision(Revision aRevision)
        {
            lblRevisionNumber.Text = aRevision.RevisionNumber.ToString();
            lblDateTime.Text = aRevision.RevisionDate.ToString();
            txtContent.Text = aRevision.Content;
        }

        private void btnOlderRevision_Click(object sender, EventArgs e)
        {
            if (allRevisions.Count > 0 && displayIndex != DISPLAY_NOTHING)
            {
                displayIndex--;
                if (displayIndex < 0)
                {
                    
                    displayIndex = allRevisions.Count -1;
                }
                DisplayRevision(allRevisions[displayIndex]);
            }
        }

        private void btnNewerRevision_Click(object sender, EventArgs e)
        {
            if (allRevisions.Count > 0 && displayIndex != DISPLAY_NOTHING)
            {
                displayIndex++;
                if (displayIndex > allRevisions.Count -1)
                {

                    displayIndex = 0;
                }
                DisplayRevision(allRevisions[displayIndex]);
            }
        }

        private void tmrAutoSave_Tick(object sender, EventArgs e)
        {
            if (txtContent.Text == allRevisions[allRevisions.Count - 1].Content)
            {
                Save();
            }
        }
    }
}
