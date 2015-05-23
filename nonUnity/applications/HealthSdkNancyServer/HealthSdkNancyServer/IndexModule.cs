using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Nancy;
using Nancy.ModelBinding;
using Newtonsoft.Json;

namespace HealthSdkNancyServer
{
    public class IndexModule : NancyModule
    {
        private const string FILE_NAME = "eventHistory.json";

        public IndexModule()
        {
            Get["/"] = parameters => View["index"];
            Get["/status"] = _ => "I'm Alive!";

            Post["/submitData"] = _ =>
            {
                try
                {
                    return ProcessSubmission();
                }
                catch (Exception e)
                {
                    return e.Message;
                }
            };

            Get["/getDataForUser/{userId}"] = parameters => GetDataForUser(parameters.userId);

            Get["/clearHistory"] = _ => DeleteHistory();
        }

        private dynamic DeleteHistory()
        {
            var emptyEventHistory = new Dictionary<int, List<EventEntry>>();
            SaveEventHistory(emptyEventHistory);

            return Negotiate
                .WithStatusCode(HttpStatusCode.OK)
                .WithModel("History Cleared.");
        }

        private dynamic GetDataForUser(int userId)
        {
            var eventHistory = LoadEventHistory();

            if (eventHistory.ContainsKey(userId))
            {
                var eventEntries = eventHistory[userId].Where(e => !e.Seen).ToArray();
                foreach (var eventEntry in eventEntries)
                {
                    eventEntry.Seen = true;
                }

                SaveEventHistory(eventHistory);

                return eventEntries.ToArray();
            }

            return new EventEntry[0];
        }

        private dynamic ProcessSubmission()
        {

            var submissionDto = this.Bind<SubmissionDTO>();

            var eventHistory = LoadEventHistory();

            if (!eventHistory.ContainsKey(submissionDto.UserId))
            {
                eventHistory.Add(submissionDto.UserId, new List<EventEntry>());
            }

            eventHistory[submissionDto.UserId].Add(new EventEntry
            {
                ApplicationId = submissionDto.ApplicationId,
                EventId = submissionDto.EventId
            });

            SaveEventHistory(eventHistory);


            var userEventEntries = eventHistory[submissionDto.UserId].ToArray();
            return Negotiate
                .WithStatusCode(HttpStatusCode.OK)
                .WithModel(userEventEntries);
        }

        private static void SaveEventHistory(Dictionary<int, List<EventEntry>> eventHistory)
        {
            var json = JsonConvert.SerializeObject(eventHistory, Formatting.Indented);
            File.WriteAllText(GetFilePath(), json);
        }

        private static Dictionary<int, List<EventEntry>> LoadEventHistory()
        {
            var eventHistory = new Dictionary<int, List<EventEntry>>();

            var filePath = GetFilePath();

            if (File.Exists(filePath))
            {
                var file = File.ReadAllText(filePath);
                eventHistory =
                    (Dictionary<int, List<EventEntry>>)
                        JsonConvert.DeserializeObject(file, typeof (Dictionary<int, List<EventEntry>>));
            }
            return eventHistory;
        }

        private static string GetFilePath()
        {
            var filePath = System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" + FILE_NAME;
            return filePath;
        }
    }
}