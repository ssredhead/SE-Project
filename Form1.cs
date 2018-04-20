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

        public class Students
        {
            public string firstName { get; set; }
            public string lastName { get; set; }
            public string idNumber { get; set; }
            public string concentration { get; set; }
            public string year { get; set; }
            public string CS102 { get; set; }
            public string CS102F { get; set; }
            public string CS109 { get; set; }
            public string CS110 { get; set; }
            public string CS111 { get; set; }
            public string CS170 { get; set; }
            public string CS171 { get; set; }
            public string CS205 { get; set; }
            public string CS214 { get; set; }
            public string CS221 { get; set; }
            public string CS225 { get; set; }
            public string CS226 { get; set; }
            public string CS250 { get; set; }
            public string CS255 { get; set; }
            public string CS265 { get; set; }
            public string CS270 { get; set; }
            public string CS290 { get; set; }
            public string CS292 { get; set; }
            public string CS305 { get; set; }
            public string CS310 { get; set; }
            public string CS315 { get; set; }
            public string CS321 { get; set; }
            public string CS322 { get; set; }
            public string CS325 { get; set; }
            public string CS330 { get; set; }
            public string CS350 { get; set; }
            public string CS351 { get; set; }
            public string CS355 { get; set; }
            public string CS357 { get; set; }
            public string CS358 { get; set; }
            public string CS375 { get; set; }
            public Students(string first, string last, string id, string conc, string yr, string cs102f, string cs102, string cs109,
                string cs110, string cs111, string cs170, string cs171, string cs205, string cs214, string cs221, string cs225,
                string cs226, string cs250, string cs255, string cs265, string cs270, string cs290, string cs292, string cs305,
                string cs310, string cs315, string cs321, string cs322, string cs325, string cs330, string cs350, string cs351,
                string cs355, string cs357, string cs358, string cs375)
            {
                firstName = first;
                lastName = last;
                idNumber = id;
                concentration = conc;
                year = yr;
                CS102F = cs102f;
                CS102 = cs102;
                CS109 = cs109;
                CS110 = cs110;
                CS111 = cs111;
                CS170 = cs170;
                CS171 = cs171;
                CS205 = cs205;
                CS214 = cs214;
                CS221 = cs221;
                CS225 = cs225;
                CS226 = cs226;
                CS250 = cs250;
                CS255 = cs255;
                CS265 = cs265;
                CS270 = cs270;
                CS290 = cs290;
                CS292 = cs292;
                CS305 = cs305;
                CS310 = cs310;
                CS315 = cs315;
                CS321 = cs321;
                CS322 = cs322;
                CS325 = cs325;
                CS330 = cs330;
                CS350 = cs350;
                CS351 = cs351;
                CS355 = cs355;
                CS357 = cs357;
                CS358 = cs358;
                CS375 = cs375;
            }
            //Other properties, methods, events...
        }

        private void button1_Click(object sender, EventArgs e)
        {

            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog box.
            if (result == DialogResult.OK) // Test result.
            {
                // Declarations
                string filePath = openFileDialog1.FileName; // Will be returned in form M://...etc.
                string nameIDLine = "";
                string nameLine = "";
                string idLine = "";
                int numLinesNameId = 0;
                int numLinesConcentration = 0;
                int numLinesYears = 0;

                // Setting prefixes to filter the txt files
                var coursesPrefix = new List<string> { "Report", "Birthdate", "COURSE", "Current", "End", "Page" };
                var prefixesNameID = new List<string> { "Mr.", "Mrs.", "Ms." };
                var concentrationPrefix = new List<string> { "Current" };
                var yearPrefix = new List<string> { "EHRS", "Mr.", "Mrs.", "Ms." };

                // Setting a variable to the My Documents folder
                // This can be changed/eliminated
                string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);


                // Make the label visible so that the user knows the new text file has been created
                lblCreated.Visible = true;

                // Reads all of the lines, and filters out the lines that don't contain the prefixes listed above
                // Will eventually lead to getting the students name and their ID #
                var nameIDLines = File.ReadAllLines(filePath)
                    .Where(line => prefixesNameID.Any(prefix => line.Contains(prefix)))
                    .ToList();

                // Puts all the lines read into a single string
                var filteredAsString = string.Join(Environment.NewLine, nameIDLines);

                // Write the filtered content to a new file named "nameIDLines.txt"
                using (StreamWriter outputFile = new StreamWriter(mydocpath + @"\nameIDLines.txt"))
                {
                    outputFile.Write(filteredAsString);
                }

                // Reads all of the lines, and filters out the lines that don't contain the prefixes listed above
                // Will eventually lead to getting the students concentration and their year
                var studentConcentrations = File.ReadAllLines(filePath)
                    .Where(lines => concentrationPrefix.Any(prefix => lines.Contains(prefix)))
                    .ToList();

                // Puts all the lines read into a single string
                filteredAsString = string.Join(Environment.NewLine, studentConcentrations);

                // Write the filtered content to a new file named "concYrLines"
                using (StreamWriter output = new StreamWriter(mydocpath + @"\concentrationLines.txt"))
                {
                    output.Write(filteredAsString);
                }

                // Counts the number of lines in our name and ID file
                using (StreamReader r = new StreamReader(mydocpath + @"\nameIDLines.txt"))
                {
                    int i = 0;
                    while (r.ReadLine() != null)
                    {
                        i++;
                    }
                    numLinesNameId = i;
                }

                // Counts the number of lines in our concentration and year file
                using (StreamReader sr = new StreamReader(mydocpath + @"\concentrationLines.txt"))
                {
                    int i = 0;
                    while (sr.ReadLine() != null)
                    {
                        i++;
                    }
                    numLinesConcentration = i;
                }

                // Declaring arrays to store the names and id's of the students
                string[] namesArray = new string[numLinesNameId];
                string[] idArray = new string[numLinesNameId];

                // Reads each students name and id into arrays that will contain duplicates
                using (var sr = new StreamReader(mydocpath + @"\nameIDLines.txt"))
                {
                    for (int i = 0; i < numLinesNameId; i++)
                    {
                        nameIDLine = sr.ReadLine();
                        nameLine = nameIDLine.Split(new string[] { "ID" }, StringSplitOptions.None)[0];
                        idLine = nameIDLine.Split(new string[] { ": " }, StringSplitOptions.None)[1];
                        idLine = idLine.Split(new string[] { " " }, StringSplitOptions.None)[0];
                        namesArray[i] = nameLine;
                        idArray[i] = idLine;
                    }
                }

                // Takes all of the duplicates out of the namesArray and idArrays
                namesArray = namesArray.Distinct().ToArray();
                idArray = idArray.Distinct().ToArray();

                // Reads all of the lines in the file into a list
                List<string> concentrationList = new List<string>(File.ReadAllLines(mydocpath + @"\concentrationLines.txt"));

                // Figures out how many lines are in the list
                numLinesConcentration = concentrationList.Count();

                // Declares an array to store the concentrations
                string[] concentrationArray = new string[numLinesConcentration];

                // Converts the previous list to an array
                concentrationArray = concentrationList.ToArray();

                // Looks through the array and finds the lines that contain the string "Current"
                // If so, it splits the line after the "(s): " in "Current Program(s): ", takes the
                // second half of it, and stores it into the concentration array
                for (int i = 0; i < concentrationArray.Length; i++)
                {
                    if (concentrationArray[i].Contains("Current"))
                    {
                        string[] concresult = concentrationArray[i].Split(new string[] { "(s): " }, StringSplitOptions.None);
                        if (concresult.Length > 1)
                        {
                            concentrationArray[i] = concresult[1];
                        }
                    }
                }

                // Checks to see if the element in the array contains the string "Bachelor", if so, it splits the element after
                // where it says "of Science in " and takes the second part, which will be the student's major (ex. "Cybersecurity")
                for (int i = 0; i < concentrationArray.Length; i++)
                {
                    if (concentrationArray[i].Contains("Bachelor"))
                    {
                        string[] concresult = concentrationArray[i].Split(new string[] { "of Science in " }, StringSplitOptions.None);
                        if (concresult.Length > 1)
                        {
                            concentrationArray[i] = concresult[1];
                        }
                    }
                }

                // Finds where it says the major in each line and converts it to the same string as is used in the dB
                for (int i = 0; i < concentrationArray.Length; i++)
                {
                    if (concentrationArray[i].Contains("Cybersecurity") || concentrationArray[i].Contains("cybersecurity"))
                    {
                        concentrationArray[i] = "Cybersecurity";
                    }
                    else if (concentrationArray[i].Contains("Computing & Information Science- Cis") || concentrationArray[i].Contains("computing & information science- cis"))
                    {
                        concentrationArray[i] = "Computer Science";
                    }
                    else if (concentrationArray[i].Contains("Computing & Information Science- It") || concentrationArray[i].Contains("computing & information science- it"))
                    {
                        concentrationArray[i] = "Information Technology";
                    }
                }

                // Reads all of the lines, and filters out the lines that don't contain the prefixes listed above
                // Will eventually lead to getting the student's year
                var studentYears = File.ReadAllLines(filePath)
                    .Where(lines => yearPrefix.Any(prefix => lines.Contains(prefix)))
                    .ToList();

                // Puts all the lines read into a single string
                filteredAsString = string.Join(Environment.NewLine, studentYears);

                // Write the filtered content to a new file named "yearsLines"
                using (StreamWriter output = new StreamWriter(mydocpath + @"\yearsLines.txt"))
                {
                    output.Write(filteredAsString);
                }

                // Reads all of the lines in the file into a list
                List<string> yearsList = new List<string>(File.ReadAllLines(mydocpath + @"\yearsLines.txt"));

                // Figures out how many lines are in the list
                numLinesYears = yearsList.Count();

                // Declares an array to store the concentrations
                string[] yearsArray = new string[numLinesYears];

                // Converts the previous list to an array
                yearsArray = yearsList.ToArray();

                // Splits every line after the "Cum" for total cumulative credits if it contains it
                for (int i = 0; i < yearsArray.Length; i++)
                {
                    if (yearsArray[i].Contains("Cum "))
                    {
                        string[] yearsResult = yearsArray[i].Split(new string[] { "Cum " }, StringSplitOptions.None);
                        if (yearsResult.Length > 1)
                        {
                            yearsArray[i] = yearsResult[1];
                        }
                    }
                }

                // If the line doesn't contain a persons name, it will split at the first space, essentially creating a format
                // that is Name, number, number, number, Name, etc.
                for (int i = 0; i < yearsArray.Length; i++)
                {
                    if (!yearsArray[i].Contains("Mr.") && !yearsArray[i].Contains("Mrs.") && !yearsArray[i].Contains("Ms."))
                    {
                        string[] yearsResult = yearsArray[i].Split('.');
                        yearsArray[i] = yearsResult[0];
                    }
                }

                List<int> cumulativeCreditsList = new List<int>();

                // this will read the lines, line by line and figure out what the total
                // number of cumulative credits is for each student.
                // The array will be in format: yearsArray[0] = "Mr. Gerald M. Abridge ID #: 0000008...", yearsArray[1] = "17.00",
                // yearsArray[2] = "Ms. Randall N. Abet ID #: 0000006...", yearsArray[3] = "62.00", yearsArray[4] = "84.00",
                // yearsArray[5] = "Ms. Randall N. Abet ID #: 0000006...", yearsArray[6] = "104.00", yearsArray[7] = "122.00", etc.
                // We need to read through the array and save the first name, which we can figure out if it's a name by checking to see
                // if the line contains "Mr. ", "Mrs. ", or "Ms. ". From there, we need to compare the number(s) between that name and
                // the next name, and then when we reach the next name, we want to check to make sure that it's not the same as the previous
                // name that we had found. If it is the same, we will keep comparing the numbers and if it isn't the same name, we will save
                // the highest number that we found to a list, cumulativeCreditsList, and
                // also overwrite the first name that we found with the second name that we have found.
                string firstName = yearsArray[0]; // We know that the first line will contain a name so we set it as the first name.
                string secondName = "";
                int firstNumber = 0;
                int secondNumber = 0;
                int highNumber = 0;

                for (int i = 1; i < yearsArray.Length; i++)
                {
                    // if the line doesn't contain a name
                    if (!yearsArray[i].Contains("Mr.") && !yearsArray[i].Contains("Mrs.") && !yearsArray[i].Contains("Ms."))
                    {
                        // convert the item in the yearsArray to an integer and set it to the first number
                        firstNumber = Int32.Parse(yearsArray[i]);
                        // the first number is the highest because it's the only one we have so far
                        if (firstNumber > highNumber)
                        {
                            highNumber = firstNumber;
                        }
                        // if the next line exists and it's not a name
                        if (i + 1 < yearsArray.Length && !yearsArray[i + 1].Contains("Mr.") && !yearsArray[i + 1].Contains("Mrs.") && !yearsArray[i + 1].Contains("Ms."))
                        {
                            // convert the next item in the yearsArray to an iteger and set it to the second number
                            secondNumber = Int32.Parse(yearsArray[i + 1]);
                        }
                        // if we reach the last line of the file, add it to the list
                        else if (!(i + 1 < yearsArray.Length))
                        {
                            // Adds the highest number of cumulative credits to the list
                            cumulativeCreditsList.Add(highNumber);

                            // Resets everything back to not much
                            highNumber = 0;
                            firstNumber = 0;
                            secondNumber = 0;
                        }
                        // if statement that's checking to see which number is the highest
                        // the only way we should change the high number is if the second number is greater than the current
                        // high number. (if they're equal, we wouldn't have to change it and if high number is already greater,
                        // we don't have to change it.
                        if (highNumber < secondNumber)
                        {
                            highNumber = secondNumber;
                        }
                    }
                    else // if the line does contain a name
                    {
                        secondName = yearsArray[i]; // the name will be our second name
                        if (secondName == firstName) // if the names are the same
                        {
                            // if the next line exists and it's not a name
                            if (i + 1 < yearsArray.Length && (!yearsArray[i + 1].Contains("Mr.") && !yearsArray[i + 1].Contains("Mrs.") && !yearsArray[i + 1].Contains("Ms.")))
                            {
                                // convert the next item in the yearsArray to an iteger and set it to the second number
                                secondNumber = Int32.Parse(yearsArray[i + 1]);
                            }
                            // if statement that's checking to see which number is the highest
                            // the only way we should change the high number is if the second number is greater than the current
                            // high number. (if they're equal, we wouldn't have to change it and if high number is already greater,
                            // we don't have to change it.
                            if (highNumber < secondNumber)
                            {
                                highNumber = secondNumber;
                            }
                        }
                        else
                        {
                            // Adds the highest number of cumulative credits to the list
                            cumulativeCreditsList.Add(highNumber);

                            // Resets everything back to not much
                            highNumber = 0;
                            firstNumber = 0;
                            secondNumber = 0;

                            // Sets the secondName to the firstName and then clears out secondName
                            firstName = secondName;
                            secondName = "";
                        }
                    }
                }

                // create a string array to store the years of each student
                string[] yearArray = new string[cumulativeCreditsList.Count];

                // parse through the list, convert each of the numbers of credits to the corresponding year, and store
                // them into the yearArray created above
                // >=87 = Senior
                // 54-86.99 = Junior
                // 24-53.99 = Sophomore
                // <24 = Freshman
                for (int i = 0; i < cumulativeCreditsList.Count; i++)
                {
                    if (cumulativeCreditsList[i] >= 87)
                    {
                        yearArray[i] = ("Senior");
                    }
                    else if (cumulativeCreditsList[i] >= 54)
                    {
                        yearArray[i] = ("Junior");
                    }
                    else if (cumulativeCreditsList[i] >= 24)
                    {
                        yearArray[i] = ("Sophomore");
                    }
                    else
                    {
                        yearArray[i] = ("Freshman");
                    }
                }

                // Reads all of the lines, and filters out the lines that don't contain the prefixes listed above
                // Will eventually lead to getting the student's year
                var studentCourses = File.ReadAllLines(filePath)
                    .Where(lines => coursesPrefix.All(prefix => !lines.Contains(prefix)))
                    .ToList();

                // Puts all the lines read into a single string
                filteredAsString = string.Join(Environment.NewLine, studentCourses);

                // Write the filtered content to a new file named "yearsLines"
                using (StreamWriter output = new StreamWriter(mydocpath + @"\courseLines.txt"))
                {
                    output.Write(filteredAsString);
                }

                // Reads all of the lines in the file into a list
                List<string> coursesList = new List<string>(File.ReadAllLines(mydocpath + @"\courseLines.txt"));

                // Create a new list to store the names of the students and their CS classes
                // there will be other classes, but each of the CS classes will begin on a new line
                List<string> coursesAndNames = new List<string>();

                // Stores the  names of the students and their CS classes. There will be other classes, but each of the CS classes will begin on a new line
                for (int i = 0; i < coursesList.Count; i++)
                {
                    // if the line contains a name
                    if (coursesList[i].Contains("Mr.") || coursesList[i].Contains("Mrs.") || coursesList[i].Contains("Ms."))
                    {
                        coursesAndNames.Add(coursesList[i]);
                    }
                    // if the line contains the abbreviation "CS"
                    if (coursesList[i].Contains("CS"))
                    {
                        // split the line that contains " CS" and store it in a string array
                        string[] courseResult = coursesList[i].Split(new string[] { " CS" }, StringSplitOptions.None);
                        // if the length of the string array is greater than 1, we take the second half of the line that we split above
                        // and add it to the new list that we created. Will be in the form "XXX ....." so we ad our delimiter to the front
                        if (courseResult.Length > 1)
                        {
                            coursesAndNames.Add("CS" + courseResult[1]);
                        }
                    }
                }

                // Create a new list that will store the grades of each student for each CS class
                List<string> grades = new List<string>();

                // Set a counter to 0 to eliminate it finding the name of the CS class that will be first on the line (ex. CS123)
                int counter = 5;

                // Parse through the list and find where the first number is after the CS class which will be the number of credits the class was (ex. 3.00)
                // After the number of credits the class was, will immediately follow a space and then the grade of the class, which is what we're looking for
                // Take the substring with length of 2 starting 5 characters further than the number of credits to acccount for the ".00 " and to account for
                // the grade either being "A" or "A-", etc. and add it to the list of grades.

                // NOTE: for some reason I'm getting an error on this and can't quite figure out why.. this loop for sure works though because I tested it out
                // on the data below (you can try and run that if you need to, to better see how it works since there will be less data and you can see the exact lines)
                // it is denoted by "EXAMPLE", you'll just have to uncomment it and comment out this for loop and the example should work.
                for (int i = 0; i < coursesAndNames.Count; i++)
                {
                    if (!coursesAndNames[i].Contains("Mr.") && !coursesAndNames[i].Contains("Mrs.") && !coursesAndNames[i].Contains("Ms."))
                    {
                        while (!Char.IsDigit(coursesAndNames[i][counter]))
                        {
                            counter++;
                        }
                        grades.Add(coursesAndNames[i].Substring(counter + 5, 2));
                    }
                }

                // Debugging Purposes Only
                for (int i = 0; i < grades.Count; i++)
                {
                    lstTest2.Items.Add(grades[i]);
                }

                // EXAMPLE
                /*
                List<string> example = new List<string>();
                example.Add("CS456 Hello 3.00 A 4.00 CS123 Goodbye 5.00 B 6.00");
                example.Add("CS789 Christian 7.00 C 8.00 CS741 Estok 9.00 D 10.00");
                int counterrr = 5;
                for (int i = 0; i < example.Count; i++)
                {
                    while (!Char.IsDigit(example[i][counterrr]))
                    {
                        counterrr++;
                    }
                    lstTest.Items.Add(counterrr);
                    lstTest.Items.Add(example[i].Substring(counterrr + 5, 2));
                }
                */
                // END OF EXAMPLE
            }
        }
    }
}