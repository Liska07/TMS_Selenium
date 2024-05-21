using NLog;

namespace TMS_Selenium.Models
{
    public class ProjectModel
    {
        private Logger _logger = LogManager.GetCurrentClassLogger();
        public string Name { get; }
        public string? Announcement { get; set; }
        public bool? IsShowAnnouncement { get; set; }
        public string? ProjectTypeByValue { get; set; }
        public bool? IsEnableTestCase { get; set; }

        public ProjectModel(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                _logger.Error("The name of the project can't be empty!");
                throw new ArgumentNullException("The name of the project can't be empty!");
            }
            else
            {
                Name = name;
            }
        }
    }
}
