using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CWS.SimpleBank.Data;

namespace CWS.SimpleBank.Models
{
    public interface IAccountProcessor
    {
        decimal CalculateInterest(Account account, int days);
    }
}
