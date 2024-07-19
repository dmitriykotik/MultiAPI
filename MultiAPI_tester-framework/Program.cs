using System;
using System.Collections.Generic;
using MultiAPI;


namespace MultiAPI_Tester
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var data = new List<Data> 
            { 
                new Data() { Text = "404", Response = "Я вас не понимаю :(", ReturnCode = -1}
            };
           

            ChatBot.Initialize(data);

            while (true)
            {
                var response = ChatBot.GetResponse(Console.ReadLine().ToLower());
                Console.WriteLine($@"RESPONSE:
Response: {response.Response}
ReturnCode: {response.ReturnCode}");
            }
        }
    }


}




