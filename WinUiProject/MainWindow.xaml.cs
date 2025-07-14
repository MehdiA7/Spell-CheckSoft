using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Input;
using WinUiProject.Services.Api;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WinUiProject
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        private readonly ApiService _apiService;
        public MainWindow()
        {
            InitializeComponent();
            _apiService = new ApiService();
        }

        private async void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            string apiUrl = "http://localhost:11434/api/generate";

            var content = new
            {
                model = "phi3:3.8b",
                prompt = $"Répond uniquement par ce text corrigé : {InputTextBox.Text}",
                stream = false
            };

            OutputTextBlock.Text = "The correction is coming";
            SendPromptApiResponse result = await _apiService.SendPrompt(apiUrl, content);

            OutputTextBlock.Text = result.Response;
        }

        private void InputTextBox_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                SubmitButton_Click(sender, e);
            }
        }

        //private async void TalkWithOllama(object sender, RoutedEventArgs e)
        //{
        //    string apiUrl = "http://localhost:11434/api/generate";

        //    var content = new
        //    {
        //        model = "phi3:3.8b",
        //        prompt = $"Répond uniquement par ce text corrigé : {InputTextBox.Text}",
        //        stream = false
        //    };

        //    string result = await _apiService.SendPrompt(apiUrl, content);

        //    ContentDialog dialog = new()
        //    {
        //        Title = "API RESPONSE",
        //        Content = result,
        //        CloseButtonText = "OK",
        //        XamlRoot = this.Content.XamlRoot
        //    };

        //    await dialog.ShowAsync();
        //}
    }
}
