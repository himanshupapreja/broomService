using System;
using System.Collections.Generic;
using System.Text;

namespace BroomService.Models
{
    public class TermConditionModel
    {
        public int Id { get; set; }
        public string TermsConditionText { get; set; }
    }

    public class TermConditionResponseModel
    {
        public bool status { get; set; }
        public string message { get; set; }
        public TermConditionModel TermsConditionsData { get; set; }
    }

    public class PrivacyPolicyModel
    {
        public int Id { get; set; }
        public string PrivacyPolicyText { get; set; }
    }

    public class PrivacyPolicyResponseModel
    {
        public bool status { get; set; }
        public string message { get; set; }
        public PrivacyPolicyModel PrivacyPolicyData { get; set; }
    }

    public class AboutUsModel
    {
        public int AboutUsId { get; set; }
        public string Text { get; set; }
    }

    public class AboutUsResponseModel
    {
        public bool status { get; set; }
        public string message { get; set; }
        public AboutUsModel AboutUsData { get; set; }
    }
}
