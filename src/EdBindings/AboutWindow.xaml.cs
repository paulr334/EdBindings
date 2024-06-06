namespace EdBindings
{
    using System.Diagnostics;
    using System.Reflection;
    using System.Windows;

    /// Interaction logic for AboutWindow.xaml
    public partial class AboutWindow : Window
    {
        public string VersionString { get; set; }

        public AboutWindow()
        {
            InitializeComponent();
            SetVersion();
            this.DataContext = this;
        }

        private void SetVersion()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var versionInfo = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>();
            this.VersionString = $"v{versionInfo.InformationalVersion}";
        }
        private void CloseButtonClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void HyperlinkRequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri) { UseShellExecute = true });
            e.Handled = true;
        }
    }
}
