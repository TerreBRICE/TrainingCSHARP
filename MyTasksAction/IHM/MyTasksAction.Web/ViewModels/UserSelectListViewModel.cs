namespace MyTasksAction.Web.ViewModels;

public class UserSelectListViewModel
{

    string Text { get; set; }
    string Value { get; set; }

    public UserSelectListViewModel(string text, string value)
    {
        Text = text;
        Value = value;  
    }
}
