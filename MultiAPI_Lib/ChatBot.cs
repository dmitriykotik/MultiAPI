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
        private static MLContext MlContext;
        private static PredictionEngine<Data, Prediction>? PredictionEngine;
        private static List<Data>? TrainingData;

        /// <summary>
        /// Чат-бот
        /// </summary>
        static ChatBot() => MlContext = new MLContext();

        #region METHOD-VOID | Initialize
        /// <summary>
        /// Инициализация чат-бота
        /// </summary>
        /// <param name="TrainingData">Данные для машинного обучения</param>
        public static void Initialize(List<Data> TrainingData)
        {
            ChatBot.TrainingData = TrainingData;

            var trainingDataView = MlContext.Data.LoadFromEnumerable(TrainingData);

            var dataProcessPipeline = MlContext.Transforms.Conversion.MapValueToKey("Label", nameof(Data.Response))
                .Append(MlContext.Transforms.Text.FeaturizeText("TextFeaturized", nameof(Data.Text)))
                .Append(MlContext.Transforms.Concatenate("Features", "TextFeaturized"));

            var trainer = MlContext.MulticlassClassification.Trainers.SdcaMaximumEntropy("Label", "Features")
                .Append(MlContext.Transforms.Conversion.MapKeyToValue("PredictedLabel", "PredictedLabel"));

            var trainingPipeline = dataProcessPipeline.Append(trainer);

            var model = trainingPipeline.Fit(trainingDataView);

            PredictionEngine = MlContext.Model.CreatePredictionEngine<Data, Prediction>(model);
        }
        #endregion

        #region METHOD-CResponse | GetResponse
        /// <summary>
        /// Получение ответа от чат-бота с помощью входных данных пользователя.
        /// </summary>
        /// <param name="UserInput">Входные данные пользователя</param>
        /// <returns>Возвращает ответ бота с текстом и кодом указанным в данных для машинного обучения. ПРЕДУПРЕЖДЕНИЕ: Если чат-бот не понимает, что ввёл пользователь, то он выберет последний элемент из тренировочных данных!</returns>
        public static CResponse GetResponse(string UserInput)
        {
            var input = new Data() { Text = UserInput };

            var prediction = PredictionEngine?.Predict(input);

            var matchingData = TrainingData?.Find(data => data.Response == prediction?.Response);

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
