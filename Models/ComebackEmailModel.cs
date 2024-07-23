using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSenderProgram.Models
{
    public class ComebackEmailModel
    {
        public ComebackEmailModel(string email, string voucherCode)
        {
            this.Email = email;
            this.VoucherCode = voucherCode; 
        }
        public string Email { get; set; }
        public string VoucherCode { get; set; }
    }
}
