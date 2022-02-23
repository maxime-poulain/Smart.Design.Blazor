using Microsoft.AspNetCore.Components;
using Smart.Design.Blazor;

namespace BlazorApp1.Shared.Radio
{
    public partial class SmartRadioGroup<TValue> : InputBase<TValue>
    {
        private readonly string? _defaultGroupName = Guid.NewGuid().ToString("N");
        private InputRadioContext<TValue>? _context;

        [Parameter]
        public RenderFragment? ChildContent { get ; set ; }

        [Parameter]
        public string? Name { get; set; }

        [Parameter]
        public string? ValueField { get; set; }

        [CascadingParameter]
        private InputRadioContext<TValue>? CascadedContext { get; set; }

        protected override void OnParametersSet()
        {
            var groupName = !string.IsNullOrEmpty(Name) ? Name : _defaultGroupName;
            _context = new InputRadioContext<TValue>(CascadedContext, groupName, Value, OnChangeCallback);
            base.OnParametersSet();
        }
    }
}