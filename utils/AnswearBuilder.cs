using AIFormHelper.Models;
namespace AIFormHelper.utils
{
    public class AnswearBuilder : IBuilder<MyRequestDTO>
    {
        private readonly string _answear;

        public AnswearBuilder(string answear)
        {
            _answear = answear;
        }

        public MyRequestDTO Build()
        {
            var lines = _answear.Split('\n');
            var form = new Form
            {
                Firstname = lines[0].Split(':')[1].Trim(),
                Lastname = lines[1].Split(':')[1].Trim(),
                Email = lines[2].Split(':')[1].Trim(),
                ReasonOfContact = lines[3].Split(':')[1].Trim(),
                Urgency = int.Parse(lines[4].Split(':')[1].Trim())
            };
            string content = string.Join('\n', lines.Skip(5));
            var request = new MyRequestDTO
            {
                Form = form,
                Content = content
            };
            return request;
        }
    }
}
