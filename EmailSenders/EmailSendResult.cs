using System.Collections.Generic;

namespace EmailSenderProgram.EmailSenders
{

    public class EmailSendResult
    {
        private List<Customer> _successfulRecipients;
        private List<Customer> _failedRecipients;

        public EmailSendResult()
        {
            _successfulRecipients = new List<Customer>();
            _failedRecipients = new List<Customer>();
        }

        public void AddSuccess(Customer customer)
        {
            _successfulRecipients.Add(customer);
        }

        public void AddFailure(Customer customer)
        {
            _failedRecipients.Add(customer);
        }

        public bool IsSuccess()
        {
            return _failedRecipients.Count <= 0;
        }

        public bool IsAnyFailure()
        {
            return !IsSuccess();
        }

        public List<Customer> GetSuccessfulRecipients()
        {
            return _successfulRecipients;
        }

        public List<Customer> GetFailedRecipients()
        {
            return _failedRecipients;
        }
    }


}
