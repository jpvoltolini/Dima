using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Dima.Core.Enums;

namespace Dima.Core.Requests.Transactions
{
    public class UpdateTransactionRequest : Request
    {
        public long Id { get; set; }
        
        [Required(ErrorMessage = "Título Invalido")]
        public string Title { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Tipo Invalido")]
        public ETransactionType Type { get; set; }

        [Required(ErrorMessage = "Valor Invalido")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Categoria Invalida")]
        public long CategoryId { get; set; }
        
        [Required(ErrorMessage = "Data Invalida")]
        public DateTime? PaidOrReceivedAt { get; set; }
    }
    
}
