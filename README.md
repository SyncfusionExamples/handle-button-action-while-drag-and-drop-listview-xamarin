# How to handle button action of ListView item when dragging in Xamarin.Forms (SflistView)?

You can handle the button click action that is loaded in the [ItemTemplate](https://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.SfListView.XForms~Syncfusion.ListView.XForms.SfListView~ItemTemplate.html?) by maintaining a property in the **ViewModel** and skip the process while drag and drop the [ListViewItem](https://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.SfListView.XForms~Syncfusion.ListView.XForms.ListViewItem.html?) using Xamarin.Forms SfListView.

You can also refer the following article.

https://www.syncfusion.com/kb/11686/how-to-handle-button-action-of-listview-item-when-dragging-in-xamarin-forms-sflistview

**XAML**

Bind Button.Command](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/button#using-the-command-interface) to skip the button click action.
``` xml
<ContentPage xmlns:syncfusion="clr-namespace:Syncfusion.ListView.XForms;assembly=Syncfusion.SfListView.XForms">
    <ContentPage.Content>
        <Grid>
            <syncfusion:SfListView x:Name="listView"
                                   ItemSize="70"
                                   DragStartMode="OnHold"
                                   SelectionBackgroundColor="Transparent"
                                   ItemsSource="{Binding ContactsInfo}">
                <syncfusion:SfListView.Behaviors>
                    <local:Behavior/>
                </syncfusion:SfListView.Behaviors>
                <syncfusion:SfListView.ItemTemplate>
                    <DataTemplate>
                        <ViewCell>
                            <ViewCell.View>
                                <Grid x:Name="grid" RowSpacing="0">
                                    <Button Text="{Binding ContactName}" x:Name="button" Command="{Binding BindingContext.TapCommand ,Source={x:Reference Name=listView}}" CommandParameter="{Binding .}"/>
                                </Grid>
                            </ViewCell.View>
                        </ViewCell>
                    </DataTemplate>
                </syncfusion:SfListView.ItemTemplate>
            </syncfusion:SfListView>
        </Grid>
    </ContentPage.Content>
</ContentPage>
```
**C#**

Behavior class to trigger the [SfListView.ItemDragging](https://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.SfListView.XForms~Syncfusion.ListView.XForms.SfListView~ItemDragging_EV.html?) event. Update the property **isDragEndRaised** to **true**, based on the [DragAction](https://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.SfListView.XForms~Syncfusion.ListView.XForms.ItemDraggingEventArgs~Action.html?).

``` c#
class Behavior : Behavior<SfListView>
{
    public SfListView listview { get; private set; }
    protected override void OnAttachedTo(SfListView bindable)
    {
        base.OnAttachedTo(bindable);
        listview = bindable as SfListView;
        listview.ItemDragging += Listview_ItemDragging;
    }
 
    private void Listview_ItemDragging(object sender, ItemDraggingEventArgs e)
    {
        var viewModel = (sender as SfListView).BindingContext as ListViewGroupingViewModel;
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
```
**C#**

Disable the isDragEndRaised property in the **TapCommand** execution method.
``` c#
public class ListViewGroupingViewModel
{
    private Command tapcommand;
    public Command TapCommand
    {
        get { return tapcommand; }
        set { tapcommand = value; }
    }
    public bool isDragEndRaised = false;
 
    public ListViewGroupingViewModel()
    {
        TapCommand = new Command(OnButtonClick);
        GenerateSource();
    }
 
    private void OnButtonClick(object obj)
    {
        var itemData = obj as ListViewContactsInfo;
 
        if (isDragEndRaised == true)
        {
            isDragEndRaised = false;
            return;
        }
        else
            App.Current.MainPage.DisplayAlert("", "Tapped item data : " + itemData.ContactName, "OK");
    }
}
```
