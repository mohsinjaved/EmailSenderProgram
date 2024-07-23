using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSenderProgram.Services.Templates
{
    public interface ITemplateService
    {
        string RenderTemplate<T>(string templateName, T model);
    }
}
