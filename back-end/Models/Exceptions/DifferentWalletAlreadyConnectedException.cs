using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class DifferentWalletAlreadyConnectedException : Exception
    {
        public override string Message { get; }
        public string NewAddress { get; set; }
        public string OldAddress { get; set; }
        public string UserName { get; set; }

        public DifferentWalletAlreadyConnectedException(string newAddress, string oldAddress, string userName)
        {
            this.NewAddress = newAddress;
            this.OldAddress = oldAddress;
            this.UserName = userName;
            this.Message = String.Format(
                $"The user {this.UserName} already has a wallet connected." +
                $"Connected wallett address: {this.OldAddress}." +
                $"Failed to connect new wallet: {this.NewAddress}"
                );
        }
    }
}
