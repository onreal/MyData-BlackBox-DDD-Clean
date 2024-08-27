using System.ComponentModel;
using https.www.aade.gr.myDATA.incomeClassificaton.v1.Item0;

namespace Upio.MyData.BlackBox.Application.Helpers;

public static class Helper
{
    public static async Task<IncomeClassificationType> GetIncomeClassification(
        string incomeClassificationCategoryType,
        string incomeClassificationValueType,
        decimal amount
    )
    {
        return await Task.Run(() =>
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
                classificationCategory =
                    Enum.Parse<IncomeClassificationCategoryType>(incomeClassificationCategoryType.ToLower()),
                classificationType = Enum.Parse<IncomeClassificationValueType>(incomeClassificationValueType)
            };

            return incomeClassificationType;
        });
    }
}