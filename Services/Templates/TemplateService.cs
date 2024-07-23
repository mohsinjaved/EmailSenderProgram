using RazorEngine;
using RazorEngine.Templating;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSenderProgram.Services.Templates
{

    public class TemplateService : ITemplateService
    {
        private readonly string _basePath;
        public TemplateService(string folderName)
        {
            if (string.IsNullOrWhiteSpace(folderName)) throw new ArgumentNullException(nameof(folderName));

            _basePath = Path.Combine(GetRootPath(), folderName);
        }

        public string RenderTemplate<T>(string templateName, T model)
        {
            var templatePath = Path.Combine(_basePath, templateName);
            try
            {
                var template = File.ReadAllText(templatePath);
                var updatedTemplate = Engine.Razor.RunCompile(template, templatePath, null, model);
                return updatedTemplate;
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"Template file not found: {templatePath}");
                return string.Empty;
            }
            catch (Exception)
            {
                Console.WriteLine($"Error while loading template.{templateName}");
                return string.Empty;
            }


        }
        private string GetRootPath()
        {
            // Go up two levels from /bin/debug or /bin/release to get to the project root
            return Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
        }
    }
}
