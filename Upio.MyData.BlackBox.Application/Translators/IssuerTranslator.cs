using System.ComponentModel;
using Upio.MyData.BlackBox.Application.Models;
using www.aade.gr.myDATA.invoice.v1.Item0;

namespace Upio.MyData.BlackBox.Application.Translators;

public class IssuerTranslator
{
    public async Task<PartyType> fromModelAsync(Issuer issuer)
    {
        return await Task.Run(() =>
        {
            if (!Enum.IsDefined(typeof(CountryType), issuer.Country))
            {
                throw new InvalidEnumArgumentException();
            }

            var partyTypeIssuer = new PartyType
            {
                vatNumber = issuer.VatNumber,
                country = Enum.Parse<CountryType>(issuer.Country),
                branch = issuer.Branch != null ? int.Parse(issuer.Branch) : 0
            };
        
            if (issuer.Country.Equals("GR"))
            {
                return partyTypeIssuer;
            }
            
            partyTypeIssuer.address = new AddressType
            {
                postalCode = issuer.Address.PostalCode,
                street = issuer.Address.Street,
                number = issuer.Address.Number,
                city = issuer.Address.City
            };
                
            partyTypeIssuer.name = issuer.Name;

            return partyTypeIssuer;
        });
    }
}