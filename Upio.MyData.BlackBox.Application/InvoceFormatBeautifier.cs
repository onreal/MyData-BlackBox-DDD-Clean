using System.ComponentModel;
using https.www.aade.gr.myDATA.incomeClassificaton.v1.Item0;
using Upio.MyData.BlackBox.Application.Models;
using www.aade.gr.myDATA.invoice.v1.Item0;

namespace Upio.MyData.BlackBox.Application
{
    public static class InvoceFormatBeautifier
    {
        public static AadeBookInvoiceType GetInvoiceFinal(InvoiceRequest invoice)
        {
            var issuer = GetInvoiceIssuer(invoice);
            var counterPart = GetCounterPart(invoice);
            var invoiceHeader = GetInvoiceHeader(invoice);
            var paymentMethods = GetPaymentMethods(invoice);
            var invoiceDetails = GetInvoicesDetails(invoice);
            var invoiceSummary = GetInvoiceSummary(invoice);
            
            var aadeBookInvoiceType = new AadeBookInvoiceType
            {
                issuer = issuer,
                invoiceHeader = invoiceHeader,
                paymentMethods = paymentMethods,
                invoiceDetails = invoiceDetails,
                invoiceSummary = invoiceSummary
            };
            
            var validateInvoiceType = invoice.InvoiceHeader.InvoiceType.Split(".");
            if (!validateInvoiceType[0].Equals("11"))
            {
                aadeBookInvoiceType.counterpart = counterPart;
            }

            return aadeBookInvoiceType;
        }
        
        private static PartyType GetInvoiceIssuer(InvoiceRequest invoice)
        {
            // validate if countryCode exists on CountryType enum
            if (!Enum.IsDefined(typeof(CountryType), invoice.Issuer.Country))
            {
                // TODO check to throw error
                return null;
            }

            var issuer = invoice.Issuer;
            
            var partyTypeIssuer = new PartyType
            {
                vatNumber = issuer.VatNumber,
                country = Enum.Parse<CountryType>(issuer.Country),
                branch = issuer.Branch != null ? int.Parse(issuer.Branch) : 0
            };

            // If issuer is not from Greece then we must add the hotel name. Required for non GR countries.
            // Για τον εκδότη, τα στοιχεία Επωνυμία και Διεύθυνση δεν γίνονται αποδεκτά στην περίπτωση που αφορούν οντότητα εντός Ελλάδας (GR).
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
        }
        
        private static PartyType GetCounterPart(InvoiceRequest invoice)
        {
            if (!Enum.IsDefined(typeof(CountryType), invoice.Counterpart.Country))
            {
                throw new InvalidEnumArgumentException();
            }
            
            var counterpart = invoice.Counterpart;

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
        }
        
        private static InvoiceHeaderType GetInvoiceHeader(InvoiceRequest invoice)
        {
            if (!Enum.IsDefined(typeof(CurrencyType), invoice.InvoiceHeader.Currency))
            {
                throw new InvalidEnumArgumentException();
            }
            
            return new InvoiceHeaderType
            {
                series = invoice.InvoiceHeader.Series ?? "0",
                aa = $"{invoice.InvoiceHeader.Aa}",
                issueDate = DateTime.Now,
                invoiceType = invoice.InvoiceHeader.InvoiceType,
                currency = Enum.Parse<CurrencyType>(invoice.InvoiceHeader.Currency)
            };
        }
        
        private static AadeBookInvoiceType.paymentMethodsLocalType GetPaymentMethods(InvoiceRequest invoice)
        {
            var paymentMethod = new AadeBookInvoiceType.paymentMethodsLocalType();
            var paymentMethodDetails = invoice.PaymentMethods.PaymentMethodDetails.Select(
                payment => new PaymentMethodDetailType { type = int.Parse(payment.Type), amount = decimal.Parse(payment.Amount) }).ToList();

            paymentMethod.paymentMethodDetails = paymentMethodDetails;

            return paymentMethod;
        }
        
        private static List<InvoiceRowType> GetInvoicesDetails(InvoiceRequest invoice)
        {
            var invoiceDetails = new List<InvoiceRowType>();
            
            for (var i = 0; invoice.InvoiceDetails.Count > i; i++)
            {
                var incomeClassification = new List<IncomeClassificationType>
                {
                    GetIncomeClassification(
                        invoice.InvoiceDetails[i].IncomeClassification.ClassificationCategory,
                        invoice.InvoiceDetails[i].IncomeClassification.ClassificationType,
                        Convert.ToDecimal(invoice.InvoiceDetails[i].IncomeClassification.Amount))
                };
                
                var invoiceTypeRow = new InvoiceRowType
                {
                    lineNumber = i + 1,
                    netValue = Convert.ToDecimal(invoice.InvoiceDetails[i].NetValue),
                    vatCategory = Convert.ToInt32(invoice.InvoiceDetails[i].VatCategory),
                    vatAmount = Convert.ToDecimal(invoice.InvoiceDetails[i].VatAmount),
                    incomeClassification = incomeClassification
                };
                
                if (invoice.InvoiceDetails[i].VatExemptionCategory != null)
                {
                    invoiceTypeRow.vatExemptionCategory =
                        int.Parse(invoice.InvoiceDetails[i].VatExemptionCategory);
                }

                invoiceDetails.Add(invoiceTypeRow);
            }

            return invoiceDetails;
        }
        
        private static InvoiceSummaryType GetInvoiceSummary(InvoiceRequest invoice)
        {
            var totalNetValue = decimal.Zero;
            var totalVatAmount = decimal.Zero;
            var totalGrossValue = decimal.Zero;
            var incomeClassification = new List<IncomeClassificationType>();
            
            foreach (var detail in invoice.InvoiceDetails)
            {
                var mydataRevenueCategoryType = detail.IncomeClassification.ClassificationCategory;
                var mydataRevenueCategory = detail.IncomeClassification.ClassificationType;
                var parsedMydataRevenueCategory = Enum.Parse<IncomeClassificationValueType>(mydataRevenueCategory);
                var grossAmount = decimal.Round(decimal.Parse(detail.NetValue) + decimal.Parse(detail.VatAmount), 2);
                var vatAmount = decimal.Round(decimal.Parse(detail.VatAmount), 2);
                var netAmount = decimal.Round(decimal.Parse(detail.NetValue), 2);
                
                totalNetValue += netAmount;
                totalVatAmount += vatAmount;
                totalGrossValue += grossAmount;
                
                var existingClassification = 
                    incomeClassification.FindIndex(a => a.classificationType.Equals(parsedMydataRevenueCategory));
                if (existingClassification >= 0)
                {
                    incomeClassification[existingClassification].amount = totalNetValue;
                } 
                else
                {
                    incomeClassification.Add(GetIncomeClassification(mydataRevenueCategoryType, 
                        mydataRevenueCategory, totalNetValue, true));
                }
            }
            
            return new InvoiceSummaryType
            {
                totalNetValue = totalNetValue,
                totalVatAmount = totalVatAmount,
                totalWithheldAmount = Convert.ToDecimal(invoice.InvoiceSummary.totalWithheldAmount),
                totalFeesAmount = Convert.ToDecimal(invoice.InvoiceSummary.totalFeesAmount),
                totalStampDutyAmount = Convert.ToDecimal(invoice.InvoiceSummary.totalStampDutyAmount),
                totalOtherTaxesAmount = Convert.ToDecimal(invoice.InvoiceSummary.totalOtherTaxesAmount),
                totalDeductionsAmount = Convert.ToDecimal(invoice.InvoiceSummary.totalDeductionsAmount),
                totalGrossValue = totalGrossValue,
                incomeClassification = incomeClassification
            };
        }
        
        private static IncomeClassificationType GetIncomeClassification(string incomeClassificationCategoryType, 
            string incomeClassificationValueType, decimal amount, bool isSummary = false)
        {
            if (!Enum.IsDefined(typeof(IncomeClassificationCategoryType), incomeClassificationCategoryType.ToLower()))
            {
                throw new InvalidEnumArgumentException();
            }
            
            if (!Enum.IsDefined(typeof(IncomeClassificationValueType), incomeClassificationValueType))
            {
                throw new InvalidEnumArgumentException();
            }
            
            var incomeClassificationType = new IncomeClassificationType
            {
                amount = decimal.Round(amount, 2),
                classificationCategory = Enum.Parse<IncomeClassificationCategoryType>(incomeClassificationCategoryType.ToLower()),
                classificationType = Enum.Parse<IncomeClassificationValueType>(incomeClassificationValueType)
            };

            return incomeClassificationType;
        }
    }
}