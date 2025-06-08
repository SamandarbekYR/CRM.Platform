using Microsoft.AspNetCore.Mvc.ModelBinding;
using StatusGeneric;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CRM.DataAccess.Extensions;

public static class ValidationHelper
{
    public static void CopyErrorsToModelState<T>(this IStatusGeneric status, ModelStateDictionary modelState, T displayDto)
    {
        if (!status.HasErrors)
        {
            return;
        }

        IList<string> source = PropertyNamesInDto(displayDto);
        foreach (ValidationResult item in status.Errors.Select((ErrorGeneric x) => x.ErrorResult))
        {
            if (!item.MemberNames.Any())
            {
                modelState.AddModelError("", item.ErrorMessage);
                continue;
            }

            foreach (string errorKeyName in item.MemberNames)
            {
                modelState.AddModelError(source.Any((string x) => x == errorKeyName) ? errorKeyName : "", item.ErrorMessage);
            }
        }
    }

    public static void CopyErrorsToModelState(this IStatusGeneric status, ModelStateDictionary modelState)
    {
        if (!status.HasErrors)
        {
            return;
        }

        foreach (ErrorGeneric error in status.Errors)
        {
            if (error.ErrorResult.MemberNames.Count() == 1)
            {
                modelState.AddModelError(error.ErrorResult.MemberNames.First(), error.ToString());
            }
            else
            {
                modelState.AddModelError("", error.ToString());
            }
        }
    }

    private static IList<string> PropertyNamesInDto<T>(T objectToCheck)
    {
        return (from x in objectToCheck.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public)
                select x.Name).ToList();
    }
}
