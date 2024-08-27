using System.ComponentModel;
using Upio.MyData.BlackBox.Application.Models;
using www.aade.gr.myDATA.invoice.v1.Item0;

namespace Upio.MyData.BlackBox.Application.Translators;

public class CounterPartTranslator
{
    public async Task<PartyType> fromModelAsync(Counterpart counterpart)
    {
        return await Task.Run(() =>
        {
            if (!Enum.IsDefined(typeof(CountryType), counterpart.Country))
            {
                throw new InvalidEnumArgumentException();
            }

            var counterPart = new PartyType
            {
                country = Enum.Parse<CountryType>(counterpart.Country),
                branch = 0,
            };

            var address = new AddressType
            {
                street = counterpart.Address.Street,
                number = counterpart.Address.Number,
                postalCode = counterpart.Address.PostalCode,
                city = counterpart.Address.City
            };

            counterPart.name = counterpart.Name;
            counterPart.address = address;
            counterPart.vatNumber = counterpart.VatNumber;

            return counterPart;
        });
    }
}