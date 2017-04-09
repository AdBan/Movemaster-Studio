﻿using IDE.Common.Views;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace IDE.Common.Models
{
    class CustomHighlighting
    {

        #region Constructor

        public CustomHighlighting()
        {

        }

        #endregion

        #region Properties

        public Color[] HighlightingDefinitionColors
        {
            set
            {
                Redefine(value);
            }
            get
            {
                return GetDefinitions();
            }
        }

        public Color[] ExportDefinitionsColors
        {
            set
            {
                Export(value);
            }
        }

        public Color[] ImportDefinitionsColors
        {
            get
            {
                return Import();
            }
        }

        #endregion

        #region Actions

        private void Redefine(Color[] colors)
        {
            try
            {
                string movement = colors[0].ToString().Remove(1, 2);
                string grip = colors[1].ToString().Remove(1, 2);
                string counters = colors[2].ToString().Remove(1, 2);
                string programming = colors[3].ToString().Remove(1, 2);
                string informations = colors[4].ToString().Remove(1, 2);
                string numbers = colors[5].ToString().Remove(1, 2);
                string comments = colors[6].ToString().Remove(1, 2);

                string[] definitionLines = File.ReadAllLines("CustomHighlighting.xshd");

                //replace outdated colors with new ones
                definitionLines[2] = $"\t<Color name=\"Comment\" foreground=\"{comments}\" />";
                definitionLines[10] = $"\t\t<Keywords fontWeight = \"bold\" foreground = \"{movement}\" > <!--MOVEMENT COMMANDS-->";
                definitionLines[33] = $"\t\t<Keywords fontWeight=\"bold\" foreground=\"{grip}\">\t<!--GRIP COMMANDS-->";
                definitionLines[42] = $"\t\t<Keywords fontWeight=\"bold\" foreground=\"{counters}\">\t<!--TIMERS, COUNTERS-->";
                definitionLines[58] = $"\t\t<Keywords fontWeight=\"bold\" foreground=\"{programming}\">\t<!--PROGRAMMING COMMANDS-->";
                definitionLines[93] = $"\t\t<Keywords fontWeight=\"bold\" foreground=\"{informations}\">\t<!--INFORMATION COMMANDS-->";
                definitionLines[119] = $"\t\t<Rule foreground=\"{numbers}\">";

                File.WriteAllLines("CustomHighlighting.xshd", definitionLines);

                if (MessageBox.Show("In order for the changes to take effect, please restart the program. Do you wish to restart now?", 
                    "Custom redefinition completed", MessageBoxButton.YesNoCancel) == MessageBoxResult.Yes)
                {
                    Process.Start(Application.ResourceAssembly.Location);
                    Application.Current.Shutdown();
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Highlighting definitions not found. You need to provide base file first.", 
                    "No definitions", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Something went very wrong here. Try again tommorow.",
                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private Color[] GetDefinitions()
        {
            Color[] colors = new Color[7];

            try
            {
                string[] definitionLines = File.ReadAllLines("CustomHighlighting.xshd");

                //read hex color for every type
                string comments = definitionLines[2].Substring(definitionLines[2].IndexOf('#'), 7);
                string movement = definitionLines[10].Substring(definitionLines[10].IndexOf('#'), 7);
                string grip = definitionLines[33].Substring(definitionLines[33].IndexOf('#'), 7);
                string counters = definitionLines[42].Substring(definitionLines[42].IndexOf('#'), 7);
                string programming = definitionLines[58].Substring(definitionLines[58].IndexOf('#'), 7);
                string informations = definitionLines[93].Substring(definitionLines[93].IndexOf('#'), 7);
                string numbers = definitionLines[119].Substring(definitionLines[119].IndexOf('#'), 7);

                //convert hex to Color
                colors[0] = (Color)ColorConverter.ConvertFromString(movement);
                colors[1] = (Color)ColorConverter.ConvertFromString(grip);
                colors[2] = (Color)ColorConverter.ConvertFromString(counters);
                colors[3] = (Color)ColorConverter.ConvertFromString(programming);
                colors[4] = (Color)ColorConverter.ConvertFromString(informations);
                colors[5] = (Color)ColorConverter.ConvertFromString(numbers);
                colors[6] = (Color)ColorConverter.ConvertFromString(comments);
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Highlighting definitions not found. You need to provide base file first.",
                    "No definitions", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Something went very wrong here. Try again tommorow.",
                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return colors;
        }

        private Color[] Import()
        {
            Color[] colors = new Color[7];

            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.FileName = "CustomHighlighting"; // Default file name
                dialog.DefaultExt = ".xshd"; // Default file extension
                dialog.Filter = "xshd files (.xshd)|*.xshd"; // Filter files by extension

                // Process open file dialog box results
                if (dialog.ShowDialog() == false)
                {
                    return new Color[] { Color.FromRgb(193, 193, 193), Color.FromRgb(193, 193, 193), Color.FromRgb(193, 193, 193),
                     Color.FromRgb(193, 193, 193), Color.FromRgb(193, 193, 193), Color.FromRgb(193, 193, 193), Color.FromRgb(193, 193, 193) };
                }

                string[] definitionLines = File.ReadAllLines($"{dialog.FileName}");

                //read hex color for every type
                string comments = definitionLines[2].Substring(definitionLines[2].IndexOf('#'), 7);
                string movement = definitionLines[10].Substring(definitionLines[10].IndexOf('#'), 7);
                string grip = definitionLines[33].Substring(definitionLines[33].IndexOf('#'), 7);
                string counters = definitionLines[42].Substring(definitionLines[42].IndexOf('#'), 7);
                string programming = definitionLines[58].Substring(definitionLines[58].IndexOf('#'), 7);
                string informations = definitionLines[93].Substring(definitionLines[93].IndexOf('#'), 7);
                string numbers = definitionLines[119].Substring(definitionLines[119].IndexOf('#'), 7);

                //convert hex to Color
                colors[0] = (Color)ColorConverter.ConvertFromString(movement);
                colors[1] = (Color)ColorConverter.ConvertFromString(grip);
                colors[2] = (Color)ColorConverter.ConvertFromString(counters);
                colors[3] = (Color)ColorConverter.ConvertFromString(programming);
                colors[4] = (Color)ColorConverter.ConvertFromString(informations);
                colors[5] = (Color)ColorConverter.ConvertFromString(numbers);
                colors[6] = (Color)ColorConverter.ConvertFromString(comments);
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Highlighting definitions not found. You need to provide base file first.",
                    "No definitions", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Something went very wrong here. Try again tommorow.",
                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return colors;
        }

        private void Export(Color[] colors)
        {
            try
            {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.FileName = "CustomHighlighting"; // Default file name
                dialog.DefaultExt = ".xshd"; // Default file extension
                dialog.Filter = "xshd files (.xshd)|*.xshd"; // Filter files by extension

                // Process save file dialog box results
                if (dialog.ShowDialog() == false)
                {
                    return;
                }


                string movement = colors[0].ToString().Remove(1, 2);
                string grip = colors[1].ToString().Remove(1, 2);
                string counters = colors[2].ToString().Remove(1, 2);
                string programming = colors[3].ToString().Remove(1, 2);
                string informations = colors[4].ToString().Remove(1, 2);
                string numbers = colors[5].ToString().Remove(1, 2);
                string comments = colors[6].ToString().Remove(1, 2);

                string[] definitionLines = File.ReadAllLines("CustomHighlighting.xshd");

                //replace outdated colors with new ones
                definitionLines[2] = $"\t<Color name=\"Comment\" foreground=\"{comments}\" />";
                definitionLines[10] = $"\t\t<Keywords fontWeight = \"bold\" foreground = \"{movement}\" > <!--MOVEMENT COMMANDS-->";
                definitionLines[33] = $"\t\t<Keywords fontWeight=\"bold\" foreground=\"{grip}\">\t<!--GRIP COMMANDS-->";
                definitionLines[42] = $"\t\t<Keywords fontWeight=\"bold\" foreground=\"{counters}\">\t<!--TIMERS, COUNTERS-->";
                definitionLines[58] = $"\t\t<Keywords fontWeight=\"bold\" foreground=\"{programming}\">\t<!--PROGRAMMING COMMANDS-->";
                definitionLines[93] = $"\t\t<Keywords fontWeight=\"bold\" foreground=\"{informations}\">\t<!--INFORMATION COMMANDS-->";
                definitionLines[119] = $"\t\t<Rule foreground=\"{numbers}\">";
                
                File.WriteAllLines($"{dialog.FileName}", definitionLines);
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Highlighting definitions not found. You need to provide base file first.",
                    "No definitions", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Something went very wrong here. Try again tommorow.",
                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        #endregion

    }
}