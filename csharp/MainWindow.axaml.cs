using Avalonia.Controls;
using Avalonia.Interactivity;
using System;
using csharp.ViewModels;

namespace csharp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }
    }
}
