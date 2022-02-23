using System;
using Microsoft.AspNetCore.Components;

namespace BlazorApp1.Shared.Radio
{

    /// <summary>
    /// Describes context for an <see cref="SmartRadio{TValue}" /> component.
    /// </summary>
    internal class InputRadioContext<TValue>
    {
        private readonly InputRadioContext<TValue>? _parentContext;

        /// <summary>
        /// Gets the name of the input radio group.
        /// </summary>
        public string? GroupName { get; }

        /// <summary>
        /// Gets the current selected value in the input radio group.
        /// </summary>
        public TValue? CurrentValue { get; }

        /// <summary>
        /// Instantiates a new <see cref="InputRadioContext{TValue}" />.
        /// </summary>
        /// <param name="parentContext">The parent <see cref="InputRadioContext{TValue}" />.</param>
        /// <param name="groupName">The name of the input radio group.</param>
        /// <param name="currentValue">The current selected value in the input radio group.</param>
        /// <param name="onChange">Call executed at the group radio level.</param>
        public InputRadioContext(
            InputRadioContext<TValue>? parentContext,
            string? groupName,
            TValue? currentValue,
            Action<ChangeEventArgs> onChange)
        {
            _parentContext = parentContext;
            GroupName = groupName;
            CurrentValue = currentValue;
            _onChange = onChange;
        }

        /// <summary>
        /// Finds an <see cref="InputRadioContext{TValue}" /> in the context's ancestors with the matching <paramref name="groupName" />.
        /// </summary>
        /// <param name="groupName">The group name of the ancestor <see cref="InputRadioContext{TValue}" />.</param>
        /// <returns>The <see cref="InputRadioContext{TValue}" />, or <c>null</c> if none was found.</returns>
        public InputRadioContext<TValue>? FindContextInAncestors(string? groupName)
            => string.Equals(GroupName, groupName) ? this : _parentContext?.FindContextInAncestors(groupName);


        private readonly Action<ChangeEventArgs> _onChange;

        public void CallBack(ChangeEventArgs changeEventArgs)
        {
            _onChange?.Invoke(changeEventArgs);
        }
    }
}
