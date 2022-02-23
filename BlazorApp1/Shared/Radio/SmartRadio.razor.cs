using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace BlazorApp1.Shared.Radio
{
    public partial class SmartRadio<TValue>
    {
        [Parameter]
        public string? Label { get; set; }

        [Parameter]
        public TValue? Value { get; set; }

        public string? Name { get ; set ; }

        [CascadingParameter]
        private InputRadioContext<TValue>? CascadedContext { get; set; }

        private InputRadioContext<TValue> Context { get; set; }

        private bool IsChecked => EqualityComparer<TValue>.Default.Equals(Context.CurrentValue, Value);

        /// <inheritdoc />
        protected override void OnParametersSet()
        {
            Context = string.IsNullOrEmpty(Name) ? CascadedContext : CascadedContext?.FindContextInAncestors(Name);

            if (Context == null)
            {
                throw new InvalidOperationException($"{GetType()} must have an ancestor {typeof(InputRadioGroup<TValue>)} " +
                                                    $"with a matching 'Name' property, if specified.");
            }
        }

        private void OnChange(ChangeEventArgs changeEventArgs)
        {
            Context.CallBack(changeEventArgs);
        }
    }
}