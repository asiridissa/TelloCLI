using Microsoft.VisualBasic;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Cloud.Speech.V1;
using NAudio.Wave;

namespace TelloControl
{

    public partial class Voice : Form
    {
        private WaveInEvent waveIn;
        private SpeechClient speechClient;
        private SpeechClient.StreamingRecognizeStream streamingCall;

        public Voice()
        {
            InitializeComponent();
            // Path to your Google Cloud service account key file
            string credentialPath = "msc2024-411517-71868ce380c1.json";

            // Set the environment variable to authenticate
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", credentialPath);
            speechClient = SpeechClient.Create();
        }

        private async void siLK_Click(object sender, EventArgs e)
        {
            await StartRecognition("si-LK");
        }

        private async void enUS_Click(object sender, EventArgs e)
        {
            await StartRecognition("en-US");
        }

        public async Task StartRecognition(string languageCode)
        {
            console.AppendText($"{languageCode} Starting...\n");
            if (waveIn != null)
            {
                // Stop current recording if any
                waveIn.StopRecording();
                waveIn.Dispose();
            }

            var config = new RecognitionConfig
            {
                Encoding = RecognitionConfig.Types.AudioEncoding.Linear16,
                SampleRateHertz = 16000,
                LanguageCode = languageCode
            };

            var streamingConfig = new StreamingRecognitionConfig
            {
                Config = config,
                InterimResults = true
            };

            streamingCall = speechClient.StreamingRecognize();
            await streamingCall.WriteAsync(new StreamingRecognizeRequest
            {
                StreamingConfig = streamingConfig
            });

            waveIn = new WaveInEvent
            {
                WaveFormat = new WaveFormat(16000, 1)
            };
            waveIn.DataAvailable += async (sender, args) =>
            {
                await streamingCall.WriteAsync(new StreamingRecognizeRequest
                {
                    AudioContent = Google.Protobuf.ByteString.CopyFrom(args.Buffer, 0, args.BytesRecorded)
                });
            };

            waveIn.StartRecording();
            console.AppendText("Speak now...\n");

            Task.Run(async () =>
            {
                await foreach (var response in streamingCall.GetResponseStream())
                {
                    foreach (var result in response.Results)
                    {
                        foreach (var alternative in result.Alternatives)
                        {
                            Invoke(new Action(() =>
                            {
                                console.AppendText($"Transcript: {alternative.Transcript}, Confidence: {alternative.Confidence}\n");
                            }));
                        }
                    }
                }
            });
        }
    }
}
