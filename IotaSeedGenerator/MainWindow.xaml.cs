// Copyright 2018 Alexander Myar
// This file is part of Iota Seed Generator.
// Iota Seed Generator is free software: you can redistribute it and/or modify 
// it under the terms of the GNU General Public License as published by the 
// Free Software Foundation, either version 3 of the License, or(at your 
// option) any later version.
// Iota Seed Generator is distributed in the hope that it will be useful, but 
// WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY 
// or FITNESS FOR A PARTICULAR PURPOSE.See the GNU General Public License for 
// more details.
// You should have received a copy of the GNU General Public License along with 
// Iota Seed Generator. If not, see http://www.gnu.org/licenses/.
using CryptoRng;
using System.Diagnostics;
using System.Windows;

namespace IotaSeedGenerator
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IotaSeed generator;


        public MainWindow()
        {
            InitializeComponent();
            generator = new IotaSeed();
        }

        private void btnGenerate_Click(object sender, RoutedEventArgs e)
        {
            int length;
            if (int.TryParse(TxtSeedLength.Text, out length))
            {
                TxtContent.Text = generator.Generate(length);
            }
            else
            {
                TxtContent.Clear();
            }
        }

        private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }
    }
}
