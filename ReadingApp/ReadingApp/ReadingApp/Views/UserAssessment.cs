using Speech;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AVFoundation;

namespace ReadingApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserAssessment : ContentPage
	{
        private string textToRead = "I do not like green eggs and ham I do not like them Sam I Am.  I would not have them in a house I would not have them with a mouse.";
        private bool assessmentInProgress = false; 
        private AVAudioEngine AudioEngine = new AVAudioEngine();
        private SFSpeechRecognizer SpeechRecognizer = new SFSpeechRecognizer();
        private SFSpeechAudioBufferRecognitionRequest LiveSpeechRequest = new SFSpeechAudioBufferRecognitionRequest();
        private SFSpeechRecognitionTask RecognitionTask;

        public UserAssessment ()
		{
			InitializeComponent();

            /* Load the initial passage of text. */
            Passage.Text = textToRead;

            /* Request user authorization to enable the microphone for live transcription. */
            SFSpeechRecognizer.RequestAuthorization((SFSpeechRecognizerAuthorizationStatus status) => {
                switch (status)
                {
                    case SFSpeechRecognizerAuthorizationStatus.Authorized:
                        // User has approved speech recognition                        \
                        break;
                    case SFSpeechRecognizerAuthorizationStatus.Denied:
                        // User has declined speech recognition                    
                        break;
                    case SFSpeechRecognizerAuthorizationStatus.NotDetermined:
                        // Waiting on approval                         
                        break;
                    case SFSpeechRecognizerAuthorizationStatus.Restricted:
                        // The device is not permitted                    
                        break;
                }
            });
		}


        void StartAssessment_Clicked(object sender, System.EventArgs e)
        {
            assessmentInProgress = !assessmentInProgress;

            /* Are we in assessment start or end? */
            if (assessmentInProgress)
            {
                /* Start listening to the user. */
                StartAssessment.Text = "End Assessment";
            }
            else
            {
                /* Stop listening to the user and commence assessment. */
                StartAssessment.Text = "Start Assessment";
                StartAssessment.IsEnabled = false;
            }


        }

	}
}