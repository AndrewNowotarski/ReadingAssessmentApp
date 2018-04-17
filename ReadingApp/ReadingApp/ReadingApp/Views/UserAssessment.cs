using Speech;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Foundation;
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

        /* Voice recognition reference:
        https://docs.microsoft.com/en-us/xamarin/ios/platform/speech?tabs=vsmac
        */
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
                StartListening();
                StartAssessment.Text = "End Assessment";
            }
            else
            {
                /* Stop listening to the user and commence assessment. */
                StopListening();
                StartAssessment.Text = "Start Assessment";
                StartAssessment.IsEnabled = false;
            }
        }

        void StartListening()
        {
            /* Setup audio session. */
            var node = AudioEngine.InputNode;
            var recordingFormat = node.GetBusOutputFormat(0);
            node.InstallTapOnBus(0, 1024, recordingFormat, (AVAudioPcmBuffer buffer, AVAudioTime when) => {
                /* Append buffer to recognition request. */
                LiveSpeechRequest.Append(buffer);
            });

            /* Start recording */
            AudioEngine.Prepare();
            NSError error;
            AudioEngine.StartAndReturnError(out error);

            /* Did recording start? */
            if (error != null)
            {
                /* Do nothing. */
                return;
            }

            /* Start recognition. */
            RecognitionTask = SpeechRecognizer.GetRecognitionTask(LiveSpeechRequest, (SFSpeechRecognitionResult result, NSError err) => {
                /* Was there an error? */
                if (err != null)                {
                    /* Do nothing. */                }
                else
                {
                    // Is this the final translation?
                    if (result.Final)                    {
                        UserText.Text = result.BestTranscription.FormattedString;                    }
                }
            });
        }

        void StopListening()
        {
            AudioEngine.Stop();
            LiveSpeechRequest.EndAudio();
        }

        void CancelRecording()
        {
            AudioEngine.Stop();
            RecognitionTask.Cancel();
        }

	}
}