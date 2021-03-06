﻿using Diplom.Dialogs.Attributes;
using DryIoc;
using System;
using System.Windows;

namespace Diplom.Dialogs.Manager
{
    /// <summary>
    /// Dialogs view factory.
    /// </summary>
    class DialogsFactoryView : IDialogsFactoryView
    {
        /// <summary>
        /// Контейнер.
        /// </summary>
        readonly IContainer container;

        /// <summary>
        /// Конструктор.
        /// </summary>
        public DialogsFactoryView(IContainer container)
        {
            this.container = container;
        }

        /// <summary>
        /// Получить view by viewmodel.
        /// </summary>
        /// <returns></returns>
        public object GetView<TViewModel>(TViewModel viewModel)
        {
            var atr = (DialogNameAttribute)Attribute.GetCustomAttribute(typeof(TViewModel), typeof(DialogNameAttribute));

            if (atr == null)
            {
                Logger.Log.Error($"DialogNameAttribute is null: {{viewModel: {viewModel}}}");
                return null;
            }

            var view = container.Resolve<FrameworkElement>(atr.ViewName);

            if (view.GetType().Name == nameof(FrameworkElement))
            {
                Logger.Log.Error($"GetView<T> view is null: {{viewModel: {viewModel}}}");
                return null;
            }

            view.DataContext = viewModel;

            return view;
        }
    }
}
