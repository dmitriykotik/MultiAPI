using Microsoft.ML;
using Microsoft.ML.Data;

/* 
  =================- INFO -===================
 * File:         | ChatBot.cs
 * Class:        | ChatBot
 * Project:      | MultiAPI
 * Author:       | dmitriykotik
 * [OPEN SOURCE] | +True
 * [CONSTRUCTOR] | -False
  ============================================
 */

namespace MultiAPI
{
    #region CLASS | Data
    /// <summary>
    /// Данные для машинного обучения
    /// </summary>
    public class Data
    {
        /// <summary>
        /// Вводимый текст пользователем
        /// </summary>
        public string? Text { get; set; }
        /// <summary>
        /// Выводимый текст при обнаружении совпадения
        /// </summary>
        public string? Response { get; set; }
        /// <summary>
        /// Возвращаемый код
        /// </summary>
        public int ReturnCode { get; set; }
    }
    #endregion

    #region CLASS | Prediction
    /// <summary>
    /// Предсказание
    /// </summary>
    internal class Prediction
    {
        /// <summary>
        /// 
        /// </summary>
        [ColumnName("PredictedLabel")]
        public string? Response { get; set; }
    }
    #endregion

    #region CLASS | CResponse
    /// <summary>
    /// Возвращаемые данные
    /// </summary>
    public class CResponse
    {
        /// <summary>
        /// Возвращаемый текст который был указан в данных для машинного обучения
        /// </summary>
        public string? Response { get; set; }
        /// <summary>
        /// Возвращаемый код который был указан в данных для машинного обучения
        /// </summary>
        public int? ReturnCode { get; set; }
    }
    #endregion

    #region CLASS | ChatBot
    /// <summary>
    /// Чат-бот
    /// </summary>
    public static class ChatBot
    {
        private static MLContext mlContext;
        private static PredictionEngine<Data, Prediction>? predictionEngine;
        private static List<Data>? trainingData;

        /// <summary>
        /// Чат-бот
        /// </summary>
        static ChatBot() => mlContext = new MLContext();

        #region METHOD-VOID | Initialize
        /// <summary>
        /// Инициализация чат-бота
        /// </summary>
        /// <param name="trainingData">Данные для машинного обучения</param>
        public static void Initialize(List<Data> trainingData)
        {
            ChatBot.trainingData = trainingData;

            var trainingDataView = mlContext.Data.LoadFromEnumerable(trainingData);

            var dataProcessPipeline = mlContext.Transforms.Conversion.MapValueToKey("Label", nameof(Data.Response))
                .Append(mlContext.Transforms.Text.FeaturizeText("TextFeaturized", nameof(Data.Text)))
                .Append(mlContext.Transforms.Concatenate("Features", "TextFeaturized"));

            var trainer = mlContext.MulticlassClassification.Trainers.SdcaMaximumEntropy("Label", "Features")
                .Append(mlContext.Transforms.Conversion.MapKeyToValue("PredictedLabel", "PredictedLabel"));

            var trainingPipeline = dataProcessPipeline.Append(trainer);

            var model = trainingPipeline.Fit(trainingDataView);

            predictionEngine = mlContext.Model.CreatePredictionEngine<Data, Prediction>(model);
        }
        #endregion

        #region METHOD-CResponse | GetResponse
        /// <summary>
        /// Получение ответа от чат-бота с помощью входных данных пользователя.
        /// </summary>
        /// <param name="userInput">Входные данные пользователя</param>
        /// <returns>Возвращает ответ бота с текстом и кодом указанным в данных для машинного обучения. ПРЕДУПРЕЖДЕНИЕ: Если чат-бот не понимает, что ввёл пользователь, то он выберет последний элемент из тренировочных данных!</returns>
        public static CResponse GetResponse(string userInput)
        {
            var input = new Data() { Text = userInput };

            var prediction = predictionEngine?.Predict(input);

            var matchingData = trainingData?.Find(data => data.Response == prediction?.Response);

            return new CResponse
            {
                Response = prediction?.Response,
                ReturnCode = matchingData?.ReturnCode
            };
        }
        #endregion
    }
    #endregion
}
