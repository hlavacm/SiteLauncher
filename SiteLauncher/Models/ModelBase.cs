using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using Netcorex.SiteLauncher.Common;
using Netcorex.SiteLauncher.Localization;

namespace Netcorex.SiteLauncher.Models
{
  /// <summary>
  /// Společný základ pro modely, obsahuje především validační záležitosti
  /// </summary>
  public abstract class ModelBase : BindableBase, IDataErrorInfo
  {
    private static readonly string s_DefaultValidationErrorText = Titles.ValidationError;
    private readonly Dictionary<string, Func<ModelBase, object>> m_PropertyGetters;
    private readonly Dictionary<string, ValidationAttribute[]> m_Validators;
    private bool m_IsVerified;


    protected ModelBase()
    {
      m_Validators = GetType()
        .GetProperties()
        .Where(p => GetValidations(p).Length != 0)
        .ToDictionary(p => p.Name, GetValidations);

      m_PropertyGetters = GetType()
        .GetProperties()
        .Where(p => GetValidations(p).Length != 0)
        .ToDictionary(p => p.Name, GetValueGetter);
    }


    public bool IsVerified
    {
      get { return m_IsVerified; }
      protected set { SetProperty(ref m_IsVerified, value, "IsVerified"); }
    }
    public string this[string propertyName]
    {
      get
      {
        string result = null;
        if (m_PropertyGetters.ContainsKey(propertyName))
        {
          object propertyValue = m_PropertyGetters[propertyName](this);

          List<string> errors = new List<string>();
          foreach (var validator in m_Validators[propertyName])
          {
            if (validator.IsValid(propertyValue))
              continue;
            errors.Add(validator.ErrorMessage ?? s_DefaultValidationErrorText);
          }
          result = string.Join(Environment.NewLine, errors);
        }
        OnPropertyChanged("IsValid");
        return result;
      }
    }
    public string Error
    {
      get
      {
        string[] errors = (from validator in m_Validators
                           from attribute in validator.Value
                           where !attribute.IsValid(m_PropertyGetters[validator.Key](this))
                           select attribute.ErrorMessage ?? s_DefaultValidationErrorText).ToArray();
        if (errors.Length == 0)
          return null;
        return string.Join(Environment.NewLine, errors);
      }
    }
    public bool IsValid
    {
      get { return Error == null; }
    }



    public bool IsPropertyValid(string propertyName = null)
    {
      if (string.IsNullOrEmpty(propertyName))
        return string.IsNullOrEmpty(Error);
      return string.IsNullOrEmpty(this[propertyName]);
    }


    private ValidationAttribute[] GetValidations(PropertyInfo property)
    {
      if (property == null)
        return null;
      return property.GetCustomAttributes(typeof(ValidationAttribute), true) as ValidationAttribute[];
    }

    private Func<ModelBase, object> GetValueGetter(PropertyInfo property)
    {
      return x => property.GetValue(x, null);
    }
  }
}