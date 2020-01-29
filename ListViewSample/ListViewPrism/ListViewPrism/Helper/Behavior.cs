using Syncfusion.ListView.XForms;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Grouping
{
    class Behavior : Behavior <SfListView>
    {
        ListViewGroupingViewModel viewModel;
        public SfListView listview { get; private set; }
        protected override void OnAttachedTo(SfListView bindable)
        {
            base.OnAttachedTo(bindable);
            listview = bindable as SfListView;
            viewModel = new ListViewGroupingViewModel();
            listview.BindingContext = viewModel;
            listview.ItemDragging += Listview_ItemDragging;
        }

        private void Listview_ItemDragging(object sender, ItemDraggingEventArgs e)
        {
            if (e.Action == Syncfusion.ListView.XForms.DragAction.Drop)
            {
                viewModel.isDragEndRaised = true;
            }
        }

        protected override void OnDetachingFrom(SfListView bindable)
        {
            base.OnDetachingFrom(bindable);
            listview.ItemDragging -= Listview_ItemDragging;
            listview = null;
        }
    }
}
