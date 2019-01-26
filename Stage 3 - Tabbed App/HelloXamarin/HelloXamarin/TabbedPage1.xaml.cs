using System;
using System.IO;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HelloXamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabbedPage1 : TabbedPage
    {
        string _fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "notes.txt");

        public TabbedPage1 ()
        {
            InitializeComponent();
        }

        void OnSaveButtonClicked(object sender, EventArgs e)
        {
            File.WriteAllText(_fileName, _editor.Text);
        }

        void OnLoadButtonClicked(object sender, EventArgs e)
        {
            if (File.Exists(_fileName))
            {
                _editor.Text = File.ReadAllText(_fileName);
            }
            else
            {
                DisplayAlert("Oh no!", "I cannot load something that does not exist", "Gotcha");
            }
        }

        void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            if (File.Exists(_fileName))
            {
                File.Delete(_fileName);
            }
            _editor.Text = string.Empty;
        }

        void OnSliderValueChanged(object sender, ValueChangedEventArgs args)
        {
            double value = args.NewValue;
            rotatingLabel.Rotation = value;
            displayLabel.Text = "The Slider value is " + value;
        }
    }
}