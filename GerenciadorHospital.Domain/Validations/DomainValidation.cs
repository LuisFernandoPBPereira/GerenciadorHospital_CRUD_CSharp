using Microsoft.VisualBasic;
using System.Text.RegularExpressions;

namespace GerenciadorHospital.Domain.Validations;

public static class DomainValidation
{
    public static void VerifyIsValidString(string field)
    {
        if (field is null) throw new Exception();
        if (field.Equals(string.Empty)) throw new Exception();
    }
    
    public static void VerifyIsStringWithoutNumbers(string field)
    {
        if (Information.IsNumeric(field)) throw new Exception();
        if (Regex.IsMatch(field, "^[0-9]+$")) throw new Exception();
    }

    public static void VerifyIsPositiveNumber(int number)
    {
        if(number <= 0) throw new Exception();
    }

    public static void VerifyIsValidDate(DateTime date)
    {
        if(date < DateTime.Parse("1900-01-01")) throw new Exception();
    }

    public static void VerifyDateIsOnFuture(DateTime date)
    {
        if(date > DateTime.Now) throw new Exception();
    }
}
