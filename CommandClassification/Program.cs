using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Transforms.Text;

namespace CommandClassification
{
    internal class Program
    {
        // Define paths
        static string basePath = AppDomain.CurrentDomain.BaseDirectory;
        static string dataPath = Path.Combine(basePath, "data.csv");
        static string modelPath = Path.Combine(basePath, "model.zip");
        static List<TextData> testList = new List<TextData>()
        {
            new TextData { Text = "Your example text here" },
            new TextData { Text = "asadasd dasdasdas" },
            new TextData { Text = "Up" },
            new TextData { Text = "Go Up" },
            new TextData { Text = "Down" },
            new TextData { Text = "Left long" },
            new TextData { Text = "Go up" },
            new TextData { Text = "Go left little" },
            new TextData { Text = "may" },
            new TextData { Text = "Hold" },
            new TextData { Text = "Wait" },
            new TextData { Text = "Stop" },
            new TextData { Text = "Pause" },
        };


        static void Main(string[] args)
        {
            //todo: did not work well. Needs advanced training
            //BuildModel();
            ProcessAndTrainModel();
        }

        public static void ProcessAndTrainModel()
        {
            MLContext mlContext = new MLContext();

            var dataView = mlContext.Data.LoadFromTextFile<TextData>(dataPath, hasHeader: true, separatorChar: ',');


            var dataProcessPipeline = mlContext.Transforms.Conversion.MapValueToKey("Label", nameof(TextData.Category))
                .Append(mlContext.Transforms.Text.FeaturizeText("Features", 
                    options: new TextFeaturizingEstimator.Options
                    {
                        WordFeatureExtractor = new WordBagEstimator.Options { NgramLength = 2, UseAllLengths = true },
                        CharFeatureExtractor = new WordBagEstimator.Options(){NgramLength = 5, UseAllLengths = true}, // Optional: Adjust as needed
                    }, nameof(TextData.Text)))
                .AppendCacheCheckpoint(mlContext);

            var trainingPipeline = dataProcessPipeline.Append(mlContext.MulticlassClassification.Trainers.SdcaMaximumEntropy("Label", "Features"))
                .Append(mlContext.Transforms.Conversion.MapKeyToValue("PredictedLabel"));

            //// Split the data 80:20 into training and test sets
            //var trainTestData = mlContext.Data.TrainTestSplit(dataView,0.2);
            //var trainingData = trainTestData.TrainSet;
            //var testData = trainTestData.TestSet;

            // Train the model
            var trainedModel = trainingPipeline.Fit(dataView);
            //var trainedModel = trainingPipeline.Fit(trainingData);

            // Evaluate the model
            //var predictions = trainedModel.Transform(testData);
            var predictions = trainedModel.Transform(dataView);
            var metrics = mlContext.MulticlassClassification.Evaluate(predictions);
            Console.WriteLine($"Macro accuracy: {metrics.MacroAccuracy:0.##}");
            Console.WriteLine($"Micro accuracy: {metrics.MicroAccuracy:0.##}");

            // Save the model
            mlContext.Model.Save(trainedModel, dataView.Schema, modelPath);

            testList.ForEach(x =>
            {
                PredictCategory(x.Text);
            });
        }

        public static void PredictCategory(string text)
        {
            MLContext mlContext = new MLContext();

            DataViewSchema modelSchema;
            ITransformer trainedModel = mlContext.Model.Load(modelPath, out modelSchema);
            var predEngine = mlContext.Model.CreatePredictionEngine<TextData, TextPrediction>(trainedModel);

            var prediction = predEngine.Predict(new TextData { Text = text });
            Console.WriteLine($"Predicted category: {prediction.PredictedCategory}");
        }


        public static string BuildModel()
        {
            // Create MLContext
            MLContext mlContext = new MLContext(seed: 1)
            {
                GpuDeviceId = 1,
                FallbackToCpu = false,
            };
            // Load Data
            IDataView dataView = mlContext.Data.LoadFromTextFile<TextData>(dataPath, hasHeader: true, separatorChar: ',');

            // Data Process Configuration with Pipeline
            var dataProcessPipeline = mlContext.Transforms.Conversion.MapValueToKey("Label", nameof(TextData.Category))
                .Append(mlContext.Transforms.Text.FeaturizeText("Features", nameof(TextData.Text)))
                .AppendCacheCheckpoint(mlContext);

            // Set the training algorithm
            //var trainer = mlContext.MulticlassClassification.Trainers.SdcaMaximumEntropy("Label", "Features").Append(mlContext.Transforms.Conversion.MapKeyToValue("PredictedLabel"));
            var trainer = mlContext.MulticlassClassification.Trainers.PairwiseCoupling(mlContext.BinaryClassification.Trainers.SdcaLogisticRegression())
                .Append(mlContext.Transforms.Conversion.MapKeyToValue("PredictedLabel"));
            var trainingPipeline = dataProcessPipeline.Append(trainer);

            // Train the model
            Console.WriteLine("Training the model...");
            ITransformer trainedModel = trainingPipeline.Fit(dataView);

            // Evaluate the model
            Console.WriteLine("Evaluating the model...");
            var predictions = trainedModel.Transform(dataView);
            var metrics = mlContext.MulticlassClassification.Evaluate(predictions);
            Console.WriteLine($"Macro accuracy: {metrics.MacroAccuracy:0.###}");
            Console.WriteLine($"Micro accuracy: {metrics.MicroAccuracy:0.###}");
            Console.WriteLine($"Log loss: {metrics.LogLoss:#.###}");
            Console.WriteLine($"Log loss reduction: {metrics.LogLossReduction:#.###}");
            Console.WriteLine(metrics.ConfusionMatrix.GetFormattedConfusionTable());

            // Save the model
            mlContext.Model.Save(trainedModel, dataView.Schema, modelPath);
            Console.WriteLine($"Model saved to {modelPath}");

            // Example of making a single prediction
            var predictionEngine = mlContext.Model.CreatePredictionEngine<TextData, TextPrediction>(trainedModel);

            
            foreach (var sampleText in testList)
            {
                var prediction = predictionEngine.Predict(sampleText);
                Console.WriteLine($"Predicted category: {prediction.PredictedCategory}");
            }

            return $"Model saved to {modelPath}";
        }

        public static string GetPrediction(string text)
        {
            // Create a new ML context
            MLContext mlContext = new MLContext();

            // Load the trained model
            DataViewSchema modelSchema;
            ITransformer trainedModel = mlContext.Model.Load(modelPath, out modelSchema);

            // Create a prediction engine from the loaded model
            var predictionEngine = mlContext.Model.CreatePredictionEngine<TextData, TextPrediction>(trainedModel);

            // Example text to classify
            var sampleText = new TextData { Text = text };

            // Make the prediction
            var prediction = predictionEngine.Predict(sampleText);

            // Output the predicted category
            Console.WriteLine($"Predicted category: {prediction.PredictedCategory}");
            return prediction.PredictedCategory;
        }
    }

    public class TextPrediction
    {
        [ColumnName("PredictedLabel")]
        public string PredictedCategory { get; set; }
    }
}
