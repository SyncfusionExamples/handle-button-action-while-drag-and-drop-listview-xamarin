# How-to-disable-button-action-when-dragging-listview-item

You can disable the button click action which loaded in ItemTemplate by maintaining a property in the view model and skip the process using Xamarin.Forms Listview when Drag and Drop ListViewItem.

```
<ContentPage xmlns:syncfusion="clr-namespace:Syncfusion.ListView.XForms;assembly=Syncfusion.SfListView.XForms">
    <ContentPage.Content>
        <Grid>
            <syncfusion:SfListView x:Name="listView"
                                   ItemSize="70"
                                   DragStartMode="OnHold"
                                   SelectionBackgroundColor="Transparent"
                                   ItemsSource="{Binding ContactsInfo}">  
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

```
    listview.ItemDragging += Listview_ItemDragging;

    private void Listview_ItemDragging(object sender, ItemDraggingEventArgs e)
    {
        if (e.Action == Syncfusion.ListView.XForms.DragAction.Drop)
        {
            viewModel.isDragEndRaised = true;
        }
    }
```

Below code defines you to execute the Button command based on DragAction.

```
public class ListViewGroupingViewModel
{
    private Command tapcommand;
    public bool isDragEndRaised = false;

    public Command TapCommand
    {
        get { return tapcommand; }
        set { tapcommand = value; }
    }

    TapCommand = new Command(OnButtonClick);

    private void OnButtonClick(object obj)
    {
        var itemData = obj as ListViewContactsInfo;

        if (isDragEndRaised == true)
        {
            isDragEndRaised = false;
            return;
        }
        else
            App.Current.MainPage.DisplayAlert("Messsage", "Tapped item data : " + itemData.ContactName, "OK");
    }
}
```
