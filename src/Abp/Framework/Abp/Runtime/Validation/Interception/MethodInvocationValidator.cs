using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using Abp.Utils.Extensions.Collections;

namespace Abp.Runtime.Validation.Interception
{
    /// <summary>
    /// This class is used to validate a method call (invocation) for method arguments.
    /// </summary>
    internal class MethodInvocationValidator
    {
        private readonly object[] _arguments;
        private readonly ParameterInfo[] _parameters;
        
        private readonly List<ValidationResult> _validationErrors;

        /// <summary>
        /// Creates a new <see cref="MethodInvocationValidator"/> instance.
        /// </summary>
        /// <param name="method">Method to be validated</param>
        /// <param name="arguments">List of arguments those are used to call the <see cref="method"/>.</param>
        public MethodInvocationValidator(MethodInfo method, object[] arguments)
        {
            _arguments = arguments;
            _parameters = method.GetParameters();

            _validationErrors = new List<ValidationResult>();
        }

        /// <summary>
        /// Validates the method invocation.
        /// </summary>
        public void Validate()
        {
            if (_parameters.IsNullOrEmpty())
            {
                //Object has no parameter, no need to validate.
                return;
            }

            if (_parameters.Length != _arguments.Length)
            {
                throw new Exception("Method parameter count does not match with argument count!");
            }

            for (var i = 0; i < _parameters.Length; i++)
            {
                Validate(_parameters[i], _arguments[i]);
            }

            if (_validationErrors.Any())
            {
                throw new AbpValidationException("Method arguments are not valid! See ValidationErrors for details.") { ValidationErrors = _validationErrors };
            }
        }

        /// <summary>
        /// Validates given parameter for given argument.
        /// </summary>
        /// <param name="parameter">Parameter of the method to validate</param>
        /// <param name="argument">Argument to validate</param>
        private void Validate(ParameterInfo parameter, object argument)
        {
            if (argument == null)
            {
                if (!parameter.IsOptional && !parameter.IsOut)
                {
                    _validationErrors.Add(new ValidationResult(parameter.Name + " is null!")); //TODO@Halil: What if null value is acceptable?
                }
                
                return;
            }

            if (argument is IValidate)
            {
                SetValidationAttributeErrors(argument);
            }

            if (argument is ICustomValidate)
            {
                (argument as ICustomValidate).AddValidationErrors(_validationErrors);
            }
        }

        /// <summary>
        /// Checks all properties for DataAnnotations attributes.
        /// </summary>
        private void SetValidationAttributeErrors(object argument)
        {
            var validationContext = new ValidationContext(argument);

            var properties = TypeDescriptor.GetProperties(argument).Cast<PropertyDescriptor>();
            foreach (var property in properties)
            {
                 foreach (var attribute in property.Attributes.OfType<ValidationAttribute>())
                {
                    var result = attribute.GetValidationResult(property.GetValue(argument), validationContext);
                    if (result != null)
                    {
                        _validationErrors.Add(result);
                    }
                }
            }
        }
    }
}