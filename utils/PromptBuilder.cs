using AIFormHelper.Models;
using System.Text;

namespace AIFormHelper.utils
{
    public class PromptBuilder : IBuilder<string>
    {
        private MyRequestDTO _request;
        public PromptBuilder(MyRequestDTO request) 
        {
            _request = request;
        }

        public string Build()
        {
            StringBuilder stringBuilder = new StringBuilder();
            var form = _request.Form;
            AppendForm(stringBuilder, form);

            stringBuilder.Append(_request.Content);
            return stringBuilder.ToString();
        }

        public void AppendForm(StringBuilder stringBuilder, Form form)
        {                       
            //stringBuilder.AppendLine("Please fill out the following form:");
            stringBuilder.AppendLine($"Firstname: {form.Firstname}");
            stringBuilder.AppendLine($"Lastname: {form.Lastname}");
            stringBuilder.AppendLine($"Email: {form.Email}");
            stringBuilder.AppendLine($"Reason of Contact: {form.ReasonOfContact}");
            stringBuilder.AppendLine($"Urgency: {form.Urgency}");            
        }
    }
}
