using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parse
{
    public partial class frmChooseFile : Form
    {
        public frmChooseFile()
        {
            InitializeComponent();
        }

        // Students holds the data of an individual student
        // Fields include: firstName, lastName, idNumber, concentration
        public class Students
        {
            public string firstName { get; set; }
            public string lastName { get; set; }
            public string idNumber { get; set; }
            public string concentration { get; set; }
            public Students(string first, string last, string id, string conc)
            {
                firstName = first;
                lastName = last;
                idNumber = id;
                concentration = conc;
            }
            // ***** Other properties, methods, events... *****
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // ***** NEXT STEP: Separate Name, ID#, Courses & Grades I believe? Maybe? *****
            // ***** and should we put each students info into some sort of structure? *****

            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog box.
            if (result == DialogResult.OK) // Test result.
            {
                // Sets filePath equal to the file location specified by the user.
                var filePath = openFileDialog1.FileName;

                // Defines ignorePrefixes as a list of prefixes which are not needed.
                var ignorePrefixes = new List<string> { "Page:", "Report Date:", "Birthdate:", "COURSE", "End" };

                // The file located at filePath is read into filteredContent.
                // Lines beginning with ignorePrefixes are not read.
                var filteredContent = File.ReadAllLines(filePath)
                    .Where(line => ignorePrefixes.All(prefix => !line.StartsWith(prefix)))
                    .ToList();

                // The lines in filteredContent are combined into a string and saved in filteredAsString.
                var filteredAsString = string.Join(Environment.NewLine, filteredContent);

                // Sets mydocpath to the user's My Documents folder.
                // ***** This may be changed to allow the user to choose the destination *****
                var mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                // Writes filteredAsString to a filed located at mydocpath called Students.txt.
                using (StreamWriter outputFile = new StreamWriter(mydocpath + @"\Students.txt"))
                {
                    outputFile.Write(filteredAsString);
                }

                // Displays "Your file has been created and is in the My Documents folder" to the user.
                lblCreated.Visible = true;
            }
        }
    }
}