using System;
using System.Collections.Generic;

namespace WinUiProject.Services.Api
{
    public class SendPromptApiResponse
    {
        public string Model { get; set; }
        public DateTime Created_at { get; set; }
        public string Response { get; set; }
        public bool Done { get; set; }
        public List<int> Context { get; set; }
        public int Total_duration { get; set; }
        public int Load_duration { get; set; }
        public int Promtp_eval_count { get; set; }
        public int Promtp_eval_duration { get; set; }
        public int Eval_count { get; set; }
        public int Eval_duration { get; set; }
    }
}
