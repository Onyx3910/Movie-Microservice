using eShop.Tickets.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace eShop.Tickets.Domain
{
    public record CreditCardPayment(
        [CreditCard] string CardNumber,
        string CardHolder,
        DateOnly ExpirationDate,
        int SecurityCode,
        Address Address);
}
