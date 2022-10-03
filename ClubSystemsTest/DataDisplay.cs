using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ClubSystemsTest
{
    public class DataDisplay
    {
        public static string ClientNameList()
        {
            string clientNameList = string.Empty;
            var clients = DatabaseOperations.GetClientList();

            foreach (var client in clients)
            {
                clientNameList += "<p>" + client.Forename + " " + client.Surname + "</p>";
            }

            return clientNameList;
        }
        public static string MembershipList()
        {
            string membershipList = string.Empty;
            var clients = DatabaseOperations.GetClientList();

            foreach (var client in clients)
            {
                membershipList += "<h3>" + client.Forename + " " + client.Surname + " memberships:</h3>";
                var memberships = DatabaseOperations.GetMembershipsFromClient(client.ClientID);

                foreach (var membership in memberships)
                {
                    membershipList += "<p>" + membership.membershipType.Name + ": Balance " + FormatCentsToCash(membership.Balance, "£") + "</p>";
                }
            }

            return membershipList;
        }

        public static string NegativeBalanceList()
        {
            string negativeBalanceList = string.Empty;

            var memberships = DatabaseOperations.GetMembershipsNegativeBalance();
            foreach (var membership in memberships)
            {
                negativeBalanceList += "<p>" + membership.client.Forename 
                    + " " + membership.client.Surname 
                    + ", " + membership.membershipType.Name 
                    + ": " + FormatCentsToCash(membership.Balance, "£") 
                    + "</p>";
            }

            return negativeBalanceList;
        }


        public static string FormatCentsToCash(int cash, string symbol)
        {
            //Converts stored cent values to proper display
            string formattedCash = string.Empty;

            if (cash < 0)
            {
                //display negative cash values
                cash = 0 - cash;
                symbol = "-" + symbol;
            }
            string cashString = cash.ToString();

            if (cashString.Length == 0)
            {
                formattedCash = symbol + "0.00";
            }
            else if (cashString.Length == 1)
            {
                formattedCash = symbol + "0.0" + cashString;
            }
            else if (cashString.Length == 2)
            {
                formattedCash = symbol + "0." + cashString;
            }
            else 
            {
                formattedCash = symbol + cashString.Substring(0, cashString.Length - 2) + "." + cashString.Substring(cashString.Length - 2, 2);
            }

            return formattedCash;
        }
    }
}
