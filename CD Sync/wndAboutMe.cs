using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;

namespace CD_Sync_Portable
{
    internal partial class WndAboutMe : Form
    {
        Random randGenerator;
        private string[] quotes =
        {
            // Bill Gates
            "Just in terms of allocation of time resources, religion is not very efficient. There's a lot more I could be doing on a Sunday morning.",
            "If you think your teacher is tough, wait until you get a boss. He doesn't have tenure.",
            "In this business, by the time you realize you're in trouble, it's too late to save yourself. Unless you're running scared all the time, you're gone.",
            "If GM had kept up with technology like the computer industry has, we would all be driving $25 cars that got 1000 MPG.",
            "Life is not divided into semesters. You don't get summers off and very few employers are interested in helping you find yourself.",
            "Life is not fair; get used to it.",
            "Success is a lousy teacher. It seduces smart people into thinking they can't lose.",
            "Until we're educating every kid in a fantastic way, until every inner city is cleaned up, there is no shortage of things to do.",
            "We are not even close to finishing the basic dream of what the PC can be.",
            "Windows 2000 already contains features such as the human discipline component, where the PC can send an electric shock through the keyboard if the human does something that does not please Windows.",
            "Your most unhappy customers are your greatest source of learning.",
            "You see, antiquated ideas of kindness and generosity are simply bugs that must be programmed out of our world. And these cold, unfeeling machines will show us the way.",
            "Be nice to nerds. Chances are you'll end up working for one.",
            "I really had a lot of dreams when I was a kid, and I think a great deal of that grew out of the fact that I had a chance to read a lot.",
            "It's fine to celebrate success but it is more important to heed the lessons of failure.",
            "The computer was born to solve problems that did not exist before.",
            // Bill Gates
            // Confucius
            "A superior man is modest in his speech, but exceeds in his actions.",
            "Ability will never catch up with the demand for it.",
            "Choose a job you love, and you will never have to work a day in your life.",
            "Everything has beauty, but not everyone sees it.",
            "If you shoot for the stars and hit the moon, it's OK. But you've got to shoot for something. A lot of people don't even shoot.",
            "It does not matter how slowly you go as long as you do not stop.",
            "It is easy to hate and it is difficult to love. This is how the whole scheme of things works. All good things are difficult to achieve; and bad things are very easy to get.",
            "Only the wisest and stupidest of men never change.",
            "Our greatest glory is not in never falling, but in rising every time we fall.",
            "Real knowledge is to know the extent of one's ignorance.",
            "Silence is a true friend who never betrays.",
            "The firm, the enduring, the simple, and the modest are near to virtue.",
            "The superior man understands what is right; the inferior man understands what will sell.",
            "To know what is right and not to do it is the worst cowardice.",
            "When anger rises, think of the consequences.",
            // Confucius
            // Mohandas Gandhi
            "A 'No' uttered from the deepest conviction is better than a 'Yes' merely uttered to please, or worse, to avoid trouble.",
            "An ounce of practice is worth more than tons of preaching.",
            "Peace is its own reward.",
            "You can chain me, you can torture me, you can even destroy this body, but you will never imprison my mind.",
            "You must be the change you wish to see in the world.",
            // Mohandas Gandhi
            // John Lennon
            "As usual, there is a great woman behind every idiot.",
            "God is a concept by which we measure our pain.",
            "Music is everybody's possession. It's only publishers who think that people own it.",
            "Part of me suspects that I'm a loser, and the other part of me thinks I'm God Almighty.",
            "Reality leaves a lot to the imagination.",
            "Time you enjoy wasting, was not wasted.",
            // John Lennon
            // William Shakespeare
            "A fool thinks himself to be wise, but a wise man knows himself to be a fool.",
            "An overflow of good converts to bad.",
            "It is not in the stars to hold our destiny but in ourselves.",
            "Life is as tedious as twice-told tale, vexing the dull ear of a drowsy man.",
            "Love all, trust a few, do wrong to none.",
            "The man that hath no music in himself, Nor is not moved with concord of sweet sounds, is fit for treasons, stratagems and spoils.",
            // William Shakespeare
            // Rick Cook
            "Programming today is a race between software engineers striving to build bigger and better idiot-proof programs, and the Universe trying to produce bigger and better idiots. So far, the Universe is winning.",
            // Rick Cook
            // Emo Philips
            "A computer once beat me at chess, but it was no match for me at kick boxing.",
            // Emo Philips
        };
        string[] authors =
        {
            "Bill Gates",
            "Confucius",
            "M.K. Gandhi",
            "John Lennon",
            "William Shakespeare",
            "Rick Cook",
            "Emo Philips"
        };

        public WndAboutMe()
        {
            randGenerator = new Random();
            InitializeComponent();

            //  Initialize the AboutBox to display the product information from the assembly information.
            //  Change assembly information settings for your application through either:
            //  - Project->Properties->Application->Assembly Information
            //  - AssemblyInfo.cs
            this.Text = String.Format("About {0}", AssemblyTitle);
            this.lblProductName.Text = AssemblyProduct;
            this.lblVersion.Text = String.Format("Version {0}", AssemblyVersion);
            this.lblCopyright.Text = AssemblyCopyright;
            this.lblCompanyName.Text = String.Format("Developed by {0}", AssemblyCompany);
        }

        #region Assembly Attribute Accessors

        public string AssemblyTitle
        {
            get
            {
                // Get all Title attributes on this assembly
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                // If there is at least one Title attribute
                if (attributes.Length > 0)
                {
                    // Select the first one
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    // If it is not an empty string, return it
                    if (titleAttribute.Title != "")
                        return titleAttribute.Title;
                }
                // If there was no Title attribute, or if the Title attribute was the empty string, return the .exe name
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                // Get all Description attributes on this assembly
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                // If there aren't any Description attributes, return an empty string
                if (attributes.Length == 0)
                    return "";
                // If there is a Description attribute, return its value
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                // Get all Product attributes on this assembly
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                // If there aren't any Product attributes, return an empty string
                if (attributes.Length == 0)
                    return "";
                // If there is a Product attribute, return its value
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                // Get all Copyright attributes on this assembly
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                // If there aren't any Copyright attributes, return an empty string
                if (attributes.Length == 0)
                    return "";
                // If there is a Copyright attribute, return its value
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                // Get all Company attributes on this assembly
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                // If there aren't any Company attributes, return an empty string
                if (attributes.Length == 0)
                    return "";
                // If there is a Company attribute, return its value
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion

        private void pBoxAppIcon_Click(object sender, EventArgs e)
        {
            int value = randGenerator.Next(50);
            if (value <= 15)
                MessageBox.Show(quotes[value] + Environment.NewLine + "--" + authors[0], "Random Quote", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (value > 15 && value <= 30)
                MessageBox.Show(quotes[value] + Environment.NewLine + "--" + authors[1], "Random Quote", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (value > 30 && value <= 35)
                MessageBox.Show(quotes[value] + Environment.NewLine + "--" + authors[2], "Random Quote", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (value > 35 && value <= 41)
                MessageBox.Show(quotes[value] + Environment.NewLine + "--" + authors[3], "Random Quote", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (value > 41 && value <= 47)
                MessageBox.Show(quotes[value] + Environment.NewLine + "--" + authors[4], "Random Quote", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (value == 48)
                MessageBox.Show(quotes[value] + Environment.NewLine + "--" + authors[5], "Random Quote", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show(quotes[value] + Environment.NewLine + "--" + authors[6], "Random Quote", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("mailto:ankitr.42@gmail.com?subject=CD Sync Portable 1.0");
        }

        private void lnkLabelWebsite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://ankitr.fileave.com");
        }
    }
}