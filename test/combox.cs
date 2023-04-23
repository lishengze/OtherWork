 public Form1(){
    InitializeComponent();
    cbBoxYear.BeginUpdate();
    for (int i = 1980; i < 2013; i++){
        cbBoxYear.Items.Add(i.ToString());
    }
    cbBoxYear.EndUpdate();cbBoxMonth.BeginUpdate();
    for (int i = 1; i <= 12; i++){cbBoxMonth.Items.Add(i.ToString());}
    cbBoxMonth.EndUpdate();cbBoxDay.BeginUpdate();
    for (int i = 1; i < 31; i++){cbBoxDay.Items.Add(i.ToString());}cbBoxDay.EndUpdate();
}
