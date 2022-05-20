using Logic.Interface;
using Models;
using Repository.Class;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sib_api_v3_sdk.Api;
using sib_api_v3_sdk.Client;
using sib_api_v3_sdk.Model;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace Logic.Class
{
    public class TransactionLogic : ITransactionLogic
    {
        private ITransactionRepository transactionRepo;
        private string SendInBlueApiKey { get; }
        private string SendInBlueDefaultSender { get; }
        private string SendInBlueDefaultSenderEmail { get; }

        public TransactionLogic(string dbPassword, string apiKey, string sender, string senderEmail)
        {
            Console.WriteLine(apiKey);
            this.transactionRepo = new TransactionRepository(dbPassword);
            this.SendInBlueApiKey = apiKey;
            this.SendInBlueDefaultSender = sender;
            this.SendInBlueDefaultSenderEmail = senderEmail;
        }

        public TransactionLogic(ITransactionRepository repo)
        {
            this.transactionRepo = repo;
        }

        public void sendEmailAboutTransaction(TransactionEmailOptions options)
        {
            try
            {
                Debug.WriteLine("Sending email about transaction");
                Configuration.Default.ApiKey.Add("api-key", this.SendInBlueApiKey);
                int templateNumber = 3;
                if (options.adminTransaction) templateNumber = 4;
                var apiInstance = new TransactionalEmailsApi();
                SendSmtpEmailSender Email = new SendSmtpEmailSender(SendInBlueDefaultSender, SendInBlueDefaultSenderEmail);
                string ToEmail = options.destinationEmail;
                string ToName = options.destinationEmail;
                SendSmtpEmailTo smtpEmailTo = new SendSmtpEmailTo(options.destinationEmail, options.destinationName);
                List<SendSmtpEmailTo> To = new List<SendSmtpEmailTo>();
                To.Add(smtpEmailTo);
                string Subject = templateNumber == 3 ? "Tranzakció került jóváírásra" : "Jóváírás történt a számládra egy admin által";
                JObject Params = new JObject();
                Params.Add("email", options.destinationEmail);
                Params.Add("TRNSACTIONAMOUNT", options.amount.ToString());
                Params.Add("TRANSACTIONUSER", options.fromUser);
                Debug.WriteLine("asd");
                SendSmtpEmailAttachment asd = new SendSmtpEmailAttachment();
                SendSmtpEmailTo1 smtpEmailTo1 = new SendSmtpEmailTo1(ToEmail, ToName);
                List<SendSmtpEmailTo1> To1 = new List<SendSmtpEmailTo1>();
                To1.Add(smtpEmailTo1);
                try
                {
                    var sendSmtpEmail = new SendSmtpEmail(Email, To, null, null, null, null, Subject, null, null, null, templateNumber, Params, null, null);
                    CreateSmtpEmail result = apiInstance.SendTransacEmail(sendSmtpEmail);
                    Debug.WriteLine(result.ToJson());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    Debug.WriteLine("Inner error: " + e.Message);
                }
                Debug.WriteLine("Finish");
            }
            catch (Exception e)
            {
                Debug.WriteLine("outer error: "+e.Message);
            }
            
        }


        public bool CreateTransaction(Transaction transaction)
        {
            if(!this.UserCanCompleteTransaction(transaction)) return false;
            try
            {
                this.transactionRepo.Add(transaction);
                this.UpdateUsersWithTransactionAmount(transaction);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteTransaction(string id)
        {
            try
            {
                this.transactionRepo.Delete(id);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool EditTransaction(string id, Transaction newTransaction)
        {
            try
            {
                this.transactionRepo.Update(id, newTransaction);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IQueryable<Transaction> GetAllTransaction()
        {
            return this.transactionRepo.GetAll();
        }

        public Transaction GetOneTransaction(string id)
        {
            return this.transactionRepo.GetOne(id);
        }

        private bool UserCanCompleteTransaction(Transaction transaction)
        {
            return this.transactionRepo.GetUserFromTransaction(transaction.Source).NikCoin >= transaction.Quantity;
        }

        private void UpdateUsersWithTransactionAmount(Transaction transaction)
        {
            this.transactionRepo.UpdateUserWithTransactionAmount(transaction.Source, transaction.Quantity * -1);
            this.transactionRepo.UpdateUserWithTransactionAmount(transaction.Recipient, transaction.Quantity);
        }
    }
}
