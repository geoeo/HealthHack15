using System.Collections.Generic;
using System.IO;
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

            Post["/submitData"] = _ => ProcessSubmission();

            Get["/getDataForUser/{userId}"] = parameters => GetDataForUser(parameters.userId);
        }

        private dynamic GetDataForUser(int userId)
        {
            var eventHistory = LoadEventHistory();

            if (eventHistory.ContainsKey(userId))
                return eventHistory[userId].ToArray();
            return string.Format("Error: UserId: {0} not found", userId);
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
            File.WriteAllText(FILE_NAME, json);
        }

        private static Dictionary<int, List<EventEntry>> LoadEventHistory()
        {
            var eventHistory = new Dictionary<int, List<EventEntry>>();

            if (File.Exists(FILE_NAME))
            {
                var file = File.ReadAllText(FILE_NAME);
                eventHistory =
                    (Dictionary<int, List<EventEntry>>)
                        JsonConvert.DeserializeObject(file, typeof (Dictionary<int, List<EventEntry>>));
            }
            return eventHistory;
        }
    }

    internal class SubmissionDTO
    {
        public int UserId { get; set; }
        public int ApplicationId { get; set; }
        public int EventId { get; set; }
    }

    internal class EventEntry
    {
        public int ApplicationId { get; set; }
        public int EventId { get; set; }
    }
}