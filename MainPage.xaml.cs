namespace PayApp;

public partial class MainPage : ContentPage
{
	decimal bill;
	int tip;
	int noPerson = 1;

	public MainPage()
	{
		InitializeComponent();
	}

    void txtBill_Completed(System.Object sender, System.EventArgs e)
    {
		bill = decimal.Parse(txtBill.Text);
		CalculateTotal();
    }

    private void CalculateTotal()
    {
        // Total Tip
        var totalTip = (bill * tip) / 100;


        // Tip by Person
        var tipByPerson = (totalTip / noPerson);
        lblTipByPerson.Text = $"{tipByPerson:C}";

        // Subtotal
        var subtotal = (bill / noPerson);
        lblSubtotal.Text = $"{subtotal:C}";

        // Total
        var totalByPerson = (bill + totalTip) / noPerson;
        lblTotal.Text = $"{totalByPerson:C}";
    }

    void sldTip_ValueChanged(System.Object sender, Microsoft.Maui.Controls.ValueChangedEventArgs e)
    {
        tip = (int)sldTip.Value;
        lblTip.Text = $"Tip: {tip}%";
        CalculateTotal();
    }

    void Button_Clicked(System.Object sender, System.EventArgs e)
    {
        if(sender is Button)
        {
            var btn = (Button)sender;
            var percentage = int.Parse(btn.Text.Replace("%", ""));
            sldTip.Value = percentage;
        }
    }

    void btnMinus_Clicked(System.Object sender, System.EventArgs e)
    {
        if(noPerson > 1)
        {
            noPerson--;
        }
        lblNoPerson.Text = noPerson.ToString();
        CalculateTotal();
    }

    void btnPlus_Clicked(System.Object sender, System.EventArgs e)
    {
        noPerson++;
        lblNoPerson.Text = noPerson.ToString();
        CalculateTotal();
    }
}


