using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace Budgeter
{
    public class XMLConfig
    {
        private static Config instance;
        private static XmlSerializer serializer = new XmlSerializer(typeof(Config));
        private static readonly string configFile = "AcctInfo.xml";

        private XMLConfig()
        {
        }

        public static Config Instance
        {
            get
            {
                if (instance == null)
                {
                    using (StreamReader reader = new StreamReader(configFile))
                    {
                        try
                        { 
                            instance = (Config)serializer.Deserialize(reader);
                        }
                        catch(Exception e)
                        {
                            // TODO: handle exception
                        }
                    }
                }
                return instance;
            }
        }

        public static void Save()
        {
            using (StreamWriter writer = new StreamWriter(configFile))
            {
                serializer.Serialize(writer, Instance);
            }
        }
    }

    [XmlRoot()]
    public class Config
    {
        [XmlArrayItem(ElementName = "Account", Type = typeof(Account))]
        public List<Account> Accounts { get; set; }

        [XmlArrayItem(ElementName = "Envelope", Type = typeof(Envelope))]
        public List<Envelope> Envelopes { get; set; }

        [XmlArrayItem(ElementName = "RecurringBill", Type = typeof(RecurringBill))]
        public List<RecurringBill> RecurringBills { get; set; }

        [XmlArrayItem(ElementName = "Goal", Type = typeof(Goal))]
        public List<Goal> Goals { get; set; }

        [XmlArrayItem(ElementName = "CommonTransaction", Type = typeof(CommonTransaction))]
        public List<CommonTransaction> CommonTransactions { get; set; }

        public Config()
        {
            Accounts = new List<Account>();
            Envelopes = new List<Envelope>();
            RecurringBills = new List<RecurringBill>();
            Goals = new List<Goal>();
            CommonTransactions = new List<CommonTransaction>();
        }

    }
    
    public class Account
    {
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "Type")]
        public string Type { get; set; }

        [XmlElement(ElementName = "AvailableAmount")]
        public decimal AvailableAmount { get; set; }

        [XmlElement(ElementName = "UpdateDate")]
        public string UpdateDate { get; set; }

        [XmlArray(ElementName = "AssociatedEnvelopes")]
        [XmlArrayItem(ElementName = "AssociatedEnvelope", Type = typeof(string))]
        public List<string> AssociatedEnvelopes { get; set; }

        public Account()
        {
            AssociatedEnvelopes = new List<string>();
        }
    }

    public class Envelope
    {
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "BudgetedAmount")]
        public decimal BudgetedAmount { get; set; }

        [XmlElement(ElementName = "AvailableAmount")]
        public decimal AvailableAmount { get; set; }
    }

    public class RecurringBill
    {
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "Amount")]
        public decimal Amount { get; set; }

        [XmlElement(ElementName = "Date")]
        public int Date { get; set; }
    }

    public class Goal
    {
        public string Name { get; set; }

        public decimal Target { get; set; }

        public decimal CurrentAmount { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }
    }

    public class CommonTransaction
    {
        public string Name { get; set; }

        public decimal AverageAmount { get; set; }

        public uint NumberOfCharges { get; set; }
    }

}
