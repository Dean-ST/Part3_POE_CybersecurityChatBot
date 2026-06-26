using System;
using System.Collections.Generic;
using System.Text;

namespace CyberSecurityBot
{
    public class ChatBot
    {
        private KeywordResponder keywordResponder = new KeywordResponder();
        private SentimentDetector sentimentDetector = new SentimentDetector();
        private MemoryStore memory = new MemoryStore();

        public string GetResponse(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return "Type something so I can help you.";

            input = input.ToLower();

            // NAME DETECTION
            if (input.StartsWith("my name is"))
            {
                string name = input.Replace("my name is", "").Trim();
                memory.UserName = name;

                return $"Got it. Nice to meet you {name}.";
            }

            // ERSONAL GREETING
            if (input.Contains("hello") || input.Contains("hi") || input.Contains("hey"))
            {
                if (memory.HasName)
                    return $"Yo {memory.UserName}, what’s up? Let’s secure your digital life.";
                else
                    return "Hi there! What’s your name?";
            }

            //SENTIMENT
            string sentiment = sentimentDetector.Detect(input);

            if (sentiment == "worried")
            {
                return "I understand you're concerned. Stay sharp online. " +
                       keywordResponder.GetResponse(input);
            }

            //NORMAL RESPONSE
            return keywordResponder.GetResponse(input);
        }
    }
}

